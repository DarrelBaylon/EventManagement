using EventCommon;

namespace EventManagementDataService
{
    public class TextFileDataService : IEventDataService
    {
        public List<EventAccount> Accounts { get; private set; } = new List<EventAccount>();
        public List<EventInfo> Events { get; private set; } = new List<EventInfo>();
        private List<string> completedEvents = new List<string>();

        string accountFilePath = "accounts.txt";
        string eventFilePath = "events.txt";
        string completedEventFilePath = "completedEvents.txt";

        public TextFileDataService()
        {
            GetAccountDataFromFile();
            GetEventDataFromFile();
            GetCompletedEventDataFromFile();
        }
        private void GetAccountDataFromFile()
        {
            var lines = File.ReadAllLines(accountFilePath);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split('|');

                if (parts.Length >= 4)
                {
                    Accounts.Add(new EventAccount
                    {
                        Username = parts[0],
                        Password = parts[1],
                        PhoneNumber = parts[2],
                        Email = parts[3],
                        CreatedEvents = new List<string>(),
                        CompletedEvents = new List<string>()
                    });
                }
                else
                {
                    
                }
            }
        }
        private void GetEventDataFromFile()
        {
            var lines = File.ReadAllLines(eventFilePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length >= 6)
                {
                    Events.Add(new EventInfo
                    {
                        Name = parts[0],
                        StartDate = parts[1],
                        StartTime = parts[2],
                        EndDate = parts[3],
                        EndTime = parts[4],
                        Creator = parts[5]
                    });
                }
                
            }
        }
        private void GetCompletedEventDataFromFile()
        {
            if (!File.Exists(completedEventFilePath))
            {
                return;
            }

            var lines = File.ReadAllLines(completedEventFilePath);

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                string[] parts = line.Split('|');

                if (parts.Length < 2)
                {
                    continue; 
                }

                string username = parts[0].Trim();

                
                EventAccount matchedAccount = null;

                for (int j = 0; j < Accounts.Count; j++)
                {
                    if (Accounts[j].Username == username)
                    {
                        matchedAccount = Accounts[j];
                        break;
                    }
                }

                if (matchedAccount != null)
                {
                    
                    for (int k = 1; k < parts.Length; k++)
                    {
                        string eventName = parts[k].Trim();

                        if (!string.IsNullOrEmpty(eventName))
                        {
                            matchedAccount.CompletedEvents.Add(eventName);
                        }
                    }
                }
            }
        }
        private void WriteEventDataToFile()
        {
            var lines = new List<string>();

            foreach (var e in Events)
            {
                lines.Add($"{e.Name}|{e.StartDate}|{e.StartTime}|{e.EndDate}|{e.EndTime}|{e.Creator}");
            }

            File.WriteAllLines(eventFilePath, lines);
        }

        public int FindEventIndex(EventInfo eventInfo)
        {
            for (int i = 0; i < Events.Count; i++)
            {
                if (Events[i].Name == eventInfo.Name)
                {
                    return i;
                }
            }

            return -1;
        }
        public List < EventAccount> GetAccounts()
        {
            return Accounts;
        }

        public List<EventInfo> GetEvents()
        {
            return Events;
        }

        public List<string> GetCompletedEvents()
        {
            for (int i = 0; i < Accounts.Count; i++)
            {
               
                    return Accounts[i].CompletedEvents;
                
            }
            return new List<string>();
        }

        public void AddAccount(EventAccount eventAccount)
        {
            var newLine = $"{eventAccount.Username}|{eventAccount.Password}|{eventAccount.PhoneNumber}|{eventAccount.Email}";

            File.AppendAllText(accountFilePath, newLine);
        }

        public void AddEvent(EventInfo eventInfo)
        {
            var newLine = $"{eventInfo.Name}|{eventInfo.StartDate}|{eventInfo.StartTime}|{eventInfo.EndDate}|{eventInfo.EndTime}|" +
                          $"{eventInfo.Creator}";

            File.AppendAllText(eventFilePath, newLine + Environment.NewLine);
        }

        public void AddCompletedEvent(EventAccount eventAccount)
        {
            var newLine = $"{eventAccount.CompletedEvents}";
            File.AppendAllText(completedEventFilePath, newLine);
        }
        public void UpdateEvent(EventInfo eventInfo)
        {
        }
        public bool RemoveEvent(EventInfo eventInfo)
        {
            int index = -1;

            for (int i = 0; i < Events.Count; i++)
            {
                if (Events[i].Name == eventInfo.Name &&
                   Events[i].StartDate == eventInfo.StartDate &&
                   Events[i].StartTime == eventInfo.StartTime &&
                   Events[i].Creator == eventInfo.Creator)
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
            {
                Events.RemoveAt(index);
                WriteEventDataToFile();
                return true;
            }
            return false;
        }
    }
}
