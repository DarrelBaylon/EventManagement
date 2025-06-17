using EventCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EventManagementDataService
{
    public class JsonFileDataService : IEventDataService
    {
        public List<EventAccount> eventAccounts { get; private set; } = new List<EventAccount>();
        public List<EventInfo> eventInfos { get; private set; } = new List<EventInfo>();
        private List<string> completedEvents = new List<string>();

        static string accountsJsonFilePath = "accounts.json";
        static string eventsJsonFilePath = "events.json";
        static string completedEventsJsonFilePath = "completedEvents.json";

        public JsonFileDataService()
        {
           ReadAccountJsonDataFromFile();
           ReadEventJsonDataFromFile();
           ReadCompletedEventJsonDataFromFile();
        }

        private void ReadAccountJsonDataFromFile()
        {
            string jsonText = File.ReadAllText(accountsJsonFilePath);

            eventAccounts = JsonSerializer.Deserialize<List<EventAccount>>
                           (jsonText, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        private void ReadEventJsonDataFromFile()
        {
            string jsonText = File.ReadAllText(eventsJsonFilePath);

            eventInfos = JsonSerializer.Deserialize<List<EventInfo>>
                           (jsonText, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        private void ReadCompletedEventJsonDataFromFile()
        {
            if (!File.Exists(completedEventsJsonFilePath))
            {
                completedEvents = new List<string>();
                return;
            }

            string jsonText = File.ReadAllText(completedEventsJsonFilePath);

            if (string.IsNullOrWhiteSpace(jsonText))
            {
                completedEvents = new List<string>();
                return;
            }

            completedEvents = JsonSerializer.Deserialize<List<string>>(
                jsonText, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        private void WriteAccountJsonDataToFile()
        {
            string jsonString = JsonSerializer.Serialize(eventAccounts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(accountsJsonFilePath, jsonString);
        }

        private void WriteEventJsonDataToFile()
        {
            string jsonString = JsonSerializer.Serialize(eventInfos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(eventsJsonFilePath, jsonString);
        }
        private void WriteCompletedEventJsonDataToFile()
        {
            string jsonString = JsonSerializer.Serialize(eventAccounts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(completedEventsJsonFilePath, jsonString);
        }

        public int FindEventIndex(EventInfo eventInfo)
        {
            for (int i = 0; i < eventInfos.Count; i++)
            {
                if (eventInfos[i].Name == eventInfo.Name)
                {
                    return i;
                }
            }
            return -1;
        }
        public void AddAccount(EventAccount eventAccount)
        {
            eventAccounts.Add(eventAccount);
            WriteAccountJsonDataToFile();
        }

        public void AddCompletedEvent(EventAccount eventAccount)
        {
            eventAccounts.Add(eventAccount);
            WriteCompletedEventJsonDataToFile();
        }

        public void AddEvent(EventInfo eventInfo)
        {
            eventInfos.Add(eventInfo);
            WriteEventJsonDataToFile();
        }

        public List<EventAccount> GetAccounts()
        {
            return eventAccounts;
        }

        public List<string> GetCompletedEvents()
        {
            for (int i = 0; i < eventAccounts.Count; i++)
            {

                return eventAccounts[i].CompletedEvents;    

            }
            return new List<string>();
        }

        public List<EventInfo> GetEvents()
        {
            return eventInfos;
        }

        public bool RemoveEvent(EventInfo eventInfo)
        {
            int index = -1;

            for (int i = 0; i < eventInfos.Count; i++)
            {
                if (eventInfos[i].Name == eventInfo.Name &&
                    eventInfos[i].StartDate == eventInfo.StartDate &&
                    eventInfos[i].StartTime == eventInfo.StartTime &&
                    eventInfos[i].Creator == eventInfo.Creator)
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                eventInfos.RemoveAt(index);
                WriteEventJsonDataToFile();
                return true;
            }

            return false;
        }

        public void UpdateEvent(EventInfo eventInfo)
        {
            RemoveEvent(eventInfo);
            eventInfos.Add(eventInfo);
            WriteEventJsonDataToFile();
        }
    }
}
