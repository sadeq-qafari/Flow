using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Core.Meteor.Dto;
using Core.Meteor.Extensions;
using Core.Meteor.Models;
using Humanizer;
using Meteor.Operation.Db;
using Meteor.Utils;

namespace Core.Meteor
{
    public class DbQueryExcel<T> : DbOperationAsync<DbQueryPageInDto, byte[]>, IHaveTableName
    {
        public string TableName { get; set; }
        private readonly string? _modelName;
        private readonly string? _serviceName;
        private List<T>? Items { get; set; }
        private IXLWorksheet? Worksheet { get; set; }

        public DbQueryExcel(string tableName)
        {
            TableName = tableName;
            (_serviceName, _modelName) = tableName.TryExtractServiceModelName();
        }

        protected override async Task ExecutionAsync()
        {
            Items = await GetItems();
            var model = SqServices.GetModel(_serviceName, _modelName);
            using var workbook = new XLWorkbook { RightToLeft = true };
            Worksheet = workbook.Worksheets.Add(model?.Title ?? "Data");

            var properties = model?.Properties.Where(x => x.Visible)
                .OrderBy(x => x.Index).ToList();
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

        protected virtual async Task<List<T>?> GetItems()
        {
            var queryPage = await New<DbQueryPage<T>>().SetTableName(TableName).ExecuteAsync(Input);
            var items = queryPage?.Items;
            if (items == null)
                throw Errors.InvalidOperation("no_items");
            return items;
        }


        private object? GetPropertyValue(T row, ModelProperty property)
        {
            var dict = row.GetDictionary();
            var cell = dict.ContainsKey(property.Name.Pascalize()) ? dict[property.Name.Pascalize()] : "";
            if (cell is string && cell.ToString()?.Length > 2000)
            {
                cell = cell.ToString()?.Substring(0, 2000);
            }
            if (cell is bool)
                cell = ((dynamic)cell == true ? "✓" : "✗");
            return cell;
        }
    }
}
