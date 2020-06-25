namespace Task10Framework
{
    using System.IO;

    /// <summary>
    /// Просто главный класс.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа в приложение.
        /// </summary>
        public static void Main()
        {
            // Рисуем две таблицы умножения. Будут сохранены в бин/дебаг.
            EarlyBindingExcel.DrawMultiplyTable(Directory.GetCurrentDirectory() + @"\multiply_table_early.xlsx");
            LateBindingExcel.DrawMultiplyTable(Directory.GetCurrentDirectory() + @"\multiply_table_late.xlsx");
        }
    }
}
