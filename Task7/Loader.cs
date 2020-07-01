namespace Task7
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;

    /// <summary>
    /// Класс, содержащий методы для загрузки в UI.
    /// </summary>
    public class Loader
    {
        /// <summary>
        /// Добавляет информацию из текстового файла в формате ртф, упакованного в gzip, в richTextBox.
        /// </summary>
        /// <param name="fileName">Путь к архиву.</param>
        /// <param name="textBox">RichTextBox для добавления текста.</param>
        public static void FromGZipToRichTextBox(string fileName, RichTextBox textBox)
        {
            try
            {
                using (FileStream reader = new FileStream(fileName, FileMode.Open))
                using (GZipStream decompressionStream = new GZipStream(reader, CompressionMode.Decompress))
                using (MemoryStream inMemory = new MemoryStream())
                {
                    decompressionStream.CopyTo(inMemory);
                    TextRange doc = new TextRange(textBox.Document.ContentStart, textBox.Document.ContentEnd);
                    doc.Load(inMemory, DataFormats.Rtf);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new LoadFileException(ex.Message, ex);
            }
            catch (FileNotFoundException ex)
            {
                throw new LoadFileException(ex.Message, ex);
            }
        }
    }
}
