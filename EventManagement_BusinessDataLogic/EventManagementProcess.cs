using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
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
        public static string[] events = new string[] { "[1] Create Event", "[2] View Event", "[3] Update Event",
                                                "[4] Delete Event", "[5] Exit" };
        public static string[] months = new string[] { "JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY",
                                                "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER", "JAN",
                                                "FEB", "MAR", "APR", "JUN", "JUL", "AUG", "SEPT", "OCT", "NOV",
                                                "DEC"};
        static string[] monthsWith31Days = new string[] { "JANUARY", "MARCH", "MAY", "JULY",
                                                          "AUGUST", "OCTOBER", "DECEMBER", "DEC", "JAN", "MAR",
                                                          "MAY", "JUL", "AUG", "OCT"};
        static string[] monthsWith30Days = new string[] { "APRIL", "JUNE", "SEPTEMBER", "NOVEMBER", "APR", "JUN",
                                                          "SEPT", "NOV"};
        static string[] monthsWith28Days = new string[] { "FEBRUARY", "FEB" };

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

        public static bool CreateEvent(string eventName, string startDate, string endDate, string startTime, 
                           string endTime)
        {
            if (endDate.CompareTo(startDate) < 0)
            {
                return false;
            }

            if (startDate == endDate && endTime.CompareTo(startTime) < 0)
            {
                return false; 
            }

            if (!CheckScheduleConflict(startDate, endDate, startTime, endTime))
            {
                return false; 
            }

            eventList.Add(eventName);
            eventStartDates.Add(startDate);
            eventEndDates.Add(endDate);
            eventStartTimes.Add(startTime);
            eventEndTimes.Add(endTime);

            return true; 
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
        public static bool CheckScheduleConflict(string newStartDate, string newEndDate, string newStartTime, 
                           string newEndTime)
        {
            for (int i = 0; i < eventList.Count; i++)
            {
                string existingStartDate = eventStartDates[i];
                string existingEndDate = eventEndDates[i];
                string existingStartTime = eventStartTimes[i];
                string existingEndTime = eventEndTimes[i];

                if (newStartDate == existingStartDate)
                {
                    if ((newStartTime.CompareTo(existingStartTime) >= 0 && 
                       newStartTime.CompareTo(existingEndTime) < 0) ||
                       (newEndTime.CompareTo(existingStartTime) > 0 && 
                       newEndTime.CompareTo(existingEndTime) <= 0) ||
                       (newStartTime.CompareTo(existingStartTime) < 0 && 
                       newEndTime.CompareTo(existingEndTime) > 0))
                    {
                        return false; 
                    }
                }
            }
            return true; 
        }
        public static bool CheckStartDate(string startMonth, int startDay)
        {
            if (monthsWith31Days.Contains(startMonth) && startDay >= 1 && startDay <= 31 ||
            monthsWith30Days.Contains(startMonth) && startDay >= 1 && startDay <= 30 ||
            monthsWith28Days.Contains(startMonth) && startDay >= 1 && startDay <= 28)
            {
                return true;
            }
            return false;
        }
        public static bool CheckEndDate(string endMonth, int endDay)
        {
            if (monthsWith31Days.Contains(endMonth) && endDay >= 1 && endDay <= 31 ||
            monthsWith30Days.Contains(endMonth) && endDay >= 1 && endDay <= 30 ||
            monthsWith28Days.Contains(endMonth) && endDay >= 1 && endDay <= 28)
            {
                return true;
            }
            return false;
        }

    }
}
