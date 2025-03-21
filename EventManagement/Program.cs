using System;

//Baylon, Darrel Andrew P.
//BSIT 2 - 1

//A system for managing events such as conferences, concerts, and workshops. 
//Users can CREATE, READ, UPDATE, and DELETE Events.

namespace EventManagementSystem
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
                //I plan to use arrayList in this case, however idk how
                //in the meantime it will be just this
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
            //a}
        }

        static void CreateEvent()
        {
            Console.Write("Enter Event Name: ");
            string eventName = Console.ReadLine();

            Console.WriteLine($"SUCCESSFULLY CREATED THE EVENT: {eventName}");
            DisplayEvents();
        }
        static void ViewEvent()
        {
            Console.WriteLine("THESE ARE THE EVENTS");
            Console.WriteLine("THIS SECTION IS STILL UNDER DEVELOPMENT");
            DisplayEvents();
        }
        static void UpdateEvent()
        {
            Console.Write("Enter the Event Name that you would like to UPDATE: ");
            string updateEventBefore = Console.ReadLine();

            Console.Write("Enter the NEW Name for your EVENT: ");
            string updateEventCurrent = Console.ReadLine();

            Console.WriteLine($"SUCCESSFULLY UPDATED THE EVENT FROM [{updateEventBefore}] INTO [{updateEventCurrent}]");
            Console.WriteLine("THIS SECTION IS STILL UNDER DEVELOPMENT");
            DisplayEvents();
        }
        static void DeleteEvent()
        {
            Console.Write("Enter the Event Name that you would like to DELETE: ");
            string deleteEvent = Console.ReadLine();
            Console.WriteLine($"SUCCESSFULLY DELETED THE EVENT: {deleteEvent}");
            Console.WriteLine("THIS SECTION IS STILL UNDER DEVELOPMENT");
            DisplayEvents();

        }
    }
}