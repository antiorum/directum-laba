namespace Task7
{
    using System;
    using System.IO;

    /// <summary>
    /// Исключение при загрузке файла.
    /// </summary>
    public class LoadFileException : IOException
    {
        /// <summary>
        /// Создает экземпляр исключения.
        /// </summary>
        /// <param name="message">Сообщение из оригинального исключения.</param>
        /// <param name="innerException">Оригинальное исключение.</param>
        public LoadFileException(string message, Exception innerException) : base(message, innerException)
        {        
        }
    }
}
