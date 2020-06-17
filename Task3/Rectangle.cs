namespace Directum_laba.Task3
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Класс фигуры "Прямоугольник"
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Конструктор с небольшой валидацией, принимающий в качестве агрументов координаты вершин.
        /// </summary>
        /// <param name="firstVertex">Координаты первой вершины</param>
        /// <param name="secondVertex">Координаты второй вершины</param>
        /// <param name="thirdVertex">Координаты третьей вершины</param>
        /// <param name="fourthVertex">Координаты четвертой вершины</param>
        public Rectangle(Coordinate firstVertex, Coordinate secondVertex, Coordinate thirdVertex, Coordinate fourthVertex)
            : base(new List<Coordinate> { firstVertex, secondVertex, thirdVertex, fourthVertex })
        {
            double diagonalOne = ShapeUtil.GetEdgeLength(Vertexes[0], Vertexes[2]);
            double diagonalTwo = ShapeUtil.GetEdgeLength(Vertexes[1], Vertexes[3]);
            if (diagonalOne != diagonalTwo)
            {
                throw new ArgumentException("Введенные координаты не соответствуют прямоугольнику");
            }
        }

        /// <summary>
        /// Геттер для координат центра
        /// </summary>
        public override Coordinate Center
        {
            get
            {
                return ShapeUtil.SegmentCenter(this.Vertexes[0], this.Vertexes[2]);
            }
        }

        /// <summary>
        /// Вычисляет периметр прямоугольника
        /// </summary>
        public double Perimeter
        {
            get
            {
                return (this.FirstEdge() + this.SecondEdge()) * 2;
            }
        }

        /// <summary>
        /// Вычисляет площадь прямоугольника
        /// </summary>
        public double Area
        {
            get
            {
                return this.FirstEdge() * this.SecondEdge();
            }
        }

        /// <summary>
        /// Переопределение для вычисления длины третьего ребра. 
        /// Не используется, но может привести к ошибкам, если будут добавлены новые методы.
        /// </summary>
        /// <returns>Длину третьего ребра</returns>
        protected override double ThirdEdge()
        {
            return ShapeUtil.GetEdgeLength(this.Vertexes[2], this.Vertexes[3]);
        }

        /// <summary>
        /// Вычисляет длину четвертого ребра прямоугольника
        /// </summary>
        /// <returns>Длину четвертого ребра</returns>
        protected double FourthEdge()
        {
            return ShapeUtil.GetEdgeLength(this.Vertexes[3], this.Vertexes[0]);
        }
    }
}
