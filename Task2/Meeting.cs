namespace Directum_laba
{
    using System;
    public class Meeting
    {
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual TimeSpan Duration
        {
            get { return EndTime.Subtract(BeginTime); }
        }

    }
}
