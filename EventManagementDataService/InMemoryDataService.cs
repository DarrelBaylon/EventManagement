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
        private List<EventAccount> accounts = new List<EventAccount>();
        private List<EventInfo> info = new List<EventInfo>();
        private List<string> completedEvents = new List<string>();
        public void AddAccount(EventAccount eventAccount)
        {
           
        }

        public void AddCompletedEvent(EventAccount eventAccount)
        {
            
        }

        public void AddEvent(EventInfo eventInfo)
        {
            
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
            return completedEvents;
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
    }
}
