using EventCommon;
using EventManagement_BusinessDataLogic;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventAccountController : ControllerBase
    {
        EventManagementService eventManagementProcess = new EventManagementService();

        [HttpGet("getusers")]
        public IEnumerable <EventAccount> GetUsers()
        {
           var accounts = eventManagementProcess.GetAccounts();

            return accounts;
        }
        [HttpGet("getinfo")]
        public IEnumerable<EventInfo> GetInfo()
        {
            var infos = eventManagementProcess.GetAllEvents();

            return infos;
        }
        [HttpGet("getcompletedevents")]
        public IEnumerable<String> GetCompletedEvent()
        {
            var completedEvents = eventManagementProcess.GetCompletedEvents();

            return completedEvents;
        }

        [HttpPatch]
        public bool UpdateEvent(UpdateEventModel request)
        {
            List<EventAccount> accounts = eventManagementProcess.GetAccounts();
            var result = !eventManagementProcess.UpdateEvent(request.EventName, request.CurrentUsername);
            return result;
        }
        [HttpPost("createaccount")]
        public bool CreateEvent(CreateEventModel request)
        {
            List<EventInfo> events = eventManagementProcess.GetAllEvents();
            var result = !eventManagementProcess.CreateEvent(
                request.EventName,
                request.StartDate,
                request.EndDate,
                request.StartTime,
                request.EndTime,
                request.CurrentUsername
            );
            return result;
            
        }
        [HttpPost("createevent")]
        public void RegisterAccount(RegisterAccountModel request)
        {
            eventManagementProcess.RegisterAccounts(
                request.Username,
                request.Password,
                request.Email,
                request.PhoneNumber
            );
        }
        [HttpPost("completeevent")]
        public bool CompleteEvent(CompleteEventModel request)
        {
            return eventManagementProcess.EventCompleter(request.EventName);
        }

        [HttpDelete]
        public bool DeleteEvent(DeleteEventModel request)
        {
            return eventManagementProcess.DeleteEvent(
                request.EventName,
                request.CurrentUsername
            );
        }
    }
}
