namespace Directum_laba.Task3
{
    using System;

    /// <summary>
    /// Класс для точки входа в приложение
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа в приложение
        /// </summary>
        public static void Main()
        {
            Coordinate center = new Coordinate(0.2, 0.3);
            Ring ring = new Ring(5, 4, center);
            Console.WriteLine(ring.Circumference);
            Console.WriteLine(ring.Area);

            Round round = new Round(5, center);
            Console.WriteLine(round.Area);

            Coordinate cor1 = new Coordinate(0, 0);
            Coordinate cor2 = new Coordinate(4, 4);
            Coordinate cor3 = new Coordinate(8, 0);
            Triangle triangle = new Triangle(cor1, cor2, cor3);
            Console.WriteLine(triangle.Perimeter);
            Console.WriteLine(triangle.Area);
            Console.WriteLine(triangle.Center);

            Coordinate cor4 = new Coordinate(0, 4);
            Coordinate cor5 = new Coordinate(4, 0);
            Square square = new Square(cor1, cor4, cor2, cor5);
            Console.WriteLine(square.Area);
            Console.WriteLine(square.Center);
        }
    }
}
