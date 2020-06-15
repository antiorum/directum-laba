using System;
using System.Linq.Expressions;
using System.Threading;

namespace directum_laba
{
    class Program
    {
    // Заметил проблему со стилем. На следующей лекции скажу про StyleCop.
        static void Main(string[] args)
        {
            MeetingWithRemind meeting = new MeetingWithRemind(DateTime.Now.AddMinutes(2));
            meeting.BeginTime = DateTime.Now.AddDays(1);
            meeting.EndTime = DateTime.Now.AddDays(1).AddHours(1);
            Console.WriteLine(meeting.Duration);
            meeting.Remind += () => Console.WriteLine("Event was generated");
            Console.ReadLine();
        }
    }
}
