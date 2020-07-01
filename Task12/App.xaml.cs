namespace Task12
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Установить текущую культуру.
        /// </summary>
        static App()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture =
              new System.Globalization.CultureInfo("ru");
        }
    }
}
