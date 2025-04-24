using EventCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementDataService
{
    public class EventDataService
    {
        List<string> eventList = new List<string>();
        List<string> eventStartDates = new List<string>();
        List<string> eventEndDates = new List<string>();
        List<string> eventStartTimes = new List<string>();
        List<string> eventEndTimes = new List<string>();
        public List  <EventAccount> accounts = new List<EventAccount>();
        List<string> eventCreators = new List<string>();
        int[] months = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

        public List<string> EventList { get { return (eventList); } }
        public List<string> EventStartDates { get { return (eventStartDates); } }
        public List<string> EventEndDates { get { return (eventEndDates); } }
        public List<string> EventStartTimes { get { return (eventStartTimes); } }
        public List<string> EventEndTimes { get { return (eventEndTimes); } }
        public List<string> EventCreators { get { return (eventCreators); } }
        public int[] Months { get { return (int[])months.Clone(); } }

        public void AddEvent(string name, string startDate, string endDate, string startTime, string endTime, string creator)
        {
            eventList.Add(name);
            eventStartDates.Add(startDate);
            eventEndDates.Add(endDate);
            eventStartTimes.Add(startTime);
            eventEndTimes.Add(endTime);
            eventCreators.Add(creator);
        }

        public bool RemoveEvent( string eventName)
        {
            int index = eventList.IndexOf(eventName);
            if (index == -1) return false;

            eventList.RemoveAt(index);
            eventStartDates.RemoveAt(index);
            eventEndDates.RemoveAt(index);
            eventStartTimes.RemoveAt(index);
            eventEndTimes.RemoveAt(index);
            eventCreators.RemoveAt(index);

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
        public string GetAccounts(string username)
        {
            foreach (var acc in accounts)
            {
                if (acc.Username == username)
                {
                    return acc.Username;
                }
            }
            return null;
        }
        public int GetEventIndex(string eventName)
        {
            return eventList.IndexOf(eventName);
        }
        public string GetEventCreator(int index)
        {
            if (index >= 0 && index < EventCreators.Count)
            {
                return eventCreators[index];
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
            Console.WriteLine("DEBUG: Current total accounts: " + accounts.Count);
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
    }
}
