namespace Task8
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Класс с точкой входа.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Статический конструктор, который инициализирует локализуемые строки.
        /// </summary>
        static Program()
        {
            XDocument document = new XDocument();

            // Раскомментировать, чтобы изменить язык на англ
            // CultureInfo.CurrentCulture = new CultureInfo("en");
            if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ru")
            {
                document = XDocument.Load(@".\ru.xml");
            }
            else if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en")
            {
                document = XDocument.Load(@".\en.xml");
            }

            E_CANT_CHANGE_PASSWORD_WITH_OS_AUTHENTIFICATION1 = document.Element("root").Elements("local_string")
                .Where((el) => el.Attribute("id").Value == "E_CANT_CHANGE_PASSWORD_WITH_OS_AUTHENTIFICATION")
                .Select(el => el.Value)
                .FirstOrDefault();
            DEBUGGER_MAIN_FORM_TRACE_INTO_ACTION_CAPTION = document.Element("root").Elements("local_string")
                .Where((el) => el.Attribute("id").Value == "DEBUGGER_MAIN_FORM_TRACE_INTO_ACTION_CAPTION")
                .Select(el => el.Value)
                .FirstOrDefault();
        }

        /// <summary>
        /// Строка, изменяющаяся в зависимости от локализации.
        /// </summary>
        public static string DEBUGGER_MAIN_FORM_TRACE_INTO_ACTION_CAPTION { get; }

        /// <summary>
        /// Строка, изменяющаяся в зависимости от локализации.
        /// </summary>
        public static string E_CANT_CHANGE_PASSWORD_WITH_OS_AUTHENTIFICATION1 { get; }

        /// <summary>
        /// Точка входа в приложение.
        /// </summary>
        public static void Main()
        {
            // Проверяем работу метода поиска максимума
            Console.WriteLine(GetMax(6, 4, 1));

            // Проверяем работу локализации
            Console.WriteLine(E_CANT_CHANGE_PASSWORD_WITH_OS_AUTHENTIFICATION1);
            Console.WriteLine(DEBUGGER_MAIN_FORM_TRACE_INTO_ACTION_CAPTION);

            // Проверяем работу класса для перебора строк файла
            StringsVault vault = new StringsVault(@".\text_sample.txt");
            foreach (string s in vault)
            {
                Console.WriteLine(s);
            }

            // Перебор generic-списка
            List<string> strings = new List<string> { "one", "two", "cow" };
            foreach (string s in strings)
            {
                Console.WriteLine(s);
            }

            // Перебор generic-словаря
            Dictionary<string, int> pairs = new Dictionary<string, int>();
            pairs.Add("one", 1);
            pairs.Add("two", 2);
            pairs.Add("cow", 100500);
            foreach (KeyValuePair<string, int> pair in pairs)
            {
                Console.WriteLine($"Ключ - {pair.Key}, значение - {pair.Value}");
            }
        }

        /// <summary>
        /// Вычисляет максимальный из трех элементов одного типа.
        /// </summary>
        /// <typeparam name="T">Тип должен реализовывать интерфейс IComparable.</typeparam>
        /// <param name="val1">Значение 1.</param>
        /// <param name="val2">Значение 2.</param>
        /// <param name="val3">Значение 3.</param>
        /// <returns>Элемент типа Т.</returns>
        public static T GetMax<T>(T val1, T val2, T val3) where T : IComparable<T>
        {
            List<T> values = new List<T> { val1, val2, val3 };
            values.OrderByDescending(el => el);
            return values[0];
        }
    }
}
