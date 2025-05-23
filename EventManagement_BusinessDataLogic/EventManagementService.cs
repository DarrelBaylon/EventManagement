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
        private IEventDataService dataService;
        int[] monthsWith31Days = new int[] {1,3,5,7,8,10,12};
        int[] monthsWith30Days = new int[] { 4,6,9,11};
        int[] monthsWith28Days = new int[] { 2 };

        InMemoryEventDataService eventsDataService = new InMemoryEventDataService();

        public EventManagementService()
        {
            //dataService = new InMemoryEventDataService();
            dataService = new TextFileEventDataService();
        }

        public void UpdateEvent(string eventName, string currentUsername)
        {
            EventAccount account = eventsDataService.GetAccount(currentUsername);

            if (account != null)
            {
                if (account.CreatedEvents.Contains(eventName))
                {
                    int index = eventsDataService.GetEventIndex(eventName);

                    if (index != -1)
                    {
                        string creator = eventsDataService.GetEventCreator(index);

                        if (creator == currentUsername)
                        {
                            eventsDataService.RemoveEvent(eventName);
                            account.CreatedEvents.Remove(eventName);
                        }
                    }
                }
            }
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
        public bool CheckScheduleConflict(string newStartDate, string newEndDate, string newStartTime, string newEndTime)
        {
            DateTime newStart = DateTime.Parse(newStartDate + " " + newStartTime);
            DateTime newEnd = DateTime.Parse(newEndDate + " " + newEndTime);

            for (int i = 0; i < eventsDataService.Events.Count; i++)
            {
                EventInfo existingEvent = eventsDataService.Events[i];
                DateTime existingStart = DateTime.Parse(existingEvent.StartDate + " " + existingEvent.StartTime);
                DateTime existingEnd = DateTime.Parse(existingEvent.EndDate + " " + existingEvent.EndTime);

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
            List<EventInfo> eventList = GetAllEvents();
            int index = eventsDataService.GetEventIndex(eventName);

            if (index != -1)
            {
                string creator = eventsDataService.GetEventCreator(index);
                string eventDetails = $"Event Name: {eventList[index].Name}, Start: {eventList[index].StartDate} {eventList[index].StartTime}, " +
                                      $"End: {eventList[index].EndDate} {eventList[index].EndTime}, Created by: {creator}";

                return eventsDataService.CompleteEvent(eventName, eventDetails);
            }

            return false;
        }
        public void ClearAllEvents()
        {
            eventsDataService.ClearUserEvents();
        }
        public bool ValidEventSelector(string input, out int selectedIndex)
        {
            if (int.TryParse(input, out selectedIndex) && selectedIndex >= 1 && selectedIndex <= eventsDataService.Events.Count)
            {
                return true;
            }
            else
            {
                selectedIndex = -1; 
                return false;
            }
        }
        public void RegisterAccounts(string username, string password, string email, string phoneNumber)
        {
            eventsDataService.AddNewAccount(username, password, phoneNumber, email);
        }
        public List<EventInfo> GetAllEvents()
        {
            return eventsDataService.Events;
        }
        public List<EventAccount> GetCompletedEvents()
        {
            return eventsDataService.Accounts;
        }
    }
}
