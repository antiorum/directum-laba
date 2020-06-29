namespace Task11
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
            // Класс из Таsк8. Метод дописал в него.
            StringsVault vault = new StringsVault("ClientConnectionLog.log");
            List<string> filtred = vault.GetFiltredAndOrdredStrings(new DateTime(2007, 12, 11));
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
                .Where(line => line.StartsWith($"{date.Day}.{date.Month}.{date.Year}"))
                .OrderBy(line => line)
                .ToList();
        }
    }
}
