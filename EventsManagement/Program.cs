using System;
using System.Collections.Generic;
using EventManagement_BusinessDataLogic;


//Baylon, Darrel Andrew P.
//BSIT 2 - 1

//A system for managing events such as conferences, concerts, and workshops. 
//Users can CREATE, READ, UPDATE, and DELETE Events.

namespace EventsManagementSystem
{
    internal class Program
    {
        static string[] events = new string[] { "[1] Create Event", "[2] View Event", "[3] Update Event", "[4] Delete Event", "[5] Exit" };
        static void Main(string[] args)
        {

            DisplayEvents();

        }
        static void DisplayEvents()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine("Welcome to EVENT MANAGEMENT SYSTEM!");

            foreach (var Event in events)
            {
                Console.WriteLine(Event);
            }

            Console.Write("Choose an Event: ");
            int userEvent = Convert.ToInt16(Console.ReadLine());

            switch (userEvent)
            {
                //this is a CASE statement for CREATING an Event
                case 1:
                    CreateEvent();
                    break;

                //this is a CASE statement for VIEWING events
                case 2:
                    ViewEvent();
                    break;

                //this is a CASE statement for UPDATING events
                case 3:
                    UpdateEvent();
                    break;

                //this is a CASE statement for DELETING events
                case 4:
                    DeleteEvent();
                    break;

                //this is a CASE statement for EXITING the SYSTEM
                case 5:
                    Console.WriteLine("THANK YOU FOR USING OUR SYSTEM!");
                    break;

                //for error handling
                default:
                    Console.WriteLine("NOT AN EVENT ACTION");
                    break;
            }
        }
        static void ViewEvent()
        {
            if (EventManagementProcess.eventList.Count() != 0)
            {
             
                Console.WriteLine("THESE ARE THE EVENTS");
                for (int i = 0; i < EventManagementProcess.eventList.Count; i++)
                {
                    Console.WriteLine($"Event: {EventManagementProcess.eventList[i]}");
                    Console.WriteLine($"Start Date: {EventManagementProcess.eventStartDates[i]}");
                    Console.WriteLine($"End Date: {EventManagementProcess.eventEndDates[i]}");
                    Console.WriteLine("-------------------------");
                }
                DisplayEvents();
            }
            else
            {
                Console.WriteLine("THERE ARE CURRENTLY NO EVENTS");
                DisplayEvents();
            }
        }
        static void CreateEvent()
        {
            
            Console.Write("Enter Event Name: ");
            string eventName = Console.ReadLine();

            Console.Write("Enter Start Date (MM-DD-YYYY): ");
            string startDate = Console.ReadLine();

            Console.Write("Enter End Date (MM-DD-YYYY): ");
            string endDate = Console.ReadLine();

            EventManagementProcess.CreateEvent(eventName, startDate, endDate);
            Console.WriteLine($"SUCCESSFULLY CREATED THE EVENT: {eventName}");
            DisplayEvents();
            
        }
        static void UpdateEvent()
        {
            Console.Write("Enter the Event Name that you would like to UPDATE: ");
            string updateEventBefore = Console.ReadLine();

            if (!EventManagementProcess.UpdateEvent(updateEventBefore))
            {
                Console.WriteLine($"THIS EVENT: [{updateEventBefore}] DOES NOT EXIST!");
                DisplayEvents();
            }
            else
            {
                Console.Write("Enter the NEW Name for your EVENT: ");
                string eventList = Console.ReadLine();

                Console.Write("Enter the NEW StartDate for your EVENT (MM-DD-YYYY): ");
                string startDate = Console.ReadLine();

                Console.Write("Enter the NEW EndDate for your EVENT (MM-DD-YYYY): ");
                string endDate = Console.ReadLine();

                EventManagementProcess.CreateEvent(eventList, startDate, endDate);

                Console.WriteLine($"SUCCESSFULLY UPDATED EVENT FROM {updateEventBefore} TO " +
                                    $"{eventList}");
                Console.WriteLine($"EVENT DURATION: {startDate} - " +
                                    $"{endDate}");
                DisplayEvents();
            }
        }
        static void DeleteEvent()
        {
            Console.Write("Enter the Event Name that you would like to DELETE: ");
            string deleteEvent = Console.ReadLine();

            if (!EventManagementProcess.DeleteEvent(deleteEvent))
            {
                Console.WriteLine("THIS EVENT DOES NOT EXIST!");
                DisplayEvents();
            }
            else
            {
                Console.WriteLine($"SUCCESSFULLY DELETED THE EVENT: {deleteEvent}");
                DisplayEvents();
            }
        }
    }
}