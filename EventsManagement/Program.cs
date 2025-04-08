using System;
using System.Collections.Generic;
using EventManagement_BusinessDataLogic;
using static System.Net.Mime.MediaTypeNames;


//Baylon, Darrel Andrew P.
//BSIT 2 - 1

//A system for managing events such as conferences, concerts, and workshops. 
//Users can CREATE, READ, UPDATE, and DELETE Events.

namespace EventsManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DisplayEvents();

        }
        static void DisplayEvents()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("Welcome to EVENT MANAGEMENT SYSTEM!");

            foreach (var Event in EventManagementProcess.events)
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
                    DisplayEvents();
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
                    DisplayEvents();
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
                    Console.WriteLine("--------------------");
                    Console.WriteLine($"Event: {EventManagementProcess.eventList[i]}");
                    Console.WriteLine($"Start Date: {EventManagementProcess.eventStartDates[i]}");
                    Console.WriteLine($"Start Time: {EventManagementProcess.eventStartTimes[i]}");
                    Console.WriteLine($"End Date: {EventManagementProcess.eventEndDates[i]}");
                    Console.WriteLine($"End Time: {EventManagementProcess.eventEndTimes[i]}");
                }
            }
            else
            {
                Console.WriteLine("THERE ARE CURRENTLY NO EVENTS TO VIEW!");
            }
        }
        static void CreateEvent()
        {
            Console.Write("Enter Event Name: ");
            string eventName = Console.ReadLine();

            if (eventName != "")
            {

                Console.Write("Enter the MONTH (MM) which the EVENT will begin: ");
                string startMonth = Console.ReadLine().ToUpper();

                if (EventManagementProcess.months.Contains(startMonth))
                {

                    Console.Write("Enter the DAY (DD) of the Month which the EVENT will begin: ");
                    int startDay = Convert.ToByte(Console.ReadLine());

                    if (EventManagementProcess.CheckStartDate(startMonth,startDay))
                    {

                        Console.Write("Enter the YEAR (YYYY) which the EVENT will begin: ");
                        int startYear = Convert.ToInt32(Console.ReadLine());

                        string startDate = $"{startMonth}-{startDay}-{startYear}";

                        Console.Write("Enter the MONTH (MM) which the EVENT will end: ");
                        string endMonth = Console.ReadLine().ToUpper();

                        if (EventManagementProcess.months.Contains(endMonth))
                        {

                            Console.Write("Enter the DAY (DD) of the Month which the EVENT will end: ");
                            int endDay = Convert.ToByte(Console.ReadLine());

                            if (EventManagementProcess.CheckEndDate(endMonth, endDay))
                            {
                                Console.Write("Enter the YEAR (YYYY) which the EVENT will end: ");
                                int endYear = Convert.ToInt32(Console.ReadLine());

                                if (endYear - startYear >= 0)
                                {

                                    string endDate = $"{endMonth}-{endDay}-{endYear}";

                                    Console.Write("Enter the TIME (HH:MM AM/PM) which the EVENT will begin: ");
                                    string startTime = Console.ReadLine();

                                    Console.Write("Enter the TIME (HH:MM AM/PM) which the EVENT will end: ");
                                    string endTime = Console.ReadLine();

                                    if (EventManagementProcess.CreateEvent(eventName, startDate, endDate, startTime, endTime))
                                    {
                                        Console.WriteLine($"SUCCESSFULLY CREATED THE EVENT: [{eventName}]");
                                    }
                                    else
                                    {
                                        Console.WriteLine("THERE IS A CONFLICT WITH THE SCHEDULE!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("END YEAR CANNOT BE EARLIER THAN START YEAR!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("INVALID DAY!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("INVALID MONTH!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("INVALID DAY!");
                    }
                }

                else
                {
                    Console.WriteLine("INVALID MONTH!");
                }
            }
            else
            {
                Console.WriteLine("EVENT NAME CANNOT BE NULL!");
            }
                DisplayEvents();
        }

        static void UpdateEvent()
        {
            if (EventManagementProcess.eventList.Count() != 0)
            {
                Console.WriteLine("--------------------");
                ViewEvent();
                Console.WriteLine("--------------------");
                Console.Write("Enter the Event Name that you would like to UPDATE: ");
                string updateEventBefore = Console.ReadLine();

                if (!EventManagementProcess.UpdateEvent(updateEventBefore))
                {
                    Console.WriteLine($"THIS EVENT: [{updateEventBefore}] DOES NOT EXIST!");
                }
                else
                {
                    Console.Write("Enter the NEW Name for your EVENT: ");
                    string eventName = Console.ReadLine();

                    if (eventName != "")
                    {



                        Console.Write("Enter the MONTH (MM) which the EVENT will begin: ");
                        string startMonth = Console.ReadLine().ToUpper();

                        if (EventManagementProcess.months.Contains(startMonth))
                        {

                            Console.Write("Enter the DAY (DD) of the Month which the EVENT will begin: ");
                            int startDay = Convert.ToByte(Console.ReadLine());

                            if(EventManagementProcess.CheckStartDate(startMonth, startDay))
                                {

                                Console.Write("Enter the YEAR (YYYY) which the EVENT will begin: ");
                                int startYear = Convert.ToInt32(Console.ReadLine());

                                string startDate = $"{startMonth}-{startDay}-{startYear}";

                                Console.Write("Enter the MONTH (MM) which the EVENT will end: ");
                                string endMonth = Console.ReadLine().ToUpper();


                                if (EventManagementProcess.months.Contains(endMonth))
                                {

                                    Console.Write("Enter the DAY (DD) of the Month which the EVENT will end: ");
                                    int endDay = Convert.ToByte(Console.ReadLine());

                                    if (EventManagementProcess.CheckEndDate(endMonth, endDay))
                                    {
                                        Console.Write("Enter the YEAR (YYYY) which the EVENT will end: ");
                                        int endYear = Convert.ToInt32(Console.ReadLine());

                                        if (endYear - startYear >= 0)
                                        {
                                            string endDate = $"{endMonth}-{endDay}-{endYear}";

                                            Console.Write("Enter the TIME (HH:MM AM/PM) which the EVENT will begin: ");
                                            string startTime = Console.ReadLine();

                                            Console.Write("Enter the TIME (HH:MM AM/PM) which the EVENT will end: ");
                                            string endTime = Console.ReadLine();

                                            EventManagementProcess.CreateEvent(eventName, startDate, endDate, startTime,
                                                                               endTime);

                                            Console.WriteLine($"SUCCESSFULLY UPDATED EVENT FROM [{updateEventBefore}] TO " +
                                                                $"[{eventName}]");
                                            Console.WriteLine($"EVENT DURATION: [{startDate} {startTime}] UNTIL " +
                                                                $"[{endDate} {endTime}]");
                                        }
                                        else
                                        {
                                            Console.WriteLine("END YEAR CANNOT BE EARLIER THAN START YEAR!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("INVALID DAY!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("INVALID MONTH!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("INVALID DAY!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("INVALID MONTH!");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("THERE ARE CURRENTLY NO EVENTS TO UPDATE!");
            }
            DisplayEvents();
        }
        static void DeleteEvent()
        {
            if (EventManagementProcess.eventList.Count() != 0)
            {
                Console.WriteLine("--------------------");
                ViewEvent();
                Console.WriteLine("--------------------");
                Console.Write("Enter the Event Name that you would like to DELETE: ");
                string deleteEvent = Console.ReadLine();

                if (!EventManagementProcess.DeleteEvent(deleteEvent))
                {
                    Console.WriteLine("THIS EVENT DOES NOT EXIST!");
                }
                else
                {
                    Console.WriteLine($"SUCCESSFULLY DELETED THE EVENT: [{deleteEvent}]");
                }
            }
            else
            {
                Console.WriteLine("THERE ARE CURRENTLY NO EVENTS TO DELETE!");
            }
            DisplayEvents();
        }        
        
    }
}