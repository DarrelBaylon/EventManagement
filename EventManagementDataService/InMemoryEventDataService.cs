using EventCommon;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventManagementDataService
{
    public class InMemoryEventDataService : IEventDataService
    {
        public List<EventAccount> Accounts { get; } = new List<EventAccount>();
        public List<EventInfo> Events { get; } = new List<EventInfo>();

        private int[] months = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        public int[] Months => (int[])months.Clone();

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

            Events.Add(newEvent);
        }

        public bool RemoveEvent(string eventName)
        {
            int index = GetEventIndex(eventName);
            if (index == -1) return false;

            Events.RemoveAt(index);
            return true;
        }

        public EventAccount GetAccount(string username)
        {
            return Accounts.FirstOrDefault(acc => acc.Username == username);
        }

        public int GetEventIndex(string eventName)
        {
            return Events.FindIndex(e => e.Name == eventName);
        }

        public string GetEventCreator(int index)
        {
            return index >= 0 && index < Events.Count ? Events[index].Creator : null;
        }

        public void ClearUserEvents()
        {
            foreach (var account in Accounts)
            {
                account.CreatedEvents.Clear();
                account.CompletedEvents.Clear();
            }
        }

        public bool IsDuplicateUser(string username, string phoneNumber, string email)
        {
            return Accounts.Any(account =>
                account.Username == username || account.PhoneNumber == phoneNumber || account.Email == email);
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

            Accounts.Add(newUser);
            Console.WriteLine("DEBUG: Current total accounts: " + Accounts.Count);
        }

        public bool ValidLogin(string currentUsername, string password)
        {
            return Accounts.Any(acc => acc.Username == currentUsername && acc.Password == password);
        }

        public bool CompleteEvent(string eventName, string eventDetails)
        {
            int index = GetEventIndex(eventName);

            if (index != -1)
            {
                foreach (var account in Accounts)
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