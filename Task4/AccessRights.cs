﻿namespace Task4
{
    using System;

    /// <summary>
    /// Тип прав
    /// </summary>
    [Flags, Serializable]
    public enum AccessRights : byte
    {
        /// <summary>
        /// Права на просмотр.
        /// </summary>
        View = 1,

        /// <summary>
        /// Права на запуск.
        /// </summary>
        Run = 2,

        /// <summary>
        /// Права на добавление.
        /// </summary>
        Add = 4,

        /// <summary>
        /// Права на изменение.
        /// </summary>
        Edit = 8,

        /// <summary>
        /// Права на утверждение.
        /// </summary>
        Ratify = 16,

        /// <summary>
        /// Права на удаление. 
        /// </summary>
        Delete = 32,

        /// <summary>
        /// Нет доступа.
        /// </summary>
        /// <remarks>
        /// Этот флаг имеет максимальный приоритет.
        /// Если он установлен, остальные флаги игнорируются 
        /// </remarks>
        AccessDenied = 64
    }

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
            byte k = (byte)rights;
            if (k == 64)
            {
                Console.WriteLine(AccessRights.AccessDenied);
                return;
            }

            Console.WriteLine("{0:G}, {1:G}", (AccessRights)(k - 1), (AccessRights)k);
        }
    }
}
