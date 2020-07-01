namespace Task7
{
    using System.Windows;

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
        /// Обработчик события загрузки главного окна.
        /// </summary>
        /// <param name="sender">Объект, инициализировавший событие.</param>
        /// <param name="routedEventArgs">Аргументы события.</param>
        private void OnLoad(object sender, RoutedEventArgs routedEventArgs)
        {
            Loader.FromGZipToRichTextBox(@".\q2.rtf.gz", this.PageBox);
        }
    }
}
