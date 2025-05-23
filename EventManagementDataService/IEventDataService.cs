using EventCommon;
using System.Collections.Generic;

namespace EventManagementDataService
{
    public interface IEventDataService
    {
        List<EventAccount> Accounts { get; }
        List<EventInfo> Events { get; }

        int[] Months { get; }

        void AddEvent(string name, string startDate, string endDate, string startTime, string endTime, string creator);
        bool RemoveEvent(string eventName);
        EventAccount GetAccount(string username);
        int GetEventIndex(string eventName);
        string GetEventCreator(int index);
        void ClearUserEvents();
        bool IsDuplicateUser(string username, string phoneNumber, string email);
        void AddNewAccount(string username, string password, string phoneNumber, string email);
        bool ValidLogin(string currentUsername, string password);
        bool CompleteEvent(string eventName, string eventDetails);
    }
}
