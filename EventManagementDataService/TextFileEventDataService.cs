using EventCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EventManagementDataService
{
    public class TextFileEventDataService : IEventDataService
    {
        string accountsPath = "accounts.txt";
        string eventsPath = "events.txt";

        public List<EventAccount> Accounts { get; private set; } = new List<EventAccount>();
        public List<EventInfo> Events { get; private set; } = new List<EventInfo>();

        private int[] months = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        public int[] Months => (int[])months.Clone();

        public TextFileEventDataService()
        {
            LoadAccountsFromFile();
            LoadEventsFromFile();
        }

        private void LoadAccountsFromFile()
        {
            if (!File.Exists(accountsPath)) return;

            foreach (var line in File.ReadAllLines(accountsPath))
            {
                var parts = line.Split('|');
                if (parts.Length < 4) continue;

                Accounts.Add(new EventAccount
                {
                    Username = parts[0],
                    Password = parts[1],
                    PhoneNumber = parts[2],
                    Email = parts[3],
                    CreatedEvents = new List<string>(),
                    CompletedEvents = new List<string>()
                });
            }
        }

        private void LoadEventsFromFile()
        {
            if (!File.Exists(eventsPath)) return;

            foreach (var line in File.ReadAllLines(eventsPath))
            {
                var parts = line.Split('|');
                if (parts.Length < 6) continue;

                Events.Add(new EventInfo
                {
                    Name = parts[0],
                    StartDate = parts[1],
                    EndDate = parts[2],
                    StartTime = parts[3],
                    EndTime = parts[4],
                    Creator = parts[5]
                });
            }
        }

        private void SaveAccountsToFile()
        {
            var lines = Accounts.Select(acc =>
                $"{acc.Username}|{acc.Password}|{acc.PhoneNumber}|{acc.Email}");
            File.WriteAllLines(accountsPath, lines);
        }

        private void SaveEventsToFile()
        {
            var lines = Events.Select(ev =>
                $"{ev.Name}|{ev.StartDate}|{ev.EndDate}|{ev.StartTime}|{ev.EndTime}|{ev.Creator}");
            File.WriteAllLines(eventsPath, lines);
        }

        public void AddEvent(string name, string startDate, string endDate, string startTime, string endTime, string creator)
        {
            Events.Add(new EventInfo
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                StartTime = startTime,
                EndTime = endTime,
                Creator = creator
            });

            SaveEventsToFile();
        }

        public bool RemoveEvent(string eventName)
        {
            var index = GetEventIndex(eventName);
            if (index == -1) return false;

            Events.RemoveAt(index);
            SaveEventsToFile();
            return true;
        }

        public EventAccount GetAccount(string username)
        {
            return Accounts.FirstOrDefault(a => a.Username == username);
        }

        public int GetEventIndex(string eventName)
        {
            return Events.FindIndex(e => e.Name == eventName);
        }

        public string GetEventCreator(int index)
        {
            return (index >= 0 && index < Events.Count) ? Events[index].Creator : null;
        }

        public void ClearUserEvents()
        {
            foreach (var account in Accounts)
            {
                account.CreatedEvents.Clear();
                account.CompletedEvents.Clear();
            }
            SaveAccountsToFile();
        }

        public bool IsDuplicateUser(string username, string phoneNumber, string email)
        {
            return Accounts.Any(a =>
                a.Username == username || a.PhoneNumber == phoneNumber || a.Email == email);
        }

        public void AddNewAccount(string username, string password, string phoneNumber, string email)
        {
            Accounts.Add(new EventAccount
            {
                Username = username,
                Password = password,
                PhoneNumber = phoneNumber,
                Email = email,
                CreatedEvents = new List<string>(),
                CompletedEvents = new List<string>()
            });

            SaveAccountsToFile();
        }

        public bool ValidLogin(string currentUsername, string password)
        {
            return Accounts.Any(a => a.Username == currentUsername && a.Password == password);
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
                SaveAccountsToFile();
                return true;
            }
            return false;
        }
    }
}