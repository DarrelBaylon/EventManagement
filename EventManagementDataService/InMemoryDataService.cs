using EventCommon;
using System;
using System.Collections.Generic;

namespace EventManagementDataService
{
    public class InMemoryEventDataService
    {
        private List<EventAccount> accounts = new List<EventAccount>();
        private List<EventInfo> info = new List<EventInfo>();
        private int[] months = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

        public int[] Months { get { return (int[])months.Clone(); } }

        public void AddEvent(string name, string startDate, string endDate, string startTime, string endTime, string creator)
        {
            EventInfo newEvent = new EventInfo
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                StartTime = startTime,
                EndTime = endTime,
                Creator = creator
            };
            info.Add(newEvent);
        }

        public bool RemoveEvent(string eventName)
        {
            int index = GetEventIndex(eventName);
            if (index == -1) return false;

            info.RemoveAt(index);
            return true;
        }

        public EventAccount GetAccount(string username)
        {
            foreach (var acc in accounts)
            {
                if (acc.Username == username)
                {
                    return acc;
                }
            }
            return null;
        }

        public int GetEventIndex(string eventName)
        {
            for (int i = 0; i < info.Count; i++)
            {
                if (info[i].Name == eventName)
                {
                    return i;
                }
            }
            return -1;
        }

        public string GetEventCreator(int index)
        {
            if (index >= 0 && index < info.Count)
            {
                return info[index].Creator;
            }
            return null;
        }

        public void ClearUserEvents()
        {
            foreach (var account in accounts)
            {
                account.CreatedEvents.Clear();
                account.CompletedEvents.Clear();
            }
        }

        public bool IsDuplicateUser(string username, string phoneNumber, string email)
        {
            foreach (EventAccount account in accounts)
            {
                if (account.Username == username || account.PhoneNumber == phoneNumber || account.Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddNewAccount(string username, string password, string phoneNumber, string email)
        {
            EventAccount newUser = new EventAccount
            {
                Username = username,
                Password = password,
                PhoneNumber = phoneNumber,
                Email = email
            };
            accounts.Add(newUser);
        }

        public bool ValidLogin(string currentUsername, string password)
        {
            foreach (var acc in accounts)
            {
                if (acc.Username == currentUsername && acc.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CompleteEvent(string eventName, string eventDetails)
        {
            int index = GetEventIndex(eventName);
            if (index != -1)
            {
                foreach (EventAccount account in accounts)
                {
                    account.CompletedEvents.Add(eventDetails);
                }
                RemoveEvent(eventName);
                return true;
            }
            return false;
        }
    }
}