using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Flow.Core;
using Flow.Core.Models;
using Flow.Operations.Form.Dtos;
using Humanizer;
using Meteor.Operation.Db;
using Newtonsoft.Json;

namespace Flow.Operations.Form.Queries
{
    public class GetFormGridExcel : DbOperationAsync<GetFormGridInDto, byte[]>
    {
        private List<object>? Items { get; set; }
        private IXLWorksheet? Worksheet { get; set; }

        protected override async Task ExecutionAsync()
        {
            Input.Paging = false;
            var grid = await OperationFactory!.New<GetFormGrid>().ExecuteAsync(Input);
            Items = grid?.Items;

            var form = FlowForms.GetForm(Input.FormName);

            using var workbook = new XLWorkbook { RightToLeft = true };
            Worksheet = workbook.Worksheets.Add(form?.Title ?? "Data");

            var properties = form?.Properties.Where(x => !x.IsHiddenInGrid)
                .OrderBy(x => x.LayoutIndex).ToList();
            for (var i = 1; i <= properties?.Count; i++)
            {
                Worksheet.Cell(1, i).Value = properties[i - 1].Title;
                SetHeaderCellStyle(i);
            }


            for (var rowIndex = 0; rowIndex < Items?.Count; rowIndex++)
            {
                var row = Items[rowIndex];
                for (var cellIndex = 0; cellIndex < properties?.Count; cellIndex++)
                {
                    var property = properties[cellIndex];
                    Worksheet.Cell(rowIndex + 2, cellIndex + 1).Value = GetPropertyValue(row, property);
                    SetBodyCellStyle(rowIndex + 2, cellIndex + 1);
                }

                Worksheet.Row(rowIndex + 2).Height = 15;
            }

            for (var i = 1; i <= properties?.Count; i++)
            {
                Worksheet.Column(i).AdjustToContents();
                if (Worksheet.Column(i).Width > 25)
                    Worksheet.Column(i).Width = 25;
                Worksheet.Column(i).Style
                    .Border.SetLeftBorder(XLBorderStyleValues.Thin).Border.SetLeftBorderColor(XLColor.FromArgb(225, 225, 225));
            }

            SetWorksheetStyle();

            await using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            Output = stream.ToArray();
        }

        protected virtual void SetWorksheetStyle()
        {
            Worksheet!.Row(1).Height = 18;
            Worksheet.SheetView.FreezeRows(1);
        }

        protected virtual void SetBodyCellStyle(int rowIndex, int cellIndex)
        {
            Worksheet!.Cell(rowIndex, cellIndex).Style
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Alignment.SetVertical(XLAlignmentVerticalValues.Top)
                .Alignment.SetWrapText(true)
                .Fill.SetBackgroundColor(rowIndex % 2 == 0 ? XLColor.White : XLColor.FromArgb(225, 245, 254));
        }

        protected virtual void SetHeaderCellStyle(int i)
        {
            Worksheet!.Cell(1, i).Style
                .Fill.SetBackgroundColor(XLColor.FromArgb(88, 196, 255))
                .Font.SetBold(true)
                .Font.SetFontColor(XLColor.White)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                .Alignment.SetVertical(XLAlignmentVerticalValues.Center);
        }

        private object? GetPropertyValue(object row, FormPropertyModel property)
        {
            var json = JsonConvert.SerializeObject(row);
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            var propertyName = property.Name;
            if (!string.IsNullOrEmpty(property.RelatedFormPropertyName))
            {
                propertyName = $"{property.RelatedFormName}{property.RelatedFormPropertyName}";
            }
            else if (property.Lookup?.Id > 0)
            {
                propertyName = $"{property.Name}Title";
            }

            var cell = dict.ContainsKey(propertyName.Pascalize()) ? dict[propertyName.Pascalize()] : "";
            if (cell is string && cell.ToString()?.Length > 2000)
            {
                cell = cell.ToString()?.Substring(0, 2000);
            }

            if (property.Type.ToLowerInvariant() == "bool" || property.Type.ToLowerInvariant() == "boolean" )
                cell = (cell?.ToLowerInvariant() == "true" ? "✓" : "✗");
            return cell;
        }
    }
}
