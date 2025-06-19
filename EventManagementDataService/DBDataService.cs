using EventCommon;
using Microsoft.Data.Sql;
using Microsoft.Data.SqlClient; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementDataService
{
    class DBDataService : IEventDataService
    {
        static string connectionString
            = "Data Source =DESKTOP-RBGBVQ7\\SQLEXPRESS; Initial Catalog = " +
              "Event; Integrated Security = True; TrustServerCertificate=True;";

        static SqlConnection sqlConnection;

        public DBDataService()
        {
            sqlConnection = new SqlConnection(connectionString);
        }
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
            string selectStatement = "SELECT AccountName, Password, Email, PhoneNumber FROM EventAccount";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var eventAccounts = new List<EventAccount>();

            while (reader.Read()) 
            {
                eventAccounts.Add(new EventAccount
                {
                    Username = reader["AccountName"].ToString(),
                    Password = reader["Password"].ToString(),
                    Email = reader["Email"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                });
            }
            sqlConnection.Close();
            return eventAccounts;

        }

        public List<string> GetCompletedEvents()
        {
            string selectStatement = "SELECT CompletedEvents FROM CompletedEvent";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var completedEvents = new List<String>();

            while (reader.Read())
            {
                completedEvents.Add(reader["CompletedEvents"].ToString());
            }
            sqlConnection.Close();
            return completedEvents;

        }

        public List<EventInfo> GetEvents()
        {
            string selectStatement = "SELECT EventStartDate, EventStartTime, EventEndDate, EventEndTime, EventCreator FROM " +
                                  "EventInfo";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var eventInfo = new List<EventInfo>();

            while (reader.Read())
            {
                eventInfo.Add(new EventInfo
                {
                    StartDate = reader["EventStartDate"].ToString(),
                    StartTime = reader["EventStartTime"].ToString(),
                    EndDate = reader["EventEndDate"].ToString(),
                    EndTime = reader["EventEndTime"].ToString(),
                    Creator = reader["EventCreator"].ToString()
                });
               
            }
            sqlConnection.Close();
            return eventInfo;

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
