namespace Task11
{
    using System;
    using System.Collections.Generic;
    using Task8;

    /// <summary>
    /// Просто главный класс.
    /// </summary>
    internal class Program
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
    }
}
