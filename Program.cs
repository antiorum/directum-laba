using System;
using System.Linq.Expressions;
using System.Threading;

namespace directum_laba
{
    class Program
    {
        static void Main(string[] args)
        {
            MeetingWithRemind meeting = new MeetingWithRemind(DateTime.Now.AddMinutes(2));
            meeting.Remind += () => Console.WriteLine("Event was generated");
            Console.ReadLine();
        }
    }
}
