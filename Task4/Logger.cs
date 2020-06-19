namespace Task4
{
    using System;
    using System.IO;

    /// <summary>
    /// Класс логгер.
    /// </summary>
    public class Logger : IDisposable
    {
        /// <summary>
        /// Файл логов.
        /// </summary>
        private readonly FileStream logFile;

        /// <summary>
        /// Писатель в лог.
        /// </summary>
        private readonly StreamWriter logWriter;

        /// <summary>
        /// Создать объект.
        /// </summary>
        /// <param name="fileName">Имя файла логов.</param>
        public Logger(string fileName)
        {
            this.logFile = new FileStream(fileName, FileMode.Append);
            this.logWriter = new StreamWriter(this.logFile);
        }  

        /// <summary>
        /// Пишет строку в лог.
        /// </summary>
        /// <param name="data">Строка для записи</param>
        public void WriteString(string data)
        {
            this.logWriter.WriteLine(data);
        }

        /// <summary>
        /// Реализация интерфейса IDisposable
        /// </summary>
        public void Dispose()
        {
            this.logWriter.Flush();
            this.logWriter.Close();
            this.logFile.Close();
        }
    }
}
