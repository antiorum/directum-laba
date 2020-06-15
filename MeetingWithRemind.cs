using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Timers;

namespace directum_laba
{
    class MeetingWithRemind : Meeting, IRemind
    {
        public delegate void MeetingHandler();
        public event MeetingHandler Remind;
        private DateTime _remindTime;

        public MeetingWithRemind(DateTime remindTime)
        {
            RemindTime = remindTime;
            Timer timer = new Timer(60_000);
            timer.Elapsed += ElapseHandle;
            timer.Start();
        }

        public DateTime RemindTime
        {
            get { return _remindTime; }
            set { _remindTime = value; }
        }


        public DateTime GetRemindTime()
        {
            return RemindTime;
        }

        public void SetRemindTime(DateTime Remind)
        {
            RemindTime = Remind;
        }

        private void ElapseHandle(Object source, ElapsedEventArgs e)
        {
            if (e.SignalTime >= RemindTime)
            {
                Console.WriteLine("Timer will be stopped");
                Remind();
                Timer timer = (Timer)source;
                timer.Stop();
            }
        }
    }
}
