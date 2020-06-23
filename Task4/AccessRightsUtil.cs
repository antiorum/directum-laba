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

            byte k = (byte)rights;
            Console.WriteLine("{0:G}, {1:G}", (AccessRights)(k - 1), (AccessRights)k);
        }
    }
}
