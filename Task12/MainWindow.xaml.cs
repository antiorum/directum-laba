namespace Task12
{
    using System;
    using System.Globalization;
    using System.Reflection;
    using System.Resources;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Конструктор главного окна.
        /// </summary>
        public MainWindow()
        {
            this.Initialized += this.MainWindow_Initialized;
            this.InitializeComponent();
            hello.Click += this.OnClick;    // Указать обработчик лучше было в xaml. (Можно просто дважды кликнуть на кнопку и создастся обработчик.)
        }

        /// <summary>
        /// Обработчик события инициализации главного окна.
        /// </summary>
        /// <param name="sender">Объект, приславший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void MainWindow_Initialized(object sender, EventArgs e)
        {
            var resMan = new ResourceManager("Task12.TextMessages", Assembly.GetExecutingAssembly());
            MessageBox.Show(resMan.GetString("HelloMessage", new CultureInfo("en")));
        }

        /// <summary>
        /// Обработчик нажатия кнопки.
        /// </summary>
        /// <param name="sender">Объект, приславший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(TextMessages.HelloMessage);
        }
    }
}
