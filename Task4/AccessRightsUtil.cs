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
        /// <returns>Строку с правами.</returns>
        public static string RightsToString(AccessRights rights)
        {
            if (rights == AccessRights.AccessDenied)
            {
                return AccessRights.AccessDenied.ToString();
            }

            return $"{rights-1}, {rights}";
        }
    }
}
