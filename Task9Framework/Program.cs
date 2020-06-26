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
            // Загружает две версии одной библиотеки. Создает экземпляры классов и печатает свойства.
            // В .net core не работает.
            string currentWay = Directory.GetCurrentDirectory();
            CreateInstanceAndPrintProperties($@"{currentWay}\old version lib\TestLib.dll", "TestLib.TestClass");
            CreateInstanceAndPrintProperties($@"{currentWay}\new version lib\TestLib.dll", "TestLib.TestClass");

            // Проверяем чтение конфига.
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
            Assembly assembly = Assembly.LoadFile(assemblyWay);
            Type type = assembly.GetType(typeName);

            // Можно через активатор переделать.
            ConstructorInfo constructor = type.GetConstructors()[0];
            var instance = constructor.Invoke(new object[0]);
            PrintObjectProperties(instance);
        }
    }
}
