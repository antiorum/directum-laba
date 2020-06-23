namespace Task8
{
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
        private List<string> strings = new List<string>();

        /// <summary>
        /// Считывает строки из файла во внутреннее хранилище.
        /// </summary>
        /// <param name="fileName">Путь к файлу.</param>
        public StringsVault(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    this.strings.Add(line);
                }
            }
        }

        /// <summary>
        /// Релизует метод интерфейса IEnumerable.
        /// </summary>
        /// <returns>Параметризованный энумератор строк.</returns>
        public IEnumerator<string> GetEnumerator()
        {
            return new StringVaultEnum(this.strings);
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
