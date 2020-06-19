namespace Directum_laba.Task3
{
    using System.Collections.Generic;

    /// <summary>
    /// Класс, который определяет абстрактную фигуру
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Координаты центра фигуры
        /// </summary>
        private readonly Coordinate center;

        /// <summary>
        /// Коллекция вершин фигуры
        /// </summary>
        private readonly List<Coordinate> vertexes;

        /// <summary>
        /// Конструктор для семейства фигур с вершинами.
        /// </summary>
        /// <param name="vertexes">координаты вершин</param>
        protected Shape(List<Coordinate> vertexes)
        {
            this.vertexes = vertexes;
        }

        /// <summary>
        /// Контруктор для семейства фигур без вершин.
        /// </summary>
        /// <param name="center">Координаты центра</param>
        protected Shape(Coordinate center)
        {
            this.center = center;
        }

        /// <summary>
        /// Геттер для коллекции вершин
        /// </summary>
        public virtual List<Coordinate> Vertexes => this.vertexes;

        /// <summary>
        /// Геттер для координат центра
        /// </summary>
        public virtual Coordinate Center { get => this.center; }

        /// <summary>
        /// Вычисляет длину первой стороны, если количество вершин больше нуля.
        /// В ином случае возвращает 0.
        /// </summary>
        /// <returns>длину первой стороны, как ни странно.</returns>
        protected double FirstEdge()  
        {
            return this.GetLength(this.Vertexes[0], this.Vertexes[1]);
        }

        /// <summary>
        /// Вычисляет длину второй стороны, если количество вершин больше нуля.
        /// В ином случае возвращает 0.
        /// </summary>
        /// <returns>Длину второй стороны.</returns>
        protected double SecondEdge()
        {
            return this.GetLength(this.Vertexes[1], this.Vertexes[2]);
        }

        /// <summary>
        /// Вычисляет длину третьей стороны, если количество вершин больше нуля.
        /// В ином случае возвращает 0.
        /// </summary>
        /// <returns>Длину третьей стороны</returns>
        protected virtual double ThirdEdge()
        {
            return this.GetLength(this.Vertexes[2], this.Vertexes[0]);
        }

        /// <summary>
        /// Вычисляет длину отрезка по координатам, если количество вершин данной фигуры больше 0.
        /// В противном случае возвращает 0.
        /// </summary>
        /// <param name="cor1">Координаты начала отрезка</param>
        /// <param name="cor2">Координаты конца отрезка</param>
        /// <returns>длину отрезка</returns>
        private double GetLength(Coordinate cor1, Coordinate cor2) 
        {
            return this.Vertexes.Count > 0 ? ShapeUtil.GetEdgeLength(cor1, cor2) : 0;
        }
    }
}
