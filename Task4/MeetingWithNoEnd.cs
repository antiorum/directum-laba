namespace Task4
{
    using System;
    using Directum_laba;

    /// <summary>
    /// Класс-встреча, который может не иметь времени конца встречи
    /// </summary>
    public class MeetingWithNoEnd : Meeting
    {
        /// <summary>
        /// Конструктор, когда время конца встречи не известно.
        /// </summary>
        /// <param name="begin">Время начала.</param>
        public MeetingWithNoEnd(DateTime begin)
        {
            this.BeginTime = begin;
            this.EndTime = DateTime.MaxValue;
        }

        /// <summary>
        /// Конструктор, когда время конца встречи известно
        /// </summary>
        /// <param name="begin">Время начала.</param>
        /// <param name="end">Время конца.</param>
        public MeetingWithNoEnd(DateTime begin, DateTime end)
        {
            this.BeginTime = begin;
            this.EndTime = end;
        }

        /// <summary>
        /// Продолжительность встречи. Если неизвестна - возвращает максимальное значение.
        /// </summary>
        public override TimeSpan Duration
        {
            get
            {
                return this.EndTime == DateTime.MaxValue ? TimeSpan.MaxValue : base.Duration;
            }
        }
    }
}
