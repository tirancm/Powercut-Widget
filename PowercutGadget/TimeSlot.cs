using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowercutGadget
{
    class TimeSlot
    {
        private DateTime startTime;
        private DateTime endTime;

        public DateTime StartTime
        {
           get { return startTime; }
           set { startTime = value; }
        }

        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        public TimeSlot(DateTime start,DateTime end)
        {
            this.startTime = start;
            this.endTime = end;
        }
    }
}
