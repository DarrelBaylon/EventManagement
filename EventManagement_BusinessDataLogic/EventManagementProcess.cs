using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement_BusinessDataLogic
{
    public class EventManagementProcess
    {
        public static List<string> eventList = new List<string>();
        public static bool UpdateEvent(string updateEventBefore, string updateEventCurrent)
        {
            if (eventList.Contains(updateEventBefore) && !eventList.Contains(updateEventCurrent))
            {

                eventList.Remove(updateEventBefore);
                eventList.Add(updateEventCurrent);
                return true;
            }
            return false;
        }
        public static bool CreateEvent(string eventName)
        {
            if (!eventList.Contains(eventName))
            {
                eventList.Add(eventName);
                return true;
            }
            return false;
            
        }
        public static bool DeleteEvent(string deleteEvent)
        {
            if (eventList.Contains(deleteEvent))
            {
                eventList.Remove(deleteEvent);
                return true;
            }
            return false;
        }
    }
}
