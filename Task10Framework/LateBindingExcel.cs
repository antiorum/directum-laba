namespace Task10Framework
{
    using System;

    /// <summary>
    /// Класс, демонстрирующий работу ком в сочетании с поздним связыванием.
    /// </summary>
    public class LateBindingExcel
    {
        /// <summary>
        /// Рисует таблицу умножения и сохраняет файл с ней по указанному пути.
        /// </summary>
        /// <param name="wayToEndFile">Расположение конечного файла.</param>
        public static void DrawMultiplyTable(string wayToEndFile)
        {
            dynamic excelApp = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));

            excelApp.DisplayAlerts = false;
            excelApp.Visible = true;
            excelApp.SheetsInNewWorkbook = 1;
            dynamic book = excelApp.Workbooks.Add(Type.Missing);

            dynamic worksheet = excelApp.Worksheets[1];
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

            dynamic valueRow = worksheet.Range("A1", "J1");
            dynamic valueColumn = worksheet.Range("A2", "A10");
            valueRow.Cells.Font.Bold = true;
            valueColumn.Cells.Font.Bold = true;

            dynamic allCells = worksheet.Range("A1", "J10");
            dynamic align = Type.GetType("Microsoft.Office.Interop.Excel.XlVAlign");
            dynamic center = align.GetField("xlVAlignCenter").GetValue(align);
            allCells.HorizontalAlignment = center;
            dynamic lineStyle = Type.GetType("Microsoft.Office.Interop.Excel.XlLineStyle");
            dynamic сontinuos = lineStyle.GetField("xlContinuous").GetValue(lineStyle);
            allCells.Borders.LineStyle = сontinuos;

            dynamic accessMode = Type.GetType("Microsoft.Office.Interop.Excel.XlSaveAsAccessMode");
            dynamic noChange = accessMode.GetField("xlNoChange").GetValue(accessMode);
            excelApp.Application.ActiveWorkbook.SaveAs(
                wayToEndFile, 
                Type.Missing,
                Type.Missing, 
                Type.Missing,
                Type.Missing, 
                Type.Missing,
                noChange,
                Type.Missing,
                Type.Missing,
                Type.Missing, 
                Type.Missing, 
                Type.Missing);

            excelApp.Quit();
        }
    }
}