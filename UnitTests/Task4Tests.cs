namespace UnitTests
{
    using System;
    using System.Data;
    using System.IO;
    using NUnit.Framework;
    using Task4;

    /// <summary>
    /// Тесты проекта Task4.
    /// </summary>
    public class Task4Tests
    {
        /// <summary>
        /// Тестирует создание встречи с типом.
        /// </summary>
        [Test]
        public void CreatedMeetingWithTypeReturnsSameType()
        {
            MeetingWithType meetingWithType = new MeetingWithType(MeetingWithType.MeetingType.Instruction);
            Assert.AreEqual(meetingWithType.Type, MeetingWithType.MeetingType.Instruction);
        }

        /// <summary>
        /// Тестириует создание встречи без даты окончания.
        /// </summary>
        [Test]
        public void CreatedMeetingWithNoEndReturnsMaxSpan()
        {
            MeetingWithNoEnd meetingWithNoEnd = new MeetingWithNoEnd(DateTime.Now);
            Assert.AreEqual(TimeSpan.MaxValue, meetingWithNoEnd.Duration);
        }

        /// <summary>
        /// Тестирует корректность перевода дата-сета в строку.
        /// </summary>
        [Test]
        public void DataSetToStringReturnsRigthString()
        {
            DataSet bookStore = new DataSet("BookStore");
            DataTable booksTable = new DataTable("Books");

            bookStore.Tables.Add(booksTable);

            DataColumn idColumn = new DataColumn("Id", Type.GetType("System.Int32"));
            idColumn.Unique = true; 
            idColumn.AllowDBNull = false; 
            idColumn.AutoIncrement = true; 
            idColumn.AutoIncrementSeed = 1; 
            idColumn.AutoIncrementStep = 1;

            DataColumn nameColumn = new DataColumn("Name", Type.GetType("System.String"));
            DataColumn priceColumn = new DataColumn("Price", Type.GetType("System.Decimal"));
            priceColumn.DefaultValue = 100;

            booksTable.Columns.Add(idColumn);
            booksTable.Columns.Add(nameColumn);
            booksTable.Columns.Add(priceColumn);

            booksTable.PrimaryKey = new DataColumn[] { booksTable.Columns["Id"] };

            DataRow row = booksTable.NewRow();
            row.ItemArray = new object[] { null, "Война и мир", 200 };
            booksTable.Rows.Add(row);

            string expected = "1|Война и мир|200|\n\n";
            Assert.AreEqual(expected, Program.DataSetToString(bookStore, "\n", "\n", "|"));
        }

        /// <summary>
        /// Тестирует корректность возвращаемой строки с правами доступа,
        /// в случае когда досутуп разрешен.
        /// </summary>
        [Test]
        public void AccessRightsRunToStringReturnsRunAndView()
        {
            AccessRights run = AccessRights.Run;
            string expected = "View, Run";
            Assert.AreEqual(expected, AccessRightsUtil.RightsToString(run));
        }

        /// <summary>
        /// Тестирует корректность возвращаемой строки с правами доступа,
        /// в случае когда досутуп запрещен.
        /// </summary>
        [Test]
        public void AccessRightsDenidedToStringReturnsAccessDenided()
        {
            AccessRights denided = AccessRights.AccessDenied;
            Assert.AreEqual("AccessDenied", AccessRightsUtil.RightsToString(denided));
        }

        /// <summary>
        /// Тестриует запись строки в лог.
        /// </summary>
        [Test]
        public void LoggerWriteToLogMustContainRightString()
        {
            string expected = "Test string";
            using (Logger logger = new Logger(@".\log.txt"))
            {
                logger.WriteString(expected);
            }

            string actual;
            using (StreamReader reader = new StreamReader(@".\log.txt"))
            {
                actual = reader.ReadLine();
            }

            Assert.AreEqual(expected, actual);
            File.Delete(@".\log.txt");
        }

        /// <summary>
        /// Тестирует сравнение времени работы String и StringBuilder по конкатенации строк.
        /// </summary>
        [Test]
        public void CompareStringAndStringBuilderTimeConcatMustBeGreater()
        {
            string[] stringsArray = new string[10000];
            Array.Fill<string>(stringsArray, "a");

            long stringConcatTime = Program.GetTimeConcat(Program.StringConcat, stringsArray);
            long stringBuilderConcatTime = Program.GetTimeConcat(Program.StringBuilderConcat, stringsArray);

            Assert.Greater(stringConcatTime, stringBuilderConcatTime);
        }
    }
}