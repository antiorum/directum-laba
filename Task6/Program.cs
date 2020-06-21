namespace Task6
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Класс для точки входа
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа
        /// </summary>
        public static void Main()
        {
            // Убеждаемся, что без переопределения тоСтринг не обойтись
            SomeClass instance = new SomeClass(1, "kek");
            Console.WriteLine(instance.ToString());

            // Проверяем работу метода, подсчитывающего количество событий
            DateTime begin = new DateTime(2007, 12, 17);
            DateTime end = new DateTime(2007, 12, 17);
            var count = GetEventCountFromLog(@"D:\examples\Logs\ClientConnectionLog.log", begin, end);
            Console.WriteLine(count);
        }

        /// <summary>
        /// Метод, который высчитывает количество записей из лога между двумя датами (включительно).
        /// </summary>
        /// <param name="log">Путь к файлу-логу.</param>
        /// <param name="begin">Дата начала.</param>
        /// <param name="end">Дата конца.</param>
        /// <returns>Целочисленное количество событий.</returns>
        public static int GetEventCountFromLog(string log, DateTime begin, DateTime end)
        {
            int count = 0;
            Regex dateRegex = new Regex(@"\A\d{2}\.\d{2}\.\d{4}");
            string format = "dd.MM.yyyy";

            using (StreamReader reader = new StreamReader(log))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (dateRegex.Match(line).Success)
                    {
                        DateTime date = DateTime.ParseExact(dateRegex.Match(line).Value, format, null);
                        if (date >= begin && date <= end)
                        {
                            count++;
                        } 
                    } 
                }
            }

            return count;
        }
    }    
}
