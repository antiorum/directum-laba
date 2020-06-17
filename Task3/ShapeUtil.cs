namespace Directum_laba.Task3
{
    using System;

    /// <summary>
    /// Класс, предоставляющий статические методы для работы с фигурами.
    /// </summary>
    public static class ShapeUtil
    {
        /// <summary>
        /// Метод для вычиcления длины отрезка по координатам его концов
        /// </summary>
        /// <param name="coord1">Координаты начала отрезка</param>
        /// <param name="coord2">Координаты конца отрезка</param>
        /// <returns>Длину ребра</returns>
        public static double GetEdgeLength(Coordinate coord1, Coordinate coord2)
        {
            return Math.Sqrt(Math.Pow(coord2.X - coord1.X, 2) + Math.Pow(coord2.Y - coord1.Y, 2));
        }

        /// <summary>
        /// Метод, вычисляющий координаты центра отрезка по координатам концов.
        /// </summary>
        /// <param name="cor1">Координаты начала отрезка</param>
        /// <param name="cor2">Координаты конца отрезка</param>
        /// <returns>Координаты середины.</returns>
        public static Coordinate SegmentCenter(Coordinate cor1, Coordinate cor2)
        {
            double centerX = (cor1.X + cor2.X) / 2;
            double centerY = (cor1.Y + cor2.Y) / 2;
            return new Coordinate(centerX, centerY);
        }
    }
}
