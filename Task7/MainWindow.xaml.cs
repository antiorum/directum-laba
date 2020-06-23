namespace Task7
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Создает главное окно. Добавляет обработчик события.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.Loaded += this.OnLoad;
        }

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

        /// <summary>
        /// Обработчик события загрузки главного окна.
        /// </summary>
        /// <param name="sender">Объект, инициализировавший событие.</param>
        /// <param name="routedEventArgs">Аргументы события.</param>
        private void OnLoad(object sender, RoutedEventArgs routedEventArgs)
        {
            FromGZipToRichTextBox(@".\q2.rtf.gz", this.PageBox);
        }
    }
}
