using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowercutGadget
{
    static class SyncedData
    {
        static private List<TimeSlot> timeSlots = new List<TimeSlot>();
        static private DateTime lastSyncDateTime;


        static public DateTime LastSyncDateTime
        {
            get { return lastSyncDateTime; }
        }
        static public List<TimeSlot> TimeSlots
        {
            get { return timeSlots; }
            set {
                timeSlots = value;
                lastSyncDateTime = DateTime.Now;
            }
        }

        static public Boolean isSynced()
        {
            if (timeSlots.Count > 0 && lastSyncDateTime!=null && lastSyncDateTime.Date==DateTime.Now.Date)
            {
                return true;
            }

            return false;
        }

        static public int timeSlotCount()
        {
            return timeSlots.Count;
        }

        //return -2 for failed or all timeslots are expired
        //teturn -1 when there is a ongoing time slot 
        static public int getIndexOfNearestTimeSlotIndex()
        {
            if (isSynced())
            {
                int i = 0;

                foreach (TimeSlot t in timeSlots)
                {
                    if (DateTime.Now <= t.EndTime && DateTime.Now>=t.StartTime){
                        return -1;
                    }

                    if (t.StartTime > DateTime.Now)
                    {
                        return i;
                    }

                    i++;
                }

            }

            return -2;
        }
    }
}
