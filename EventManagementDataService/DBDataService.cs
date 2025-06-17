using EventCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementDataService
{
    class DBDataService : IEventDataService
    {

        public void AddAccount(EventAccount eventAccount)
        {
            throw new NotImplementedException();
        }

        public void AddCompletedEvent(EventAccount eventAccount)
        {
            throw new NotImplementedException();
        }

        public void AddEvent(EventInfo eventInfo)
        {
            throw new NotImplementedException();
        }

        public int FindEventIndex(EventInfo eventInfo)
        {
            throw new NotImplementedException();
        }

        public List<EventAccount> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public List<string> GetCompletedEvents()
        {
            throw new NotImplementedException();
        }

        public List<EventInfo> GetEvents()
        {
            throw new NotImplementedException();
        }

        public bool RemoveEvent(EventInfo eventInfo)
        {
            throw new NotImplementedException();
        }

        public void UpdateEvent(EventInfo eventInfo)
        {
            throw new NotImplementedException();
        }
    }
}
