using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Meteor.Operation.Db;
using Saanaa.Core.AspNetCore.Operations.Db.Accounting.Commands;
using Saanaa.Core.AspNetCore.Operations.Db.Accounting.Dto;
using Saanaa.Core.AspNetCore.Operations.Db.Payment.Command;
using Saanaa.Core.AspNetCore.Operations.Db.Payment.Dto;
using Saanaa.Core.Meteor;
using Tenant.Operations.Transaction.Commands;
using Tenant.Operations.Transaction.Dtos;
using TransactionType = Tenant.Operations.Transaction.TransactionType;

namespace Tenant.Operations.PricingTenant.Commands
{
    public class PricingTenantSettle : DbOperationAsync<PaymentResult, bool>, INeedLog, IHaveTableName
    {
        public string TableName { get; set; } = "[Tenant].[PricingTenant]";

        protected override async Task ExecutionAsync()
        {
            Output = false;
            if (Input.PaymentInfo.IsCompleted && Input.PaymentInfo.IsPaid)
            {
                int sellerTenantId = 0;
                decimal giftAmount = 0;
                decimal vat = 0;
                try
                {
                    vat = Input.PaymentInfo.Amount - (decimal)((float)Input.PaymentInfo.Amount / 1.09);
                    if (Input.PaymentInfo?.AdditionalData?.ContainsKey("giftAmount") == true)
                    {
                        giftAmount = decimal.Parse(Input.PaymentInfo.AdditionalData["giftAmount"].ToString()!);
                    }
                    if (Input.PaymentInfo?.AdditionalData?.ContainsKey("sellerTenantId") == true)
                    {
                        sellerTenantId = int.Parse(Input?.PaymentInfo?.AdditionalData["sellerTenantId"]?.ToString()??"0");
                    }

                    await OperationFactory!.New<TenantTransactionAdd>().ExecuteAsync(new TenantTransactionAddInDto
                    {
                        Code = Input.PaymentInfo.Code,
                        Amount = Input.PaymentInfo.Amount,
                        GiftAmount = giftAmount,
                        TaxAmount = vat,
                        TypeLookup = TransactionType.Online,
                        Description = "پرداخت آنلاین، افزایش اعتبار سازمان",
                        ActionBy = Input.ActionBy ?? 0,
                        TenantId = Input.TenantId
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                try
                {
                    var bankAccountId = await NewSql(sql => sql.Select("[Payment].[GatewayDetail] GatewayDetail",
                            "Gateway.BankAccountId")
                        .InnerJoin("[Payment].[Gateway] Gateway",
                            "GatewayDetail.GatewayId = Gateway.Id")
                        .Where("GatewayDetail.Id = @Id"), new
                    {
                        Id = Input.PaymentInfo.GatewayDetailId
                    }).ExecuteScalarAsync<int>();

                    var document = new DocumentSubmitInDto()
                    {
                        Description =
                            $"{"افزایش اعتبار سازمان با شماره پیگیری پرداخت"} {Input.PaymentInfo.TrackingNumber} {"بابت"} {(Input.PaymentInfo?.AdditionalData?.ContainsKey("title") == true ? Input.PaymentInfo?.AdditionalData?["title"] : "سفارش شماره " + (Input.PaymentInfo?.RequestId ?? 0))}",
                        TenantId = sellerTenantId,
                        TemplateName = "ChargeTenant", ActionBy = Input.ActionBy ?? 0,
                        DocumentDate = DateTime.Now, StatusLookup = StatusLookupEnum.Permanent, TypeLookup = TypeLookupEnum.Auto,
                        Items = new List<DocumentSubmitItemsInDto>()
                        {
                            new DocumentSubmitItemsInDto
                            {
                                Debit = Input.PaymentInfo.Amount - vat + giftAmount,
                                Description = "افزایش اعتبار سازمان",
                                TemplateDetailName = "Tenant",
                                DetailedAccountEntityId = Input.TenantId,
                                DetailedAccountModelName = "Organization",
                                DetailedAccountServiceName = "Tenant"
                            },
                            new DocumentSubmitItemsInDto
                            {
                                Debit = Input.PaymentInfo.Amount,
                                Description = "افزایش موجودی حساب",
                                TemplateDetailName = "Bank",
                                DetailedAccountEntityId = bankAccountId,
                                DetailedAccountModelName = "BankAccount",
                                DetailedAccountServiceName = "Accounting"
                            },
                            new DocumentSubmitItemsInDto
                            {
                                Debit = vat,
                                Description = "مالیات بر ارزش افزوده",
                                TemplateDetailName = "VAT"
                            }
                        }
                    };
                    if (giftAmount > 0)
                    {
                        document.Items.Add(new DocumentSubmitItemsInDto()
                        {
                            Debit = giftAmount,
                            Description = "هدیه افزایش اعتبار",
                            TemplateDetailName = "Gift"
                        });
                    }

                    var documentResult = await OperationFactory!.New<DocumentSubmit>().ExecuteAsync(document);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                try
                {
                    var factor = new FactorUpsertInDto
                    {
                        Id = 0,
                        Title = "فاکتور ارائه خدمات",
                        Description = (Input.PaymentInfo?.AdditionalData?.ContainsKey("title") == true)
                            ? Input.PaymentInfo.AdditionalData["title"].ToString()!
                            : "",
                        Date = DateTime.Now,
                        SellerTenantId = (Input.PaymentInfo?.AdditionalData?.ContainsKey("sellerTenantId") == true)
                            ? sellerTenantId
                            : 0,
                        BuyerTenantId = (int)(Input.PaymentInfo?.TenantId ?? 0),
                        ActionBy = Input.ActionBy ?? 0,
                        TenantId = Input.TenantId,
                        AutoFillTenantData = true,
                        Items = new List<FactorUpsertItem?>
                        {
                            new FactorUpsertItem
                            {
                                Id = 0,
                                ProductCode = Input.PaymentInfo?.AdditionalData?.ContainsKey("pricingId") == true
                                    ? int.Parse(Input.PaymentInfo?.AdditionalData["pricingId"].ToString())
                                    : 0,
                                Title =
                                    $"{(Input.PaymentInfo?.AdditionalData?.ContainsKey("title") == true ? Input.PaymentInfo?.AdditionalData?["title"] : "سفارش شماره " + (Input.PaymentInfo?.RequestId ?? 0))}",
                                Quantity = 1,
                                Amount = Input.PaymentInfo.Amount - vat + giftAmount,
                                Discount = giftAmount,
                                Tax = vat
                            }
                        }
                    };

                    var factorResult = await OperationFactory!.New<FactorUpsert>().ExecuteAsync(factor);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }


                Output = await NewSql(@"EXECUTE Tenant.sp_PricingTenantSettle @TenantId = @TenantId
                                     ,@PricingId = @PricingId
                                     ,@ActionBy = @ActionBy", new
                {
                    Input.TenantId,
                    PricingId = Input.PaymentInfo.RequestId,
                    Input.ActionBy,
                }).ExecuteAsync() > 0;
            }
        }
    }
}
