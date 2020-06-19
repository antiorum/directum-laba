namespace Task6
{
    /// <summary>
    /// Просто класс, чтобы убедиться, что надо переопределить toString
    /// </summary>
    public class SomeClass
    {
        /// <summary>
        /// Просто конструктор
        /// </summary>
        /// <param name="myProperty1">Числовой параметр</param>
        /// <param name="name">Строковый параметр</param>
        public SomeClass(int myProperty1, string name)
        {
            this.MyProperty1 = myProperty1;
            this.Name = name;
        }

        /// <summary>
        /// Числовое свойство
        /// </summary>
        public int MyProperty1 { get; set; }

        /// <summary>
        /// Строковое свойство
        /// </summary>
        public string Name { get; set; }
    }
}
