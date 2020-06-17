namespace Directum_laba.Task3
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Класс, определяющий фигуру "Треугольник"
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// Конструктор с валидацией, принимает координаты вершин в качестве аргументов.
        /// </summary>
        /// <param name="firstVertex">Координаты первой вершины.</param>
        /// <param name="secondVertex">Координаты второй вершины.</param>
        /// <param name="thirdVertex">Координаты третьей вершины.</param>
        public Triangle(Coordinate firstVertex, Coordinate secondVertex, Coordinate thirdVertex)
            : base(new List<Coordinate> { firstVertex, secondVertex, thirdVertex })
        {
            if ((this.FirstEdge() + this.SecondEdge() < this.ThirdEdge())
                || (this.FirstEdge() + this.ThirdEdge() < this.SecondEdge())
                || (this.SecondEdge() + this.ThirdEdge() < this.FirstEdge()))
            {
                throw new ArgumentException("Невозможно построить треугольник из введенных координат");
            }
        }

        /// <summary>
        /// Вычисляет координаты центра треугольника
        /// </summary>
        public override Coordinate Center 
        {
            get
            {
                double centerX = (this.Vertexes[0].X + this.Vertexes[1].X + this.Vertexes[2].X) / 3;
                double centerY = (this.Vertexes[0].Y + this.Vertexes[1].Y + this.Vertexes[2].Y) / 3;
                return new Coordinate(centerX, centerY);
            }
        }

        /// <summary>
        /// Вычисляет периметр треугольника
        /// </summary>
        public double Perimeter
        {
            get
            {
                return this.FirstEdge() + this.SecondEdge() + this.ThirdEdge();
            }
        }

        /// <summary>
        /// Вычисляет площадь треугольника
        /// </summary>
        public double Area
        {
            get
            {
                double halfPerim = this.Perimeter / 2;
                return Math.Sqrt(halfPerim * (halfPerim - this.FirstEdge()) * (halfPerim - this.SecondEdge()) * (halfPerim - this.ThirdEdge()));
            }
        }
    }
}
