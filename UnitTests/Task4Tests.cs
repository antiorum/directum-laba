namespace UnitTests
{
    using System;
    using System.Data;
    using System.IO;
    using NUnit.Framework;
    using Task4;

    /// <summary>
    /// ����� ������� Task4.
    /// </summary>
    public class Task4Tests
    {
        /// <summary>
        /// ��������� �������� ������� � �����.
        /// </summary>
        [Test]
        public void CreatedMeetingWithTypeReturnsSameType()
        {
            MeetingWithType meetingWithType = new MeetingWithType(MeetingWithType.MeetingType.Instruction);
            Assert.AreEqual(meetingWithType.Type, MeetingWithType.MeetingType.Instruction);
        }

        /// <summary>
        /// ���������� �������� ������� ��� ���� ���������.
        /// </summary>
        [Test]
        public void CreatedMeetingWithNoEndReturnsMaxSpan()
        {
            MeetingWithNoEnd meetingWithNoEnd = new MeetingWithNoEnd(DateTime.Now);
            Assert.AreEqual(TimeSpan.MaxValue, meetingWithNoEnd.Duration);
        }

        /// <summary>
        /// ��������� ������������ �������� ����-���� � ������.
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
            row.ItemArray = new object[] { null, "����� � ���", 200 };
            booksTable.Rows.Add(row);

            string expected = "1|����� � ���|200|\n\n";
            Assert.AreEqual(expected, Program.DataSetToString(bookStore, "\n", "\n", "|"));
        }

        /// <summary>
        /// ��������� ������������ ������������ ������ � ������� �������,
        /// � ������ ����� ������� ��������.
        /// </summary>
        [Test]
        public void AccessRightsRunToStringReturnsRunAndView()
        {
            AccessRights run = AccessRights.Run;
            string expected = "View, Run";
            Assert.AreEqual(expected, AccessRightsUtil.RightsToString(run));
        }

        /// <summary>
        /// ��������� ������������ ������������ ������ � ������� �������,
        /// � ������ ����� ������� ��������.
        /// </summary>
        [Test]
        public void AccessRightsDenidedToStringReturnsAccessDenided()
        {
            AccessRights denided = AccessRights.AccessDenied;
            Assert.AreEqual("AccessDenied", AccessRightsUtil.RightsToString(denided));
        }

        /// <summary>
        /// ��������� ������ ������ � ���.
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
        /// ��������� ��������� ������� ������ String � StringBuilder �� ������������ �����.
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