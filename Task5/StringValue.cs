namespace Task5
{
    using System;

    /// <summary>
    /// Класс, хранящий значение строки.
    /// </summary>
    public class StringValue
    {
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="value">Значение строки</param>
        public StringValue(string value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Значение строки.
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Переопределение оператора ==
        /// </summary>
        /// <param name="val1">Первый объект для сравнения</param>
        /// <param name="val2">Второй объект для сравнения</param>
        /// <returns>Булево значение равенства</returns>
        public static bool operator ==(StringValue val1, StringValue val2) => val1.Value == val2.Value;

        /// <summary>
        /// Переопределение оператора !=
        /// </summary>
        /// <param name="val1">Первый объект для сравнения</param>
        /// <param name="val2">Второй объект для сравнения</param>
        /// <returns>Булево значение неравенства</returns> 
        public static bool operator !=(StringValue val1, StringValue val2) => val1.Value != val2.Value;

        /// <summary>
        /// Переопределение для эквивалентности экземпляров класса.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Значение в формате bool.</returns>
        public override bool Equals(object obj)
        {
            return obj is StringValue value && this.Value == value.Value;
        }

        /// <summary>
        /// Переопределение для хэш-кода.
        /// </summary>
        /// <returns>Целочисленный хэш.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Value);
        }
    }
}
