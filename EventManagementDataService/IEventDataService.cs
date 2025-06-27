using EventCommon;

namespace EventManagementDataService
{
    public interface IEventDataService
    {
        public List<EventAccount> GetAccounts();
        public List<EventInfo> GetEvents();
        public List<String> GetCompletedEvents();
        public void AddAccount(EventAccount eventAccount);
        public void AddEvent(EventInfo eventInfo);
        public bool RemoveEvent(EventInfo eventInfo);
        public void UpdateEvent(EventInfo eventInfo);
        public void AddCompletedEvent(EventAccount eventAccount);
        public int FindEventIndex(EventInfo eventInfo);
    }
}
