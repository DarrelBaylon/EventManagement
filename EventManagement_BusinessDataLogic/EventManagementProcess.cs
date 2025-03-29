using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement_BusinessDataLogic
{
    public class EventManagementProcess
    {
        public static List<string> eventList = new List<string>();
        public static bool UpdateEvent(string updateEventBefore)
        {
            if (eventList.Contains(updateEventBefore))
            {

                eventList.Remove(updateEventBefore);
               
                return true;
            }
            return false;
        }
        
        public static void CreateEvent(string eventName)
        {
            eventList.Add(eventName);
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
