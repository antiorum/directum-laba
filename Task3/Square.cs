namespace Directum_laba.Task3
{
    using System;

    /// <summary>
    /// Класс фигуры "Квадрат"
    /// </summary>
    public class Square : Rectangle
    {
        /// <summary>
        /// Конструктор с валидацией, для создания нового квадрата
        /// </summary>
        /// <param name="firstVertex">Координаты первой вершины</param>
        /// <param name="secondVertex">Координаты второй вершины</param>
        /// <param name="thirdVertex">Координаты третьей вершины</param>
        /// <param name="fourthVertex">координаты четвертой вершины</param>
        public Square(Coordinate firstVertex, Coordinate secondVertex, Coordinate thirdVertex, Coordinate fourthVertex)
            : base(firstVertex, secondVertex, thirdVertex, fourthVertex)
        {
            if (this.FirstEdge() != this.SecondEdge() ||
                this.FirstEdge() != this.ThirdEdge() ||
                this.FirstEdge() != this.FourthEdge())
            {
                throw new ArgumentException("Введенные координаты не соответствуют квадрату");
            }     
        }
    }
}
