namespace Task5
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Класс комплексного числа.
    /// </summary>
    public class Complex : IComparable<Complex>
    {
        /// <summary>
        /// Внутренняя структура, которая реально хранит данные.
        /// </summary>
        private System.Numerics.Complex inner;

        /// <summary>
        /// Конструктор, создающий экземпляр комплексного числа.
        /// </summary>
        /// <param name="re">Реальная часть.</param>
        /// <param name="im">Мнимая часть.</param>
        public Complex(double re, double im)
        {
            this.inner = new System.Numerics.Complex(re, im);
        }

        /// <summary>
        /// Реальная часть.
        /// </summary>
        public double Re => this.inner.Real;

        /// <summary>
        /// Мнимая часть.
        /// </summary>
        public double Im => this.inner.Imaginary;

        /// <summary>
        /// Вычисляет абсолютное значение.
        /// </summary>
        public double Abs
        {
            get
            {
                return Math.Sqrt(Math.Pow(this.Re, 2) + Math.Pow(this.Im, 2));
            }
        }

        /// <summary>
        /// Сравнивает два комплексных числа по модулю
        /// </summary>
        /// <param name="other">Второе комплексное число для сравнения</param>
        /// <returns>Результат сравнения - целое число</returns>
        public int CompareTo([AllowNull] Complex other)
        {
            if (this.Abs < other.Abs)
            {
                return -1;
            }
            else if (this.Abs > other.Abs)
            {
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// Переопредление тоСтринг для красивого отображения.
        /// </summary>
        /// <returns>Комплексное число в виде строки</returns>
        public override string ToString()
        {
            return $"Complex number ({this.Re} + {this.Im}i)";
        }
    }
}
