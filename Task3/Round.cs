namespace Directum_laba.Task3
{
    /// <summary>
    /// Класс, определяющий фигуру "Круг"
    /// </summary>
    public class Round : Ring
    {
        /// <summary>
        /// Конструктор, инстанцирует новый круг. Принимает в качестве аргументов радиус и координаты центра
        /// </summary>
        /// <param name="radius">Радиус круга</param>
        /// <param name="center">Координаты центра круга</param>
        public Round(double radius, Coordinate center) : base(radius, 0, center)
        {
        }
    }
}
