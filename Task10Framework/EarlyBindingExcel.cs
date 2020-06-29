namespace Task10Framework
{
    using System;
    using System.IO;
    using Microsoft.Office.Interop.Excel;
    using Range = Microsoft.Office.Interop.Excel.Range;

    /// <summary>
    /// Класс, демонстрирующий работу ком в сочетании с ранним связыванием
    /// </summary>
    public class EarlyBindingExcel
    {
        /// <summary>
        /// Рисует таблицу умножения и сохраняет файл с ней по указанному пути.
        /// </summary>
        /// <param name="wayToEndFile">Расположение конечного файла.</param>
        public static void DrawMultiplyTable(string wayToEndFile)
        {
            var excelApp = new Application();
            excelApp.DisplayAlerts = false;
            excelApp.Visible = true;
            excelApp.SheetsInNewWorkbook = 1;
            excelApp.Workbooks.Add(Type.Missing);

            Worksheet worksheet = excelApp.Worksheets[1];
            worksheet.Name = "Таблица умножения";

            for (int i = 2; i <= 10; i++)
            {
                worksheet.Cells[i, 1] = i - 1;
                worksheet.Cells[1, i] = i - 1;
                for (int j = 2; j <= 10; j++)
                {
                    worksheet.Cells[i, j] = (i - 1) * (j - 1);
                }
            }

            Range valueRow = worksheet.get_Range("A1", "J1");
            Range valueColumn = worksheet.get_Range("A2", "A10");
            valueRow.Cells.Font.Bold = true;
            valueColumn.Cells.Font.Bold = true;

            Range allCells = worksheet.get_Range("A1", "J10");
            allCells.HorizontalAlignment = XlVAlign.xlVAlignCenter;
            allCells.Borders.LineStyle = XlLineStyle.xlContinuous;

            excelApp.Application.ActiveWorkbook.SaveAs(
                wayToEndFile,
                Type.Missing,
                Type.Missing,
                Type.Missing, 
                Type.Missing,
                Type.Missing,
                XlSaveAsAccessMode.xlNoChange,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing,
                Type.Missing);
        }
    }
}
