using System;

//Baylon, Darrel Andrew P.
//BSIT 2 - 1

//A system for managing events such as conferences, concerts, and workshops. 
//Users can CREATE, READ, UPDATE, and DELETE Events.

namespace EventManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to EVENT MANAGEMENT SYSTEM!");

            string[] events = new string[] { "[1] Create Event", "[2] View Event", "[3] Update Event", "[4] Delete Event", "[5] Exit" };

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
                    Console.Write("Enter Event NAME: ");
                    string eventName = Console.ReadLine();
                    break;

                //this is a CASE statement for VIEWING events
                //I plan to use arrayList in this case, however idk how
                //in the meantime it will be just this
                case 2:
                    Console.Write("UNFINISHED");
                    break;

                //this is a CASE statement for UPDATING events
                case 3:
                    Console.Write("Enter The Event to UPDATE: ");
                    string updateEvent = Console.ReadLine();
                    break;

                //this is a CASE statement for DELETING events
                case 4:
                    Console.Write("Enter the Event to DELETE: ");
                    string deleteEvent = Console.ReadLine();
                    break;

                //this is a CASE statement for EXITING the SYSTEM
                case 5:
                    Console.WriteLine("THANK YOU FOR USING OUR SYSTEM!");
                    break;

                //for error handling
                default:  
                    Console.WriteLine("NOT AN ACTION");
                    break;

            }
        }
    }
}