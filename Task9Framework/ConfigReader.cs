namespace Task9Framewor
{
    using System;
    using System.Configuration;

    /// <summary>
    /// Класс для чтения конфигурации.
    /// </summary>
    public class ConfigReader
    {
        /// <summary>
        /// Позволяет считывать свойство из секции appSettings.
        /// </summary>
        /// <param name="parameterName">Имя свойства.</param>
        /// <returns>Значение свойства в виде строки.</returns>
        public string GetCommonParameterFromConfig(string parameterName)
        {
            string[] potentialValues = ConfigurationManager.AppSettings.GetValues(parameterName);
            return (potentialValues != null
                && potentialValues.Length > 0
                && !string.IsNullOrEmpty(potentialValues[0]))
                ? potentialValues[0] : string.Empty;
        }

        /// <summary>
        /// Коллекция элементов конфигурации
        /// </summary>
        [ConfigurationCollection(typeof(SubSettingSection), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
        public class SubSettingCollection : ConfigurationElementCollection
        {
            /// <summary>
            /// Создает элемент конфигурации.
            /// </summary>
            /// <returns>Созданный элемент.</returns>
            protected override ConfigurationElement CreateNewElement()
            {
                return new SubSettingSection();
            }

            /// <summary>
            /// Возвращает ключ элемента.
            /// </summary>
            /// <param name="element">Элемент для получения ключа.</param>
            /// <returns>Объект ключ.</returns>
            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((SubSettingSection)element).SubSetting;
            }
        }

        /// <summary>
        /// Секция из конфигурации.
        /// </summary>
        public class SettingsSection : ConfigurationSection
        {
            /// <summary>
            /// Возвращает коллекцию конфигурционных элементов.
            /// </summary>
            [ConfigurationProperty("", IsDefaultCollection = true, IsRequired = true)]
            public SubSettingCollection SubSettings
            {
                get { return (SubSettingCollection)this[string.Empty]; }
            }          
        }

        /// <summary>
        /// Элемент конфигурации.
        /// </summary>
        internal class SubSettingSection : ConfigurationElement
        {
            /// <summary>
            /// Ключ элемента.
            /// </summary>
            [ConfigurationProperty("SubSetting", IsRequired = true, IsKey = true)]
            public string SubSetting
            {
                get { return (string)this["SubSetting"]; }
            }

            /// <summary>
            /// Значение элемента.
            /// </summary>
            [ConfigurationProperty("SubSettingValue", IsRequired = true)]
            public string SubSettingValue
            {
                get { return (string)this["SubSettingValue"]; }
            }
        }
    }
}
