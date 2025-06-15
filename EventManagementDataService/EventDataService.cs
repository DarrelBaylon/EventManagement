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
        TextFileDataService textFileDataService = new TextFileDataService();

        
        public List<EventInfo> info;
        private int[] months = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

        public int[] Months { get { return (int[])months.Clone(); } }

        public EventDataService()
        {
            info = new List<EventInfo>();
        }

        public List<EventAccount> GetAccounts()
        {
            return textFileDataService.GetAccounts();
        }
        public List<EventInfo> GetEvents()
        {
            return textFileDataService.GetEvents();
        }

        public List<string> GetCompletedEvents()
        {
            return textFileDataService.GetCompletedEvents();
        }

        public void addAccount(EventAccount eventAccount)
        {
            textFileDataService.AddAccount(eventAccount);
        }

        public void AddEvent(EventInfo eventInfo)
        {
            textFileDataService.AddEvent(eventInfo);
            info.Add(eventInfo); 
        }

        public void UpdateEvent(EventInfo eventInfo)
        {
            textFileDataService.UpdateEvent(eventInfo);
            info.Remove(eventInfo);
        }

        public void RemoveEvent(EventInfo eventInfo)
        {
            textFileDataService.RemoveEvent(eventInfo);
            info.Remove(eventInfo); 
        }
        public string GetEventCreator(int index)
        {
            if (index >= 0 && index < GetEvents().Count)
            {
                return GetEvents()[index].Creator;
            }
            return null;
        }
        // public int GetEventIndex(string eventName)
        //{
        //for (int i = 0; i < info.Count; i++)
        //{
        //if (info[i].Name == eventName)
        //{
        //    return textFileDataService.FindIndex(info[i]);
        //}
        //}
        // return -1;
        // }
        public bool CompleteEvent(string eventName, string eventDetails)
        {
            EventAccount eventAccount = new EventAccount
            {
                CreatedEvents = new List<string> { eventName }, 
                CompletedEvents = new List<string> { eventDetails } 
            };

            textFileDataService.AddCompletedEvent(eventAccount);
            return true;
        }
    }
}
