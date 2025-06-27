using EventCommon;
using Microsoft.Data.SqlClient; 

namespace EventManagementDataService
{
    class DBDataService : IEventDataService
    {
        public List<EventInfo> eventInfos { get; private set; } = new List<EventInfo>();
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
            var insertStatement = "INSERT INTO EventAccount (AccountName, Password, Email, PhoneNumber) " +
                                  "VALUES (@AccountName, @Password, @Email, @PhoneNumber)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);
            insertCommand.Parameters.AddWithValue("@AccountName", eventAccount.Username);
            insertCommand.Parameters.AddWithValue("@Password", eventAccount.Password);
            insertCommand.Parameters.AddWithValue("@Email", eventAccount.Email);
            insertCommand.Parameters.AddWithValue("@PhoneNumber", eventAccount.PhoneNumber);
            sqlConnection.Open();

            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void AddCompletedEvent(EventAccount eventAccount)
        {
            var insertStatement = "INSERT INTO CompletedEvent (CompletedEvents) VALUES (@CompletedEvents)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);
            insertCommand.Parameters.AddWithValue("@CompletedEvents", eventAccount.CompletedEvents);
            sqlConnection.Open();

            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void AddEvent(EventInfo eventInfo)
        {
            var insertStatement = "INSERT INTO EventInfo (EventName, EventStartDate, EventStartTime, EventEndDate, EventEndTime, EventCreator) " +
                                  "VALUES (@Name, @StartDate, @StartTime, @EndDate, @EndTime, @Creator)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);
            insertCommand.Parameters.AddWithValue("@Name", eventInfo.Name);
            insertCommand.Parameters.AddWithValue("@StartDate", eventInfo.StartDate);
            insertCommand.Parameters.AddWithValue("@StartTime", eventInfo.StartTime);
            insertCommand.Parameters.AddWithValue("@EndDate", eventInfo.EndDate);
            insertCommand.Parameters.AddWithValue("@EndTime", eventInfo.EndTime);
            insertCommand.Parameters.AddWithValue("@Creator", eventInfo.Creator);
            sqlConnection.Open();

            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public int FindEventIndex(EventInfo eventInfo)
        {
            for (int i = 0; i < eventInfos.Count; i++)
            {
                if (eventInfos[i].Name == eventInfo.Name)
                {
                    return i;
                }
            }
            return -1;
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
                EventAccount eventAccount = new EventAccount();
                eventAccount.Username = reader["AccountName"].ToString();
                eventAccount.Password = reader["Password"].ToString();
                eventAccount.Email = reader["Email"].ToString();
                eventAccount.PhoneNumber = reader["PhoneNumber"].ToString();

                eventAccounts.Add(eventAccount);
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

            var completedEvents = new List<string>();

            while (reader.Read())
            {
                string completedEvent = reader["CompletedEvents"].ToString();
                string deserializedCompletedEvent = completedEvent;

                completedEvents.Add(deserializedCompletedEvent);
            }

            sqlConnection.Close();
            return completedEvents;
        }
        public List<EventInfo> GetEvents()
        {
            string selectStatement = "SELECT EventName, EventStartDate, EventStartTime, EventEndDate, EventEndTime, EventCreator FROM " +
                                  "EventInfo";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var eventInfos = new List<EventInfo>();

            while (reader.Read())
            {
                EventInfo eventInfo = new EventInfo();
                eventInfo.Name = reader["EventName"].ToString();
                eventInfo.StartDate = reader["EventStartDate"].ToString();
                eventInfo.StartTime = reader["EventStartTime"].ToString();
                eventInfo.EndDate = reader["EventEndDate"].ToString();
                eventInfo.EndTime = reader["EventEndTime"].ToString();
                eventInfo.Creator = reader["EventCreator"].ToString();

                eventInfos.Add(eventInfo);
            }
            sqlConnection.Close();
            return eventInfos;

        }
        public bool RemoveEvent(EventInfo eventInfo)
        {
            sqlConnection.Open();

            var deleteStatement = "DELETE FROM EventInfo WHERE EventName = @Name AND EventStartDate = @StartDate " +
                                  "AND EventStartTime = @StartTime AND EventCreator = @Creator";

            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            deleteCommand.Parameters.AddWithValue("@Name", eventInfo.Name);
            deleteCommand.Parameters.AddWithValue("@StartDate", eventInfo.StartDate);
            deleteCommand.Parameters.AddWithValue("@StartTime", eventInfo.StartTime);
            deleteCommand.Parameters.AddWithValue("@Creator", eventInfo.Creator);

            int rowsAffected = deleteCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return rowsAffected > 0; 
        }
        public void UpdateEvent(EventInfo eventInfo)
        {
            sqlConnection.Open();
            var updateStatement = "UPDATE EventInfo SET EventName = @Name, EventStartDate = @StartDate,EventStartTime = " +
                                  "@StartTime, EventEndDate = @EndDate, EventEndTime = @EndTime, EventCreator = " +
                                  "@Creator WHERE EventName = @Name AND EventStartDate = @StartDate AND EventStartTime = " +
                                  "@StartTime AND EventCreator = @Creator";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@Name", eventInfo.Name);
            updateCommand.Parameters.AddWithValue("@StartDate", eventInfo.StartDate);
            updateCommand.Parameters.AddWithValue("@StartTime", eventInfo.StartTime);
            updateCommand.Parameters.AddWithValue("@EndDate", eventInfo.EndDate);
            updateCommand.Parameters.AddWithValue("@EndTime", eventInfo.EndTime);
            updateCommand.Parameters.AddWithValue("@Creator", eventInfo.Creator);
            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();  
        }
    }
}
