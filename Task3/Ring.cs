namespace Directum_laba.Task3
{
    using System;

    /// <summary>
    /// Класс, определяющий фигуру "Кольцо"
    /// </summary>
    public class Ring : Circle
    {
        /// <summary>
        /// Конструктор класса с валидацией,
        /// принимающий координаты центра и радиусы внтрунней и внешней окружностей в качестве параметров.
        /// </summary>
        /// <param name="radius">Внешний радиус кольца</param>
        /// <param name="innerRadius">Внутрений радиус кольца</param>
        /// <param name="center">Координаты центра</param>
        public Ring(double radius, double innerRadius, Coordinate center) : base(radius, center)
        {
            if (radius < innerRadius)
            {
                throw new ArgumentException("Внутренний радиус не может быть больше внешнего!");
            }

            this.InnerRadius = innerRadius;
        }

        /// <summary>
        /// Геттер для внутреннего радиуса
        /// </summary>
        public double InnerRadius { get; }

        /// <summary>
        /// Вычисляет окружность внутренней окружности
        /// </summary>
        public double InnerCircumference
        {
            get { return 2 * Math.PI * this.InnerRadius; }
        }

        /// <summary>
        /// Вычисляет площадь
        /// </summary>
        public double Area
        {
            get
            {
                double innerArea = Math.PI * Math.Pow(this.InnerRadius, 2);
                double outherArea = Math.PI * Math.Pow(this.Radius, 2);
                return outherArea - innerArea;
            }
        }
    }
}
