using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
        static string[] choice = new string[] { "[1] Login", "[2] Signup", "[3] Exit"};
        static string[] adminChoice = new string[] {"[1] View Events" , "[2] View History", "[3] Exit"};
        static string currentUsername;

        static void Main(string[] args)
        {
            LoginPage();
            static void LoginPage()
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Welcome to EVENT MANAGEMENT SYSTEM!");
                foreach (var choice in choice)
                {
                    Console.WriteLine(choice);
                }
                Console.Write("ENTER THE NUMBER OF YOUR CHOICE: ");
                int userChoice = Convert.ToByte(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        UserLogin();
                        break;

                    case 2:
                        Signup();
                        LoginPage();
                        break;

                    case 3:
                        Console.WriteLine("THANK YOU FOR USING OUR SYSTEM!");
                        break;

                    default:
                        Console.WriteLine("NOT AN ACTION!");
                        LoginPage();
                        break;
                }
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
                int userEvent = Convert.ToByte(Console.ReadLine());

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
                        LoginPage();
                        break;

                    case 6:
                        Console.WriteLine("THANK YOU FOR USING OUR SYSTEM!");
                        break;

                    //for error handling
                    default:
                        Console.WriteLine("NOT AN EVENT ACTION");
                        DisplayEvents();
                        break;
                }
            }
            static void AdminPage()
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Welcome to EVENT MANAGEMENT SYSTEM!");
                foreach (var choice in adminChoice)
                {
                    Console.WriteLine(adminChoice);
                }
                Console.Write("ENTER THE NUMBER OF YOUR CHOICE: ");
                int userChoice = Convert.ToByte(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        ViewEvent();
                        //ViewAdminEvent();
                        break;

                    case 2:
                        //History();
                        break;

                    case 3:
                        Console.WriteLine("THANK YOU FOR USING OUR SYSTEM!");
                        break;

                    default:
                        Console.WriteLine("NOT AN ACTION!");
                        LoginPage();
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
                        Console.WriteLine($"Created By: {EventManagementProcess.eventCreators[i]}");
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
                    int startMonth = Convert.ToInt16(Console.ReadLine());

                    if (EventManagementProcess.months.Contains(startMonth))
                    {

                        Console.Write("Enter the DAY (DD) of the Month which the EVENT will begin: ");
                        int startDay = Convert.ToByte(Console.ReadLine());

                        if (EventManagementProcess.CheckStartDate(startMonth, startDay))
                        {

                            Console.Write("Enter the YEAR (YYYY) which the EVENT will begin: ");
                            int startYear = Convert.ToInt32(Console.ReadLine());

                            string startDate = $"{startMonth}-{startDay}-{startYear}";

                            Console.Write("Enter the MONTH (MM) which the EVENT will end: ");
                            int endMonth = Convert.ToInt16(Console.ReadLine());

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

                                        if (EventManagementProcess.CreateEvent(eventName, startDate, endDate, startTime, endTime, currentUsername))
                                        {

                                            
                                            Console.WriteLine($"SUCCESSFULLY CREATED THE EVENT: [{eventName}] by [{currentUsername}]");
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

                    if (!EventManagementProcess.UpdateEvent(updateEventBefore, currentUsername))
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
                            int startMonth = Convert.ToInt16(Console.ReadLine());

                            if (EventManagementProcess.months.Contains(startMonth))
                            {

                                Console.Write("Enter the DAY (DD) of the Month which the EVENT will begin: ");
                                int startDay = Convert.ToByte(Console.ReadLine());

                                if (EventManagementProcess.CheckStartDate(startMonth, startDay))
                                {

                                    Console.Write("Enter the YEAR (YYYY) which the EVENT will begin: ");
                                    int startYear = Convert.ToInt32(Console.ReadLine());

                                    string startDate = $"{startMonth}-{startDay}-{startYear}";

                                    Console.Write("Enter the MONTH (MM) which the EVENT will end: ");
                                    int endMonth = Convert.ToInt16(Console.ReadLine());


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
                                                                                   endTime, currentUsername);

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

                    if (!EventManagementProcess.DeleteEvent(deleteEvent, currentUsername))
                    {
                        Console.WriteLine("THIS EVENT DOES NOT EXIST ON YOUR ACCOUNT!");
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
            static void Signup()
            {
                Console.Write("Enter Username: ");
                string username = Console.ReadLine();

                if (username != "")
                {
                    Console.Write("Enter Password: ");
                    string password = Console.ReadLine();

                    if (password != "")
                    {
                        Console.Write("Enter Age: ");
                        string age = Console.ReadLine();

                        if (age != "")
                        {
                            Console.Write("Enter Contact Number: ");
                            string phoneNumber = Console.ReadLine();

                            if(phoneNumber != "")
                            { 
                                Console.Write("Enter Email: ");
                                string email = Console.ReadLine();

                                if(email != "")
                                {
                                    string users = $"{username},{password},{age},{phoneNumber},{email}";

                                    if (EventManagementProcess.DuplicateUser(username, phoneNumber, email))
                                    {
                                        Console.WriteLine("Signup failed: USERNAME, CONTACT NUMBER, or EMAIL already exists!");
                                    }
                                    else
                                    {
                                        EventManagementProcess.usersList.Add(users);
                                        Console.WriteLine("ACCOUNT CREATED SUCCESSFULLY!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("EMAIL Cannot be NULL!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("CONTACT NUMBER Cannot be NULL!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("AGE Cannot be NULL!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("PASSWORD Cannot be NULL!");
                    }
                }
                else
                {
                    Console.WriteLine("USERNAME Cannot be NULL!");
                }
            }
            static void UserLogin()
            {
                Console.Write("Enter Username: ");
                currentUsername = Console.ReadLine();

                if (currentUsername != null)
                {
                    Console.Write("Enter Password: ");
                    string password = Console.ReadLine();
                    if (password != null)
                    {
                        if (currentUsername == "admin" && password == "admin123")
                        {
                        AdminPage();
                        }
                        else
                        {
                            if (EventManagementProcess.ValidLogin(currentUsername, password))
                            {

                            Console.WriteLine("Login successful!");
                            DisplayEvents();
                            }
                            else
                            {
                            Console.WriteLine("Invalid USERNAME or PASSWORD!");
                            LoginPage();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("PASSWORD Cannot be NULL!");
                        LoginPage();
                    }
                }
                else
                {
                    Console.WriteLine("USERNAME Cannot be NULL!");
                    LoginPage();
                }
            }
        }
    }
}

