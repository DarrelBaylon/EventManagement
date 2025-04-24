using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement_BusinessDataLogic
{
    public class EventAccounts
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        
        public List<string> CreatedEvents { get; set; } = new List<string>();
        public List<string> CompletedEvents { get; set; } = new List<string>();
    }
}
