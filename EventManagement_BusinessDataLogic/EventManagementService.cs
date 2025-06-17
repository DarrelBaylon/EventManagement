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
        int[] monthsWith31Days = new int[] { 1, 3, 5, 7, 8, 10, 12 };
        int[] monthsWith30Days = new int[] { 4, 6, 9, 11 };
        int[] monthsWith28Days = new int[] { 2 };

        EventDataService eventsDataService = new EventDataService();


        /*public void UpdateEvent(string eventName, string currentUsername)
        {
            EventAccount account = GetAccount(currentUsername);

            if (account != null)
            {
                if (account.CreatedEvents.Contains(eventName))
                {
                    int index = GetEventIndex(eventName);

                    if (index != -1)
                    {
                        
                        EventInfo eventInfo = GetAllEvents()[index];
                        string targetEventName = eventInfo.Name;

                        foreach (EventAccount acc in GetAccounts())
                        {
                            if (acc.CreatedEvents.Contains(targetEventName))
                            {
                                return; 
                            }
                        }
                        
                        if (eventInfo.Creator == currentUsername)
                        {
                            DeleteEvent(eventName, currentUsername);
                            account.CreatedEvents.Remove(eventName);
                            eventsDataService.UpdateEvent(eventInfo);
                        }
                    }
                }
            }
        }*/

        public void UpdateEvent(string eventName, string currentUsername)
        {
            EventAccount account = GetAccount(currentUsername);

            if (account != null)
            {
                if (account.CreatedEvents.Contains(eventName))
                {
                    int index = GetEventIndex(eventName);

                    if (index != -1)
                    {
                        EventInfo eventInfo = GetAllEvents()[index];

                        if (eventInfo.Creator == currentUsername)
                        {
                            eventsDataService.UpdateEvent(eventInfo);
                            account.CreatedEvents.Remove(eventName);
                        }
                    }
                }
            }
        }
        public bool CreateEvent(string eventName, string startDate, string endDate, string startTime, string endTime, string currentUsername)
        {
            EventAccount account = GetAccount(currentUsername);

            if (account == null)
            {
                return false;
            }

            if (!CheckScheduleConflict(startDate, endDate, startTime, endTime))
            {
                return false;
            }

            EventInfo eventInfo = new EventInfo
            {
                Name = eventName,
                StartDate = startDate,
                EndDate = endDate,
                StartTime = startTime,
                EndTime = endTime,
                Creator = currentUsername
            };

            eventsDataService.AddEvent(eventInfo);

            account.CreatedEvents.Add(eventName);

            return true;
        }



        /*public bool DeleteEvent(string eventName, string currentUsername)
        {
            EventAccount account = GetAccount(currentUsername);
            if (account == null)
            {
                return false;
            }

            // Debug
            Console.WriteLine("Created Events:");
            for (int i = 0; i < account.CreatedEvents.Count; i++)
            {
                Console.WriteLine(account.CreatedEvents[i]);
            }

            List<EventInfo> allEvents = GetAllEvents();
            int index = GetEventIndex(eventName);

            if (index != -1)
            {
                Console.WriteLine("CurrentUser: " + currentUsername);
                Console.WriteLine("Event Creator: " + allEvents[index].Creator);

                if (allEvents[index].Creator.Trim().ToLower() == currentUsername.Trim().ToLower())
                {
                    // Fix: Pass the correct type (EventInfo) to RemoveEvent
                    eventsDataService.RemoveEvent(allEvents[index]);

                    // Optional: also remove from CreatedEvents
                    for (int i = 0; i < account.CreatedEvents.Count; i++)
                    {
                        if (account.CreatedEvents[i].ToLower() == eventName.ToLower())
                        {
                            account.CreatedEvents.RemoveAt(i);
                            break;
                        }
                    }

                    return true;
                }
            }

            return false;
        }*/

        public bool DeleteEvent(string eventName, string currentUsername)
        {
            EventAccount account = GetAccount(currentUsername);
            if (account == null)
            {
                return false;
            }

            List<EventInfo> allEvents = GetAllEvents();
            int index = GetEventIndex(eventName);

            if (index != -1)
            {
                EventInfo eventToDelete = allEvents[index];

                Console.WriteLine("CurrentUser: " + currentUsername);
                Console.WriteLine("Event Creator: " + eventToDelete.Creator);

                if (eventToDelete.Creator.Trim().ToLower() == currentUsername.Trim().ToLower())
                {
                    eventsDataService.RemoveEvent(eventToDelete);
                    return true;
                }
            }

            return false;
        }
        public bool CheckScheduleConflict(string newStartDate, string newEndDate, string newStartTime, string newEndTime)
        {
            DateTime newStart = DateTime.Parse(newStartDate + " " + newStartTime);
            DateTime newEnd = DateTime.Parse(newEndDate + " " + newEndTime);

            for (int i = 0; i < GetAllEvents().Count; i++)
            {
                EventInfo existingEvent = GetAllEvents()[i];
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
           

            List<EventAccount> accounts = GetAccounts();

            foreach (EventAccount account in accounts)
            {
                if (account.Username == username || account.PhoneNumber == phoneNumber || account.Email == email)
                {
                    return true;
                }
            }

            return false;
        }
        public bool ValidLogIn(string currentUsername, string password)
        {
            List<EventAccount> accounts = GetAccounts();
            foreach (var account in accounts)
            {
                if (account.Username == currentUsername && account.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        public bool EventCompleter(string eventName)
        {
            List<EventInfo> eventList = GetAllEvents();
            int index = GetEventIndex(eventName);

            if (index != -1)
            {
             
                string creator = eventList[index].Creator;
                string eventDetails = $"Event Name: {eventList[index].Name}, Start: {eventList[index].StartDate} {eventList[index].StartTime}, " +
                                      $"End: {eventList[index].EndDate} {eventList[index].EndTime}, Created by: {creator}";

                return eventsDataService.CompleteEvent(eventName, eventDetails);
            }

            return false;
        }
        public void ClearAllEvents()
        {
            eventsDataService.info.Clear();
        }
        public bool ValidEventSelector(string input, out int selectedIndex)
        {
            if (int.TryParse(input, out selectedIndex) && selectedIndex >= 1 && selectedIndex <= GetAllEvents().Count)
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
            EventAccount newAccount = new EventAccount
            {
                Username = username,
                Password = password,
                Email = email,
                PhoneNumber = phoneNumber
            };

            eventsDataService.addAccount(newAccount);
        }
        public List<EventInfo> GetAllEvents()
        {
            return eventsDataService.GetEvents();
        }
        public List<string> GetCompletedEvents()
        {
            return eventsDataService.GetCompletedEvents();
        }
        private List<EventAccount> GetAccounts()
        {
            return eventsDataService.GetAccounts();
        }
        private EventAccount GetAccount(string username)
        {
            
            List<EventAccount> accounts = GetAccounts();

            foreach (EventAccount account in accounts)
            {
                if (account.Username == username)
                {
                    return account;
                }
            }

            return null;
        }
        public int GetEventIndex(string eventName)
        {
            return eventsDataService.GetEventIndex(new EventInfo { Name = eventName });
        }


       

    }

    
}