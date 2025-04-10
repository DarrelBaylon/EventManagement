﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement_BusinessDataLogic
{
    public class EventManagementProcess
    {

        public static List<string> eventList = new List<string>();
        public static List<string> eventStartDates = new List<string>();
        public static List<string> eventEndDates = new List<string>();
        public static List<string> eventStartTimes = new List<string>();
        public static List<string> eventEndTimes = new List<string>();
        public static List<EventAccount> Accounts = new List<EventAccount>();
        public static List<string> eventCreators = new List<string>();

        public static string[] events = new string[] { "[1] Create Event", "[2] View Event", "[3] Update Event",
                                                "[4] Delete Event", "[5] Logout", "[6] Exit" };
        public static int[] months = new int[] {1,2,3,4,5,6,7,8,9,10,11,12};
        static int[] monthsWith31Days = new int[] {1,3,5,7,8,10,12};
        static int[] monthsWith30Days = new int[] { 4,6,9,11};
        static int[] monthsWith28Days = new int[] { 2 };



        public static bool UpdateEvent(string eventName, string currentUsername)
        {
            EventAccount account = null;

            foreach (EventAccount acc in Accounts)
            {
                if (acc.Username == currentUsername)
                {
                    account = acc;
                    break;
                }
            }
            if (account == null)
            {
                return false;  
            }
            if (account.CreatedEvents.Contains(eventName))
            {
                int index = eventList.IndexOf(eventName);

                if (index != -1 && eventCreators[index] == currentUsername)
                {
                    eventList.RemoveAt(index);
                    eventStartDates.RemoveAt(index);
                    eventEndDates.RemoveAt(index);
                    eventStartTimes.RemoveAt(index);
                    eventEndTimes.RemoveAt(index);
                    eventCreators.RemoveAt(index);

                    account.CreatedEvents.Remove(eventName);
                    account.CreatedEvents.Add(eventName); 

                    return true;
                }
            }
            return false;
        }
        public static bool CreateEvent(string eventName, string startDate, string endDate, string startTime, string endTime, 
                                       string currentUsername)
        {
            EventAccount account = null;

            foreach (EventAccount acc in Accounts)
            {
                if (acc.Username == currentUsername)
                {
                    account = acc;
                    break;
                }
            }
            if (account == null)
            {
                return false; 
            }
            if (!CheckScheduleConflict(startDate, endDate, startTime, endTime))
            {
                return false;
            }
            account.CreatedEvents.Add(eventName);
            eventList.Add(eventName); 
            eventStartDates.Add(startDate); 
            eventEndDates.Add(endDate); 
            eventStartTimes.Add(startTime); 
            eventEndTimes.Add(endTime);
            eventCreators.Add(currentUsername);
            return true;
        }

        public static bool DeleteEvent(string eventName, string currentUsername)
        {
            EventAccount account = null;
            foreach (EventAccount acc in Accounts)
            {
                if (acc.Username == currentUsername)
                {
                    account = acc;
                    break;
                }
            }
            if (account == null)
            {
                return false;
            }
            if (account.CreatedEvents.Contains(eventName))
            {
                int index = eventList.IndexOf(eventName);

                if (index != -1 && eventCreators[index] == currentUsername)
                {
                    eventList.RemoveAt(index);
                    eventStartDates.RemoveAt(index);
                    eventEndDates.RemoveAt(index);
                    eventStartTimes.RemoveAt(index);
                    eventEndTimes.RemoveAt(index);
                    eventCreators.RemoveAt(index);
                    account.CreatedEvents.Remove(eventName);
                    return true;
                }
            }
            return false;
        }
        public static bool CheckScheduleConflict(string newStartDate, string newEndDate, string newStartTime, 
                                                 string newEndTime)
        {
            DateTime newStart = DateTime.Parse($"{newStartDate} {newStartTime}");
            DateTime newEnd = DateTime.Parse($"{newEndDate} {newEndTime}");

            for (int i = 0; i < eventList.Count; i++)
            {
                DateTime existingStart = DateTime.Parse($"{eventStartDates[i]} {eventStartTimes[i]}");
                DateTime existingEnd = DateTime.Parse($"{eventEndDates[i]} {eventEndTimes[i]}");

                if (newStart < existingEnd && newEnd > existingStart)
                {
                    return false;
                }
            }

            return true;
        }
        public static bool CheckStartDate(int startMonth, int startDay)
        {
            if (monthsWith31Days.Contains(startMonth) && startDay >= 1 && startDay <= 31 ||
            monthsWith30Days.Contains(startMonth) && startDay >= 1 && startDay <= 30 ||
            monthsWith28Days.Contains(startMonth) && startDay >= 1 && startDay <= 28)
            {
                return true;
            }
            return false;
        }
        public static bool CheckEndDate(int endMonth, int endDay)
        {
            if (monthsWith31Days.Contains(endMonth) && endDay >= 1 && endDay <= 31 ||
            monthsWith30Days.Contains(endMonth) && endDay >= 1 && endDay <= 30 ||
            monthsWith28Days.Contains(endMonth) && endDay >= 1 && endDay <= 28)
            {
                return true;
            }
            return false;
        }
        public static bool DuplicateUser(string username, string phoneNumber, string email)
        {
            foreach (EventAccount account in Accounts)
            {
                if (account.Username == username || account.PhoneNumber == phoneNumber || account.Email == email)
                    return true;
            }
            return false;
        }
        public static bool ValidLogin(string currentUsername, string password)
        {
            foreach (EventAccount account in Accounts)
            {
                if (account.Username == currentUsername && account.Password == password)
                    return true;
            }
            return false;
        }
        public static bool EventCompleter(string eventName)
        {
            int index = eventList.IndexOf(eventName);

            if (index != -1)
            {
                string completedEvent = "Event Name: " + eventList[index] +
                                        ", Start: " + eventStartDates[index] + " " + eventStartTimes[index] +
                                        ", End: " + eventEndDates[index] + " " + eventEndTimes[index] +
                                        ", Created by: " + eventCreators[index];

                foreach (var account in Accounts)
                {
                    
                        account.CompletedEvents.Add(completedEvent);

                        eventList.RemoveAt(index);
                        eventStartDates.RemoveAt(index);
                        eventEndDates.RemoveAt(index);
                        eventStartTimes.RemoveAt(index);
                        eventEndTimes.RemoveAt(index);
                        eventCreators.RemoveAt(index);

                        return true;
                    
                }
                return false;
            }
            return false;
        }
        public static void ClearAllEvents()
        {
            foreach (EventAccount account in Accounts)
            {
                account.CreatedEvents.Clear();
                account.CompletedEvents.Clear();
            }
        }
        public static bool ValidEventSelector(string input, out int selectedIndex)
        {
            return int.TryParse(input, out selectedIndex) && selectedIndex >= 1 && selectedIndex <= eventList.Count;
        } 
    }
}
