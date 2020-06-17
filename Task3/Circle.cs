namespace Directum_laba.Task3
{
    using System;

    /// <summary>
    /// Класс фигуры "Окружность"
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Конструктор класса, принимющий в качестве аргументов координаты центра и радиус.    // Не ошибка: Не надо заставлять себя писать длинные комментарии.
        /// </summary>                                                                          // Входные параметры и так описаны ниже.
        /// <param name="radius">Радиус в виде числа с плавающей точкой</param>                 // Я бы не придирался, даже если бы было просто написано "Конструктор".
        /// <param name="center">Координаты центра</param>
        public Circle(double radius, Coordinate center) : base(center)
        {
            this.Radius = radius;
        }

        /// <summary>
        /// Геттер для радиуса окружности   // Тут можешь не править, но на будущее: Можно написать просто "Радиус".
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
