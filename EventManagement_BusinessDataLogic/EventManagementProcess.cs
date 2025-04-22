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

        List<string> eventList = new List<string>();
        List<string> eventStartDates = new List<string>();
        List<string> eventEndDates = new List<string>();
        List<string> eventStartTimes = new List<string>();
        List<string> eventEndTimes = new List<string>();
        public List<EventAccount> accounts = new List<EventAccount>();
        List<string> eventCreators = new List<string>();


        int[] months = new int[] {1,2,3,4,5,6,7,8,9,10,11,12};
        int[] monthsWith31Days = new int[] {1,3,5,7,8,10,12};
        int[] monthsWith30Days = new int[] { 4,6,9,11};
        int[] monthsWith28Days = new int[] { 2 };

        public List<string> EventList { get { return (eventList); } }
        public List<string> EventStartDates { get { return (eventStartDates); } }
        public List<string> EventEndDates { get { return (eventEndDates); } }
        public List<string> EventStartTimes { get { return (eventStartTimes); } }
        public List<string> EventEndTimes { get { return (eventEndTimes); } }
        public int[] Months { get { return (int[])months.Clone(); } }

        public bool UpdateEvent(string eventName, string currentUsername)
        {
            EventAccount account = null;

            foreach (EventAccount acc in accounts)
            {
                if (acc.Username == currentUsername)
                {
                    account = acc;
                    break;
                }
            }
            if (account == null)
            {
                return false;  
            }
            if (account.CreatedEvents.Contains(eventName))
            {
                int index = eventList.IndexOf(eventName);

                if (index != -1 && eventCreators[index] == currentUsername)
                {
                    eventList.RemoveAt(index);
                    eventStartDates.RemoveAt(index);
                    eventEndDates.RemoveAt(index);
                    eventStartTimes.RemoveAt(index);
                    eventEndTimes.RemoveAt(index);
                    eventCreators.RemoveAt(index);

                    account.CreatedEvents.Remove(eventName);
                    account.CreatedEvents.Add(eventName); 

                    return true;
                }
            }
            return false;
        }
        public bool CreateEvent(string eventName, string startDate, string endDate, string startTime, string endTime, 
                                       string currentUsername)
        {
            EventAccount account = null;

            foreach (EventAccount acc in accounts)
            {
                if (acc.Username == currentUsername)
                {
                    account = acc;
                    break;
                }
            }
            if (account == null)
            {
                return false; 
            }
            if (!CheckScheduleConflict(startDate, endDate, startTime, endTime))
            {
                return false;
            }
            account.CreatedEvents.Add(eventName);
            eventList.Add(eventName); 
            eventStartDates.Add(startDate); 
            eventEndDates.Add(endDate); 
            eventStartTimes.Add(startTime); 
            eventEndTimes.Add(endTime);
            eventCreators.Add(currentUsername);
            return true;
        }

        public bool DeleteEvent(string eventName, string currentUsername)
        {
            EventAccount account = null;
            foreach (EventAccount acc in accounts)
            {
                if (acc.Username == currentUsername)
                {
                    account = acc;
                    break;
                }
            }
            if (account == null)
            {
                return false;
            }
            if (account.CreatedEvents.Contains(eventName))
            {
                int index = eventList.IndexOf(eventName);

                if (index != -1 && eventCreators[index] == currentUsername)
                {
                    eventList.RemoveAt(index);
                    eventStartDates.RemoveAt(index);
                    eventEndDates.RemoveAt(index);
                    eventStartTimes.RemoveAt(index);
                    eventEndTimes.RemoveAt(index);
                    eventCreators.RemoveAt(index);
                    account.CreatedEvents.Remove(eventName);
                    return true;
                }
            }
            return false;
        }
        public  bool CheckScheduleConflict(string newStartDate, string newEndDate, string newStartTime, 
                                                 string newEndTime)
        {
            DateTime newStart = DateTime.Parse($"{newStartDate} {newStartTime}");
            DateTime newEnd = DateTime.Parse($"{newEndDate} {newEndTime}");

            for (int i = 0; i < eventList.Count; i++)
            {
                DateTime existingStart = DateTime.Parse($"{eventStartDates[i]} {eventStartTimes[i]}");
                DateTime existingEnd = DateTime.Parse($"{eventEndDates[i]} {eventEndTimes[i]}");

                if (newStart < existingEnd && newEnd > existingStart)
                {
                    return false;
                }
            }

            return true;
        }
        public bool CheckStartDate(int startMonth, int startDay)
        {
            if (monthsWith31Days.Contains(startMonth) && startDay >= 1 && startDay <= 31 ||
            monthsWith30Days.Contains(startMonth) && startDay >= 1 && startDay <= 30 ||
            monthsWith28Days.Contains(startMonth) && startDay >= 1 && startDay <= 28)
            {
                return true;
            }
            return false;
        }
        public bool CheckEndDate(int endMonth, int endDay)
        {
            if (monthsWith31Days.Contains(endMonth) && endDay >= 1 && endDay <= 31 ||
            monthsWith30Days.Contains(endMonth) && endDay >= 1 && endDay <= 30 ||
            monthsWith28Days.Contains(endMonth) && endDay >= 1 && endDay <= 28)
            {
                return true;
            }
            return false;
        }
        public  bool DuplicateUser(string username, string phoneNumber, string email)
        {
            foreach (EventAccount account in accounts)
            {
                if (account.Username == username || account.PhoneNumber == phoneNumber || account.Email == email)
                    return true;
            }
            return false;
        }
        public  bool ValidLogin(string currentUsername, string password)
        {
            foreach (EventAccount account in accounts)
            {
                if (account.Username == currentUsername && account.Password == password)
                    return true;
            }
            return false;
        }
        public  bool EventCompleter(string eventName)
        {
            int index = eventList.IndexOf(eventName);

            if (index != -1)
            {
                string completedEvent = "Event Name: " + eventList[index] +
                                        ", Start: " + eventStartDates[index] + " " + eventStartTimes[index] +
                                        ", End: " + eventEndDates[index] + " " + eventEndTimes[index] +
                                        ", Created by: " + eventCreators[index];

                foreach (var account in accounts)
                {
                    
                        account.CompletedEvents.Add(completedEvent);

                        eventList.RemoveAt(index);
                        eventStartDates.RemoveAt(index);
                        eventEndDates.RemoveAt(index);
                        eventStartTimes.RemoveAt(index);
                        eventEndTimes.RemoveAt(index);
                        eventCreators.RemoveAt(index);

                        return true;
                    
                }
                return false;
            }
            return false;
        }
        public void ClearAllEvents()
        {
            foreach (EventAccount account in accounts)
            {
                account.CreatedEvents.Clear();
                account.CompletedEvents.Clear();
            }
        }
        public bool ValidEventSelector(string input, out int selectedIndex)
        {
            return int.TryParse(input, out selectedIndex) && selectedIndex >= 1 && selectedIndex <= eventList.Count;
        } 
    }
}
