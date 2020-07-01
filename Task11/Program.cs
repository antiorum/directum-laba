namespace Task11
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Task8;

    /// <summary>
    /// Просто главный класс.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        internal static void Main()
        {
            StringsVault vault = new StringsVault("ClientConnectionLog.log");
            List<string> filtred = vault.GetFiltredAndOrdredStrings(new DateTime(2008, 01, 22));
            foreach (string s in filtred)
            {
                Console.WriteLine(s);
            }
        }

        /// <summary>
        /// Метод расширения для класса <see cref="StringsVault"/>.
        /// Фильтрует строки по дате и сортирует по времени.
        /// </summary>
        /// <param name="vault">Экземпляр класса, к которому применяется расширяющий метод.</param>
        /// <param name="date">Дата для нахождения записей.</param>
        /// <returns>Список строк.</returns>
        internal static List<string> GetFiltredAndOrdredStrings(this StringsVault vault, DateTime date)
        {
            return vault.Strings
                .Where(line => line.StartsWith($"{date:dd.MM.yyyy}"))
                .OrderBy(line => GetTime(line))
                .ToList();
        }

        /// <summary>
        /// Получает текущую дату, но время берется из параметра.
        /// </summary>
        /// <param name="source">Строка, содержащая время.</param>
        /// <returns>Дату с временем.</returns>
        internal static DateTime GetTime(string source)
        {
            Regex time = new Regex(@"\d?\d{1}:\d{2}:\d{2}");
            string format = "H:mm:ss";

            return DateTime.ParseExact(time.Match(source).Value, format, null);
        }
    }
}
