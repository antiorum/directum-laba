using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Directum_laba
{
    class Meeting
    {
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }

        public string Duration
        {
            get { return EndTime.Subtract(BeginTime).ToString(); }
        }

    }
}
