namespace Directum_laba.Task3
{
    /// <summary>
    /// Структура, определяющая координату, состоит из координаты Х и координаты У 
    /// </summary>
    public struct Coordinate // Не ошибка: Можно было использовать структуру Point. Я бы не придирался.
    {
        /// <summary>
        /// Контруктор, требующий задать обе координаты при создании
        /// </summary>
        /// <param name="x">Число с плавающей точкой, задающее Х</param>
        /// <param name="y">Число с плавающей точкой, задающее У</param>
        public Coordinate(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Свойство Х
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Свойство У
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Переопределние для оператора равенства (==)
        /// </summary>
        /// <param name="cor1">Коорданата 1</param>
        /// <param name="cor2">Координата 2</param>
        /// <returns>Результат сравнения</returns>
        public static bool operator ==(Coordinate cor1, Coordinate cor2) => cor1.X == cor2.X && cor1.Y == cor2.Y;

        /// <summary>
        /// Переопределние для оператора неравенства (!=)
        /// </summary>
        /// <param name="cor1">Коорданата 1</param>
        /// <param name="cor2">Коорданата 2</param>
        /// <returns>Результат сравнения</returns>
        public static bool operator !=(Coordinate cor1, Coordinate cor2) => cor1.X != cor2.X || cor1.Y != cor2.Y;

        /// <summary>
        /// Переопределение для equals
        /// </summary>
        /// <param name="obj">Сравниваемый с this объект</param>
        /// <returns>Результат сравнения в виде bool</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Coordinate))
            {
                return false;
            } 

            Coordinate toCompare = (Coordinate)obj;
            return this.X == toCompare.X && this.Y == toCompare.Y;
        }

        /// <summary>
        /// Переопределение для hashcode
        /// </summary>
        /// <returns>Целочисленное значение хэш-кода</returns>
        public override int GetHashCode()
        {
            return (this.X.GetHashCode() + this.Y.GetHashCode()) * 31;
        }

        /// <summary>
        /// Переопределение ToString для понятного вывода координат
        /// </summary>
        /// <returns>Строку с координатами</returns>
        public override string ToString()
        {
            return $"Coordinate (X:{this.X}, Y:{this.Y})";
        }
    }
}
