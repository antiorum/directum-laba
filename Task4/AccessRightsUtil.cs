namespace Task4
{
    using System;

    /// <summary>
    /// Класс, содержащий утилитные методы для прав
    /// </summary>
    public static class AccessRightsUtil
    {
        /// <summary>
        /// Печатает права пользователя.
        /// </summary>
        /// <param name="rights">Права пользователя</param>
        public static void PrintRights(AccessRights rights)
        {
            if (rights == AccessRights.AccessDenied)
            {
                Console.WriteLine(AccessRights.AccessDenied);
                return;
            }

            Console.WriteLine("{0:G}, {1:G}", rights - 1, rights);
        }
    }
}
