using EventManagementDataService;
using EventCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement_BusinessDataLogic
{
    public class EventManagementService
    {
        int[] monthsWith31Days = new int[] {1,3,5,7,8,10,12};
        int[] monthsWith30Days = new int[] { 4,6,9,11};
        int[] monthsWith28Days = new int[] { 2 };

        EventDataService eventsDataService = new EventDataService();

        public bool UpdateEvent(string eventName, string currentUsername)
        {
            EventAccount account = eventsDataService.GetAccount(currentUsername);

            if (account != null)
            {
                if (account.CreatedEvents.Contains(eventName))
                {
                    eventsDataService.RemoveEvent(eventName);
                }
            }

            return false;
        }
        public bool CreateEvent(string eventName, string startDate, string endDate, string startTime, string endTime, string currentUsername)
        {
            EventAccount account = eventsDataService.GetAccount(currentUsername);

            if (account == null)
            {
                return false; 
            }

            if (!CheckScheduleConflict(startDate, endDate, startTime, endTime))
            {
                return false; 
            }
            account.CreatedEvents.Add(eventName);
            eventsDataService.AddEvent(eventName, startDate, endDate, startTime, endTime, currentUsername);

            return true;
        }

        public bool DeleteEvent(string eventName, string currentUsername)
        {
            EventAccount account = eventsDataService.GetAccount(currentUsername);

            if (account == null)
            {
                return false;
            }

            if (account.CreatedEvents.Contains(eventName))
            {
                int index = eventsDataService.GetEventIndex(eventName);

                if (index != -1 && eventsDataService.GetEventCreator(index) == currentUsername)
                {
                    eventsDataService.RemoveEvent(eventName); 
                    account.CreatedEvents.Remove(eventName);
                    return true;
                }
            }

            return false;
        }
        public bool CheckScheduleConflict(string newStartDate, string newEndDate, string newStartTime, 
                                                 string newEndTime)
        {
            DateTime newStart = DateTime.Parse($"{newStartDate} {newStartTime}");
            DateTime newEnd = DateTime.Parse($"{newEndDate} {newEndTime}");

            for (int i = 0; i < eventsDataService.EventList.Count; i++)
            {
                DateTime existingStart = DateTime.Parse($"{eventsDataService.EventStartDates[i]} {eventsDataService.EventStartTimes[i]}");
                DateTime existingEnd = DateTime.Parse($"{eventsDataService.EventEndDates[i]}   {eventsDataService.EventEndTimes[i]}");

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
        public bool DuplicateUser(string username, string phoneNumber, string email)
        {
            return eventsDataService.IsDuplicateUser(username, phoneNumber, email);
        }
        public bool ValidLogIn(string currentUsername, string password)
        {
            return eventsDataService.ValidLogin(currentUsername, password);
        }
        public bool EventCompleter(string eventName)
        {
            int index = eventsDataService.GetEventIndex(eventName);

            if (index != -1)
            {
                string creator = eventsDataService.GetEventCreator(index);
                string eventDetails = "Event Name: " + eventsDataService.EventList[index] +
                                      ", Start: " + eventsDataService.EventStartDates[index] + " " + eventsDataService.EventStartTimes[index] +
                                      ", End: " + eventsDataService.EventEndDates[index] + " " + eventsDataService.EventEndTimes[index] +
                                      ", Created by: " + creator;

                foreach (EventAccount account in eventsDataService.accounts)
                {
                    account.CompletedEvents.Add(eventDetails);
                }

                eventsDataService.RemoveEvent(eventName);
                return true;
            }

            return false;
        }
        public void ClearAllEvents()
        {
            eventsDataService.ClearUserEvents();
        }
        public bool ValidEventSelector(string input, out int selectedIndex)
        {
            return int.TryParse(input, out selectedIndex) && selectedIndex >= 1 && selectedIndex <= eventsDataService.EventList.Count;
        } 
    }
}
