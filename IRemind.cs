using System;
using System.Collections.Generic;
using System.Text;

namespace directum_laba
{
    interface IRemind
    {
    // А почему методами, а не с помощью свойства? Так можно, но интересны причины.
        void SetRemindTime(DateTime Remind);
        DateTime GetRemindTime(); 
    }
}
