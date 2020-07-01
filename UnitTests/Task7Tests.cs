namespace UnitTests
{
    using System.Threading;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using NUnit.Framework;
    using Task7;

    /// <summary>
    /// Тесты проекта Task7.
    /// </summary>
    public class Task7Tests
    {
        /// <summary>
        /// Тестирует правильность загрузки данных из gzip в richtextbox.
        /// </summary>
        /// <remarks>
        /// Вынес в отдельный класс - все равно ексепшен вылетает, если в отдельный поток не обернуть.
        /// </remarks>
        [Test]
        public void FromGZipAndWriteToRichTextBoxMustContainSameString()
        {
            Thread thread = new Thread(() =>
            {
                RichTextBox box = new RichTextBox();
                Loader.FromGZipToRichTextBox(@".\test.rtf.gz", box);
                string expected = "Test string";
                string actual = new TextRange(box.Document.ContentStart, box.Document.ContentEnd).Text;
                Assert.AreEqual(expected, actual);
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}
