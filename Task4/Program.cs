namespace Task4
{
    using System;
    using System.Data;
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// Главный класс.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа в приложение.
        /// </summary>
        public static void Main()
        {
            // Проверяем работу классов-встреч.
            MeetingWithType meetingWithType = new MeetingWithType(MeetingType.Instruction);
            MeetingWithNoEnd meetingWithNoEnd = new MeetingWithNoEnd(DateTime.Now);
            Console.WriteLine(meetingWithType.Type);
            Console.WriteLine(meetingWithNoEnd.Duration);

            // Проверяем работу датасет в стринг.
            CheckForDataSetToString();

            // Проверяем работу печати прав
            AccessRightsUtil.PrintRights(AccessRights.Delete);
            AccessRightsUtil.PrintRights(AccessRights.AccessDenied);

            // Проверяем работу логгера.
            using (Logger logger = new Logger(@"D:/1.txt"))
            {
                logger.WriteString("666");
                logger.WriteString("Welcome to hell");
            }

            // Проверяем работу сравнения стринг и стринг-билдер.
            Program.StringAndStringBuilderCompare(100000, 10000000, 5000000);
        }

        /// <summary>
        /// Переводит датасет в строку.
        /// </summary>
        /// <param name="set">Дата сет.</param>
        /// <param name="tableSeparator">Разделитель таблиц.</param>
        /// <param name="rowSeparator">Разделитель строк таблицы.</param>
        /// <param name="recordSeparator">Разделитель записей в одной строке.</param>
        /// <returns>Датасет в виде строки.</returns>
        public static string DataSetToString(DataSet set, string tableSeparator, string rowSeparator, string recordSeparator)
        {
            StringBuilder result = new StringBuilder();

            foreach (DataTable table in set.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        result.Append(row[column]).Append(recordSeparator);
                    }

                    result.Append(rowSeparator);
                }

                result.Append(tableSeparator);
            }

            return result.ToString();
        }

        /// <summary>
        /// Сравнивает и печатает скорость работы классов String и StringBuilder.
        /// </summary>
        /// <param name="stringsToConcat">Количество строк, которые будут конкатенироватсья.</param>
        /// <param name="stringLength">Длина строки, из которой будет извлекаться подстрока.</param>
        /// <param name="substringLength">Длина подстроки.</param>
        public static void StringAndStringBuilderCompare(int stringsToConcat, int stringLength, int substringLength)
        {
            string[] stringsArray = new string[stringsToConcat];
            Array.Fill<string>(stringsArray, "a");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var s in stringsArray)
            {
                stringBuilder.Append(s);
            }

            stopwatch.Stop();
            Console.WriteLine($"Время работы StringBuilder по конкатенации {stringsToConcat} строк составило {stopwatch.ElapsedMilliseconds} миллисекунд.");

            stopwatch.Restart();
            string seed = string.Empty;
            foreach (var s in stringsArray)
            {
                seed += s;
            }

            stopwatch.Stop();
            Console.WriteLine($"Время работы String по конкатенации {stringsToConcat} строк составило {stopwatch.ElapsedMilliseconds} миллисекунд.");

            string from = new string('a', stringLength);

            stopwatch.Restart();
            new StringBuilder(from).ToString(0, substringLength);
            stopwatch.Stop();
            Console.WriteLine($"Время работы StringBuilder по получению подстроки длиной {substringLength} из строки длиной {stringLength} составило {stopwatch.ElapsedMilliseconds} миллисекунд.");

            stopwatch.Restart();
            from.Substring(0, substringLength);
            stopwatch.Stop();
            Console.WriteLine($"Время работы String по получению подстроки длиной {substringLength} из строки длиной {stringLength} составило {stopwatch.ElapsedMilliseconds} миллисекунд.");
        }

        /// <summary>
        /// Метод, в котором создается новый датасет с одной таблицей,
        /// и происходит печать с использованием метода <see cref="DataSetToString"/>
        /// </summary>
        /// <remarks>Нагло скопипастил с ментанита создание датасета</remarks>
        public static void CheckForDataSetToString()
        {
            DataSet bookStore = new DataSet("BookStore");
            DataTable booksTable = new DataTable("Books");

            // добавляем таблицу в dataset
            bookStore.Tables.Add(booksTable);

            // создаем столбцы для таблицы Books
            DataColumn idColumn = new DataColumn("Id", Type.GetType("System.Int32"));
            idColumn.Unique = true; // столбец будет иметь уникальное значение
            idColumn.AllowDBNull = false; // не может принимать null
            idColumn.AutoIncrement = true; // будет автоинкрементироваться
            idColumn.AutoIncrementSeed = 1; // начальное значение
            idColumn.AutoIncrementStep = 1; // приращении при добавлении новой строки

            DataColumn nameColumn = new DataColumn("Name", Type.GetType("System.String"));
            DataColumn priceColumn = new DataColumn("Price", Type.GetType("System.Decimal"));
            priceColumn.DefaultValue = 100; // значение по умолчанию
            DataColumn discountColumn = new DataColumn("Discount", Type.GetType("System.Decimal"));
            discountColumn.Expression = "Price * 0.2";

            booksTable.Columns.Add(idColumn);
            booksTable.Columns.Add(nameColumn);
            booksTable.Columns.Add(priceColumn);
            booksTable.Columns.Add(discountColumn);

            // определяем первичный ключ таблицы books
            booksTable.PrimaryKey = new DataColumn[] { booksTable.Columns["Id"] };

            DataRow row = booksTable.NewRow();
            row.ItemArray = new object[] { null, "Война и мир", 200 };
            booksTable.Rows.Add(row); // добавляем первую строку
            booksTable.Rows.Add(new object[] { null, "Отцы и дети", 170 }); // добавляем вторую строку
            Console.WriteLine(DataSetToString(bookStore, "***END OF TABLE*** \n", "\n----------------------\n", "|"));
        }
    }
}
