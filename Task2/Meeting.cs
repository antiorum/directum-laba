namespace Directum_laba
{
    using System;
    public class Meeting
    {
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual string Duration
        {
            get { return EndTime.Subtract(BeginTime).ToString(); }
        }

    }
}
