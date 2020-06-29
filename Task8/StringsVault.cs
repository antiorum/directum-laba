namespace Task8
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Класс, перебирающий строки из файла.
    /// </summary>
    public class StringsVault : IEnumerable<string>
    {
        /// <summary>
        /// Внутренее хранилище строк.
        /// </summary>
        public List<string> Strings { get; }

        /// <summary>
        /// Считывает строки из файла во внутреннее хранилище.
        /// </summary>
        /// <param name="fileName">Путь к файлу.</param>
        public StringsVault(string fileName)
        {
            this.Strings = new List<string>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    this.Strings.Add(line);
                }
            }
        }

        /// <summary>
        /// Релизует метод интерфейса IEnumerable.
        /// </summary>
        /// <returns>Параметризованный энумератор строк.</returns>
        public IEnumerator<string> GetEnumerator()
        {
            return new StringVaultEnum(this.Strings);
        }

        /// <summary>
        /// Реализует метод интерфейса IEnumerable.
        /// </summary>
        /// <returns>Непараметризованный энумератор.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
