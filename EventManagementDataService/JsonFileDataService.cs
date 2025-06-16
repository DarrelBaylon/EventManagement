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
        static List<EventAccount> eventAccounts = new List<EventAccount>();
        static List<EventInfo> eventInfos = new List<EventInfo>();
        static List<string> completedEvents = new List<string>();

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
            string jsonText = File.ReadAllText(completedEventsJsonFilePath);

            completedEvents = JsonSerializer.Deserialize<List<String>>
                           (jsonText, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public void AddAccount(EventAccount eventAccount)
        {
            eventAccounts.Add(eventAccount);
            //WriteJsonDataToFile();
        }

        public void AddCompletedEvent(EventAccount eventAccount)
        {
            throw new NotImplementedException();
        }

        public void AddEvent(EventInfo eventInfo)
        {
            throw new NotImplementedException();
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
                //WriteEventDataToFile();
                return true;
            }

            return false;
        }

        public void UpdateEvent(EventInfo eventInfo)
        {
            RemoveEvent(eventInfo);
            eventInfos.Add(eventInfo);
            //WriteEventDataToFile();
        }
    }
}
