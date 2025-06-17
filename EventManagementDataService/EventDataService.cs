using EventCommon;

namespace EventManagementDataService
{
    public class EventDataService
    {
        IEventDataService eventDataService;

        public EventDataService()
        {
            eventDataService = new TextFileDataService();
            //eventDataService = new InMemoryDataService();
            //eventDataService = new JsonFileDataService();
            info = new List<EventInfo>();
        }
        public List<EventInfo> info;
        private int[] months = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

        public int[] Months { get { return (int[])months.Clone(); } }

       

        public List<EventAccount> GetAccounts()
        {
            return eventDataService.GetAccounts();
        }
        public List<EventInfo> GetEvents()
        {
            return eventDataService.GetEvents();
        }

        public List<String> GetCompletedEvents()
        {
            return eventDataService.GetCompletedEvents();
        }

        public void addAccount(EventAccount eventAccount)
        {
            eventDataService.AddAccount(eventAccount);
        }

        public void AddEvent(EventInfo eventInfo)
        {
            eventDataService.AddEvent(eventInfo);
            info.Add(eventInfo); 
        }

        public void UpdateEvent(EventInfo eventInfo)
        {
            eventDataService.UpdateEvent(eventInfo);
            info.Remove(eventInfo);
        }

        public void RemoveEvent(EventInfo eventInfo)
        {
            eventDataService.RemoveEvent(eventInfo);
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
        public int GetEventIndex(EventInfo eventInfo)
        {
            return eventDataService.FindEventIndex(eventInfo);
        }
        public bool CompleteEvent(string eventName, string eventDetails)
        {
            EventAccount eventAccount = new EventAccount
            {
                CreatedEvents = new List<string> { eventName }, 
                CompletedEvents = new List<string> { eventDetails } 
            };

            eventDataService.AddCompletedEvent(eventAccount);
            return true;
        }
    }
}
