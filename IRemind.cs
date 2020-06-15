using System;
using System.Collections.Generic;
using System.Text;

namespace directum_laba
{
    interface IRemind
    {
        void SetRemindTime(DateTime Remind);
        DateTime GetRemindTime(); 
    }
}
