using EventCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementDataService
{


    public class InMemoryDataService : IEventDataService
    {
        public List<EventAccount> accounts { get; private set; } = new List<EventAccount>();
        public List<EventInfo> info { get; private set; } = new List<EventInfo>();
        private List<string> completedEvents = new List<string>();

        public void AddAccount(EventAccount eventAccount)
        {
           accounts.Add(eventAccount);
        }

        public void AddCompletedEvent(EventAccount eventAccount)
        {
           accounts.Add(eventAccount);
        }

        public void AddEvent(EventInfo eventInfo)
        {
            info.Add(eventInfo);
        }

        public List<EventAccount> GetAccounts()
        {
           return accounts;
        }

        public List<EventInfo> GetEvents()
        {
            return info;
        }

        public List<string> GetCompletedEvents()
        {
            for (int i = 0; i < accounts.Count; i++)
            {

                return accounts[i].CompletedEvents;

            }
            return new List<string>();
        }

        public bool RemoveEvent(EventInfo eventInfo)
        {
            for (int i = 0; i < info.Count; i++)
            {
                if (info[i].Name == eventInfo.Name)
                {
                    info.RemoveAt(i);
                    return true; 
                }
            }
            return false;
        }

        public void UpdateEvent(EventInfo eventInfo)
        {
            for (int i = 0; i < info.Count; i++)
            {
                if (info[i].Name == eventInfo.Name)
                {
                    info[i].StartDate = eventInfo.StartDate;
                    info[i].EndDate = eventInfo.EndDate;
                    info[i].StartTime = eventInfo.StartTime;
                    info[i].EndTime = eventInfo.EndTime;
                    info[i].Creator = eventInfo.Creator;
                    return;
                }
            }
        }

        public int FindEventIndex(EventInfo eventInfo)
        {
            for (int i = 0; i < info.Count; i++)
            {
                if (info[i].Name == eventInfo.Name)
                {
                    return i;
                }
            }
            return -1; 
        }
    }
}
