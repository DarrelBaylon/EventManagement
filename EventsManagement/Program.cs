using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using EventCommon;
using EventManagement_BusinessDataLogic;
using EventManagementDataService;
using static System.Net.Mime.MediaTypeNames;


//Baylon, Darrel Andrew P.
//BSIT 2 - 1

//A system for managing events such as conferences, concerts, and workshops. 
//Users can CREATE, READ, UPDATE, and DELETE Events.

namespace EventsManagementSystem
{
    internal class Program
    {
        static string[] choice = new string[] { "[1] Login", "[2] Signup", "[3] Exit" };
        static string[] adminChoice = new string[] {"[1] View Events" , "[2] View History", "[3] Complete Event", "[4] Logout",
                                                    "[5] Exit"};
        static string[] events = new string[] { "[1] Create Event", "[2] View Event", "[3] Update Event",
                                                "[4] Delete Event", "[5] Logout", "[6] Exit" };
        static string currentUsername;

        static EventManagementService eventManagementProcess = new EventManagementService();
        static EventDataService eventDataService = new EventDataService();  

        static void Main(string[] args)

        {
            eventManagementProcess.ClearAllEvents();
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
                        Environment.Exit(0);
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

                foreach (var Event in events)
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
                        Environment.Exit(0);
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
                    Console.WriteLine(choice);
                }
                Console.Write("ENTER THE NUMBER OF YOUR CHOICE: ");
                int userChoice = Convert.ToByte(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        ViewEvent();
                        AdminPage();
                        break;

                    case 2:
                        ViewHistory();
                        AdminPage();
                        break;

                    case 3:
                        CompleteEvent();
                        AdminPage();
                        break;

                    case 4:
                        LoginPage();
                        break;

                    case 5:
                        Console.WriteLine("THANK YOU FOR USING OUR SYSTEM!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("NOT AN ACTION!");
                        AdminPage();
                        break;
                }
            }
            static void ViewEvent()
            {
                List<EventInfo> eventList = eventManagementProcess.GetAllEvents();

                if (eventList.Count != 0)
                {
                    Console.WriteLine("--------------------");
                    Console.WriteLine("THESE ARE THE EVENTS:");

                    for (int i = 0; i < eventList.Count; i++)
                    {
                        EventInfo currentEvent = eventList[i];

                        Console.WriteLine((i + 1) + ". " + currentEvent.Name);
                        Console.WriteLine(" Start: " + currentEvent.StartDate + " " + currentEvent.StartTime);
                        Console.WriteLine(" End: " + currentEvent.EndDate + " " + currentEvent.EndTime);
                        Console.WriteLine(" Creator: " + currentEvent.Creator);
                        Console.WriteLine("--------------------");
                    }
                }
                else
                {
                    Console.WriteLine("THERE ARE CURRENTLY NO EVENTS TO VIEW!");
                }
            }
            static void CreateEvent()
            {
                ViewEvent();
                Console.Write("Enter Event Name: ");
                string eventName = Console.ReadLine();

                if (eventName != "")
                {

                    Console.Write("Enter the MONTH (MM) which the EVENT will begin: ");
                    int startMonth = Convert.ToInt16(Console.ReadLine());

                    if (eventDataService.Months.Contains(startMonth))
                    {

                        Console.Write("Enter the DAY (DD) of the Month which the EVENT will begin: ");
                        int startDay = Convert.ToByte(Console.ReadLine());

                        if (eventManagementProcess.CheckStartDate(startMonth, startDay))
                        {

                            Console.Write("Enter the YEAR (YYYY) which the EVENT will begin: ");
                            int startYear = Convert.ToInt32(Console.ReadLine());

                            string startDate = $"{startMonth}-{startDay}-{startYear}";

                            Console.Write("Enter the MONTH (MM) which the EVENT will end: ");
                            int endMonth = Convert.ToInt16(Console.ReadLine());

                            if (eventDataService.Months.Contains(endMonth))
                            {

                                Console.Write("Enter the DAY (DD) of the Month which the EVENT will end: ");
                                int endDay = Convert.ToByte(Console.ReadLine());

                                if (eventManagementProcess.CheckEndDate(endMonth, endDay))
                                {
                                    Console.Write("Enter the YEAR (YYYY) which the EVENT will end: ");
                                    int endYear = Convert.ToInt32(Console.ReadLine());

                                    if (endYear - startYear >= 0)
                                    {
                                        string endDate = $"{endMonth}-{endDay}-{endYear}";

                                        Console.Write("Enter the TIME 24HR Format (HH:MM) which the EVENT will begin: ");
                                        string startTime = Console.ReadLine();

                                        Console.Write("Enter the TIME 24HR Format (HH:MM) which the EVENT will end: ");
                                        string endTime = Console.ReadLine();


                                        if (eventManagementProcess.CreateEvent(eventName, startDate, endDate, startTime,
                                            endTime, currentUsername))
                                        {


                                            Console.WriteLine($"SUCCESSFULLY CREATED THE EVENT: [{eventName}] by " +
                                                              $"[{currentUsername}]");
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
                List<EventInfo> eventList = eventManagementProcess.GetAllEvents();

                if (eventList.Count != 0)
                {
                    ViewEvent();
                    Console.Write("Enter the NUMBER of the EVENT that you would like to UPDATE: ");
                    string input = Console.ReadLine();

                    if (eventManagementProcess.ValidEventSelector(input, out int selectedIndex))
                    {
                        int index = selectedIndex - 1;

                        if (index >= 0 && index < eventList.Count)
                        {
                            string selectedEvent = eventList[index].Name;

                            eventManagementProcess.UpdateEvent(selectedEvent, currentUsername);

                            if (eventDataService.GetEventIndex(selectedEvent) == -1)
                            {
                                Console.Write("Enter the NEW Name for your EVENT: ");
                                string eventName = Console.ReadLine();

                                if (!string.IsNullOrWhiteSpace(eventName))
                                {
                                    Console.Write("Enter the MONTH (MM) which the EVENT will begin: ");
                                    int startMonth = Convert.ToInt16(Console.ReadLine());

                                    if (eventDataService.Months.Contains(startMonth))
                                    {
                                        Console.Write("Enter the DAY (DD) of the Month which the EVENT will begin: ");
                                        int startDay = Convert.ToByte(Console.ReadLine());

                                        if (eventManagementProcess.CheckStartDate(startMonth, startDay))
                                        {
                                            Console.Write("Enter the YEAR (YYYY) which the EVENT will begin: ");
                                            int startYear = Convert.ToInt32(Console.ReadLine());
                                            string startDate = $"{startMonth}-{startDay}-{startYear}";

                                            Console.Write("Enter the MONTH (MM) which the EVENT will end: ");
                                            int endMonth = Convert.ToInt16(Console.ReadLine());

                                            if (eventDataService.Months.Contains(endMonth))
                                            {
                                                Console.Write("Enter the DAY (DD) of the Month which the EVENT will end: ");
                                                int endDay = Convert.ToByte(Console.ReadLine());

                                                if (eventManagementProcess.CheckEndDate(endMonth, endDay))
                                                {
                                                    Console.Write("Enter the YEAR (YYYY) which the EVENT will end: ");
                                                    int endYear = Convert.ToInt32(Console.ReadLine());

                                                    if (endYear - startYear >= 0)
                                                    {
                                                        string endDate = $"{endMonth}-{endDay}-{endYear}";

                                                        Console.Write("Enter the TIME 24HR Format (HH:MM) which the EVENT will begin: ");
                                                        string startTime = Console.ReadLine();

                                                        Console.Write("Enter the TIME 24HR Format (HH:MM) which the EVENT will end: ");
                                                        string endTime = Console.ReadLine();

                                                        if (eventManagementProcess.CreateEvent(eventName, startDate, endDate,
                                                            startTime, endTime, currentUsername))
                                                        {
                                                            Console.WriteLine($"SUCCESSFULLY UPDATED EVENT FROM [{selectedEvent}] TO [{eventName}]");
                                                            Console.WriteLine($"EVENT DURATION: [{startDate} {startTime}] UNTIL [{endDate} {endTime}]");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("FAILED TO UPDATE EVENT! POSSIBLE SCHEDULE CONFLICT OR INVALID INPUT.");
                                                            Console.WriteLine("PLEASE ENTER THE NEW NAME FOR YOUR EVENT");
                                                            CreateEvent();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("END YEAR CANNOT BE EARLIER THAN START YEAR!");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("INVALID END DAY!");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("INVALID END MONTH!");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("INVALID START DAY!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("INVALID START MONTH!");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("EVENT NAME CANNOT BE EMPTY!");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"YOU ARE NOT AUTHORIZED TO UPDATE THE EVENT: [{selectedEvent}]");
                            }
                        }
                        else
                        {
                            Console.WriteLine("INVALID INDEX. PLEASE SELECT A VALID EVENT NUMBER.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("INVALID INPUT. Please enter a valid event number.");
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
                List<EventInfo> eventList = eventManagementProcess.GetAllEvents();

                if (eventList.Count != 0)
                {
                    Console.WriteLine("--------------------");
                    ViewEvent();
                    Console.WriteLine("--------------------");

                    Console.Write("Enter the NUMBER of the Event that you would like to DELETE: ");
                    string input = Console.ReadLine();

                    if (eventManagementProcess.ValidEventSelector(input, out int selectedIndex))
                    {
                        int index = selectedIndex - 1;

                        if (index >= 0 && index < eventList.Count)
                        {
                            string selectedEvent = eventList[index].Name;

                            if (eventManagementProcess.DeleteEvent(selectedEvent, currentUsername))
                            {
                                Console.WriteLine($"SUCCESSFULLY DELETED THE EVENT: [{selectedEvent}]");
                            }
                            else
                            {
                                Console.WriteLine("YOU ARE NOT AUTHORIZED TO DELETE THIS EVENT!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("INVALID EVENT NUMBER. Please select a valid number.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("INVALID INPUT! Please enter a valid event number.");
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

                            if (phoneNumber != "")
                            {
                                Console.Write("Enter Email: ");
                                string email = Console.ReadLine();

                                if (email != "")
                                {
                                    if (eventManagementProcess.DuplicateUser(username, phoneNumber, email))
                                    {
                                        Console.WriteLine("Signup failed: USERNAME, CONTACT NUMBER, or EMAIL already exists!");
                                    }
                                    else
                                    {
                                        eventManagementProcess.RegisterAccounts(username, password, phoneNumber, email);
                                        Console.WriteLine("ACCOUNT CREATED SUCCESSFULLY!");
                                        foreach (var acc in eventDataService.accounts)
                                        {
                                            Console.WriteLine($"Username: {acc.Username}, Email: {acc.Email}");
                                        }
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
                            if (eventManagementProcess.ValidLogIn(currentUsername, password))
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
            static void CompleteEvent()
            {
                List<EventInfo> eventList = eventManagementProcess.GetAllEvents();

                if (eventList.Count == 0)
                {
                    Console.WriteLine("THERE ARE CURRENTLY NO EVENTS!");
                    AdminPage();
                }
                else
                {
                    ViewEvent();

                    Console.Write("Enter the NUMBER of the EVENT to mark as COMPLETE: ");
                    string input = Console.ReadLine();

                    if (eventManagementProcess.ValidEventSelector(input, out int selectedIndex))
                    {
                        int index = selectedIndex - 1;

                        if (index >= 0 && index < eventList.Count)
                        {
                            string eventName = eventList[index].Name;

                            if (eventManagementProcess.EventCompleter(eventName))
                            {
                                Console.WriteLine("EVENT successfully marked as COMPLETED.");
                                ViewEvent(); 
                            }
                            else
                            {
                                Console.WriteLine("FAILED to complete the event. Please try again.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("INVALID EVENT NUMBER. Please select a valid number.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("INVALID INPUT. Please enter a valid event number.");
                    }
                }
            }
            static void ViewHistory()
            {
                List<EventAccount> getAllEvents = eventManagementProcess.GetCompletedEvents();
                Console.WriteLine("--------------------");

                foreach (var account in eventDataService.accounts)
                {
                    if (getAllEvents.Count == 0)
                    {
                        Console.WriteLine($"No completed events for account: {account.Username}");
                    }
                    else
                    {
                        Console.WriteLine($"Completed events for account: {account.Username}");
                        foreach (var completedEvent in account.CompletedEvents)
                        {
                            Console.WriteLine(completedEvent); 
                        }
                    }
                }
                if (eventDataService.accounts.All(account => account.CompletedEvents.Count == 0))
                {
                    Console.WriteLine("THERE ARE CURRENTLY NO EVENTS THAT ARE MARKED AS COMPLETED!");
                }
            }
        }
    }
}


