namespace Task9Framework
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Reflection;
    using Task9Framewor;

    /// <summary>
    /// Просто главный класс.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа в приложение.
        /// </summary>
        public static void Main()
        {
            // Загружает две версии одной библиотеки. Создает экземпляры классов и печатает свойства.             // Лучше писать это в консоль. А то из консоли не понятно, что к чему относится.
            // В .net core не работает.
            string currentWay = Directory.GetCurrentDirectory();                                                  // Не требуется.
            CreateInstanceAndPrintProperties($@"{currentWay}\old version dll\TestLib.dll", "TestLib.TestClass");  // Посмотре что получается в bin/Debug/. Путь: "./old version dll/TestLib.dll".
            CreateInstanceAndPrintProperties($@"{currentWay}\new version dll\TestLib.dll", "TestLib.TestClass");  // Кстати, что-то при разговоре забыл упомянуть, что пробелы в названии это плохо.

            // Проверяем чтение конфига.                                                                          // Тоже в консоль.
            // Чтение общих свойств.
            ConfigReader configReader = new ConfigReader();
            Console.WriteLine(configReader.GetCommonParameterFromConfig("IntSetting"));
            Console.WriteLine(configReader.GetCommonParameterFromConfig("StrSetting"));

            // Чтение свойств из кастомной секции.
            ConfigReader.SettingsSection settingsSection = (ConfigReader.SettingsSection)ConfigurationManager
                .GetSection("ProgramSettings");
            ConfigurationElementCollection settings = settingsSection.SubSettings;
            foreach (ConfigurationElement element in settings)
            {
                foreach (PropertyInformation prop in element.ElementInformation.Properties)
                {
                    Console.WriteLine($"Свойство:{prop.Name} Значение:{prop.Value}");
                }
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Печатает reed-write свойства объекта, кроме устаревших.
        /// </summary>
        /// <param name="obj">Объект со свойствами.</param>
        public static void PrintObjectProperties(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                if (prop.GetCustomAttribute<ObsoleteAttribute>(true) == null && prop.CanRead && prop.CanWrite)
                {
                    Console.WriteLine($"Свойство: {prop.Name} | Значение: {prop.GetValue(obj)}");
                }
            }
        }

        /// <summary>
        /// Загружает сборку и печатает свойства класса из нее, не помеченные как устаревшие.
        /// </summary>
        /// <param name="assemblyWay">Полный путь к сборке.</param>
        /// <param name="typeName">Пространство имен и имя класс.</param>
        public static void CreateInstanceAndPrintProperties(string assemblyWay, string typeName)
        {
            Assembly assembly = Assembly.LoadFile(assemblyWay);   // Лучше писать в консоль версию сборки.
            Type type = assembly.GetType(typeName);

            // Можно через активатор переделать.
            ConstructorInfo constructor = type.GetConstructors()[0];
            var instance = constructor.Invoke(new object[0]); // Array.Empty<object>()
            PrintObjectProperties(instance);
        }
    }
}
