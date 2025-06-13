﻿using EventCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementDataService
{
    public class TextFileDataService
    {
        public List<EventAccount> Accounts { get; private set; } = new List<EventAccount>();
        public List<EventInfo> Events { get; private set; } = new List<EventInfo>();

        string accountFilePath = "accounts.txt";
        string eventFilePath = "events.txt";
        string completedEventFilePath = "completedEvents.txt";

        public TextFileDataService()
        {
            GetAccountDataFromFile();
            GetEventDataFromFile();
            GetCompletedEventDataFromFile();
        }
        private void GetAccountDataFromFile()
        {
            var lines = File.ReadAllLines(accountFilePath);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split('|');

                if (parts.Length >= 4)
                {
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
                else
                {
                    
                }
            }
        }
        private void GetEventDataFromFile()
        {
            var lines = File.ReadAllLines(eventFilePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length >= 6)
                {
                    Events.Add(new EventInfo
                    {
                        Name = parts[0],
                        StartDate = parts[1],
                        StartTime = parts[2],
                        EndDate = parts[3],
                        EndTime = parts[4],
                        Creator = parts[5]
                    });
                }
                
            }
        }
        private void GetCompletedEventDataFromFile()
        {
            var lines = File.ReadAllLines(completedEventFilePath);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split('|');

                if (parts.Length > 0)
                {
                    var account = new EventAccount
                    {
                        CompletedEvents = new List<string>()
                    };

                    foreach (var eventName in parts)
                    {
                        account.CompletedEvents.Add(eventName.Trim());
                    }

                    Accounts.Add(account);
                }
            }
        }

        private void WriteEventDataToFile()
        {
            var lines = new string[Events.Count];

            for (int i = 0; i < Events.Count; i++)
            {
                lines[i] = $"{Events[i].Name}|{Events[i].StartDate}|{Events[i].EndDate}|{Events[i].StartTime}|{Events[i].EndTime}|" +
                           $"{Events[i].Creator}|";
            }
            File.WriteAllLines(eventFilePath, lines);
        }

        public int FindIndex(EventInfo eventInfo)
        {
            
            for (int i = 0; i < Events.Count; i++)
            {
                if (Events[i].Name == eventInfo.Name)
                {
                    return i;
                }
            }

            return -1;
        }

        public List < EventAccount> GetAccounts()
        {
            return Accounts;
        }

        public List<EventInfo> GetEvents()
        {
            return Events;
        }

        public List<string> GetCompletedEvents()
        {
            for (int i = 0; i < Accounts.Count; i++)
            {
               
                    return Accounts[i].CompletedEvents;
                
            }
            return new List<string>();
        }

        public void AddAccount(EventAccount eventAccount)
        {
            var newLine = $"{eventAccount.Username}|{eventAccount.Password}|{eventAccount.PhoneNumber}|{eventAccount.Email}\n";

            File.AppendAllText(accountFilePath, newLine);
        }

        public void AddEvent(EventInfo eventInfo)
        {
            var newLine = $"{eventInfo.Name}|{eventInfo.StartDate}|{eventInfo.StartTime}|{eventInfo.EndDate}|{eventInfo.EndTime}|" +
                          $"{eventInfo.Creator}\n";

            File.AppendAllText(eventFilePath, newLine);
        }

        public void AddCompletedEvent(EventAccount eventAccount)
        {
            var newLine = $"{eventAccount.CompletedEvents}";
            File.AppendAllText(completedEventFilePath, newLine);
        }
        public void UpdateEvent(EventInfo eventInfo)
        {
            //RemoveEvent(eventInfo);
            int index = FindIndex(eventInfo);

            Events[index].Name = eventInfo.Name;
            Events[index].StartDate = eventInfo.StartDate;
            Events[index].EndDate = eventInfo.EndDate;
            Events[index].StartTime = eventInfo.StartTime;
            Events[index].EndTime = eventInfo.EndTime;
            Events[index].Creator = eventInfo.Creator;
            
            WriteEventDataToFile();
        }
        public void RemoveEvent(EventInfo eventInfo)
        {
            int index = -1;
            for (int i = 0; i < Events.Count; i++)
            {
                if (Events[i].Name == eventInfo.Name)
                {
                    index = i;
                }
            }
            if(index!= -1)
            {
                Events.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Event Not Found");
            }
                WriteEventDataToFile();
        }
    }
}
