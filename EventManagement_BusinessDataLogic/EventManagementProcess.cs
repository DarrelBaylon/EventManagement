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
        public static List<string> eventStartDates = new List<string>();
        public static List<string> eventEndDates = new List<string>();
        public static List<string> eventStartTimes = new List<string>();
        public static List<string> eventEndTimes = new List<string>();

        public static bool UpdateEvent(string updateEventBefore)
        {
            int index = eventList.IndexOf(updateEventBefore);

            if (eventList.Contains(updateEventBefore))
            {
                eventList.Remove(updateEventBefore);
                eventStartDates.RemoveAt(index);  
                eventEndDates.RemoveAt(index);
                eventStartTimes.RemoveAt(index);
                eventEndTimes.RemoveAt(index);
                return true;
            }
            return false;
        }
        
        public static void CreateEvent(string eventName, string startDate, string endDate, string startTime, 
            string endTime)
        {
            eventList.Add(eventName);
            eventStartDates.Add(startDate);
            eventStartTimes.Add(startTime);
            eventEndDates.Add(endDate);
            eventEndTimes.Add(endTime);
        }

        public static bool DeleteEvent(string deleteEvent)
        {
            int index = eventList.IndexOf(deleteEvent);
            if (eventList.Contains(deleteEvent))
            {
                if (index != -1)
                {
                    eventList.RemoveAt(index);
                    eventStartDates.RemoveAt(index);
                    eventEndDates.RemoveAt(index);
                    eventStartTimes.RemoveAt(index);
                    eventEndTimes.RemoveAt(index);
                    return true;
                }
            }
            return false;
        }
    }
}
