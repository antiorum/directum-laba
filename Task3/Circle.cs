namespace Directum_laba.Task3
{
    using System;

    /// <summary>
    /// Класс фигуры "Окружность"
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Конструктор класса, принимющий в качестве аргументов координаты центра и радиус.
        /// </summary>
        /// <param name="radius">Радиус в виде числа с плавающей точкой</param>
        /// <param name="center">Координаты центра</param>
        public Circle(double radius, Coordinate center) : base(center)
        {
            this.Radius = radius;
        }

        /// <summary>
        /// Геттер для радиуса окружности
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// Геттер для длины окружности
        /// </summary>
        public double Circumference
        {
            get { return this.Radius * 2 * Math.PI; }
        }
    }
}
