namespace Task5
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Главный метод
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа в приложение
        /// </summary>
        public static void Main()
        {
            Console.WriteLine(new StringValue("AAA").Equals(new StringValue("AAA")));
            Console.WriteLine(new StringValue("AAA") == new StringValue("AAA"));

            var twoComplexes = new List<Complex>() { new Complex(3, 5), new Complex(2, 2) };
            twoComplexes.Sort();
            Console.WriteLine(twoComplexes[0].ToString() + ", " + twoComplexes[1].ToString());
        }
    }
}
