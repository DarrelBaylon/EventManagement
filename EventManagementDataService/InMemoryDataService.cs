using EventCommon;

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
