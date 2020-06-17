namespace Directum_laba
{
    using System;

    /// <summary>
    /// Класс для точки входа в приложение
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа в приложение
        /// </summary>
        public static void Main()
        {
            // 54 предупреждения от StyleCop.
            // + В MeetingWithRemind лучше либо убрать свойство, либо убрать методы и переделать интерфейс на свойства.
            MeetingWithRemind meeting = new MeetingWithRemind(DateTime.Now.AddMinutes(2));
            meeting.BeginTime = DateTime.Now.AddDays(1);
            meeting.EndTime = DateTime.Now.AddDays(1).AddHours(1);
            Console.WriteLine(meeting.Duration);
            meeting.Remind += () => Console.WriteLine("Event was generated");
            Console.ReadLine();
        }
    }
}
