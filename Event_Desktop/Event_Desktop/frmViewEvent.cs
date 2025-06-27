using EventCommon;
using EventManagement_BusinessDataLogic;

namespace Event_Desktop
{
    public partial class frmViewEvent : Form
    {
        EventManagementService eventManagementProcess = new EventManagementService();
  
        
        private string username;

        public frmViewEvent()
        {
            InitializeComponent();
            LoadEventsToListBox();
        }

        private void frmViewEvent_Load(object sender, EventArgs e)
        {

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            EventForm eventForm = new EventForm(username);
            this.Hide();
            eventForm.Show();
        }
        public void LoadEventsToListBox()
        {
            llbViewEvents.Items.Clear();
            llbViewEvents.HorizontalScrollbar = true;
            llbViewEvents.IntegralHeight = false;

            List<EventInfo> eventList = eventManagementProcess.GetAllEvents();

            if (eventList.Count != 0)
            {
                foreach (EventInfo currentEvent in eventList)
                {
                    string formattedStartTime = DateTime.Parse(currentEvent.StartTime).ToString("HH:mm");
                    string formattedEndTime = DateTime.Parse(currentEvent.EndTime).ToString("HH:mm");

                    string formatted = "Event: " + currentEvent.Name + "\n" +
                                       " Start: " + currentEvent.StartDate + " " + formattedStartTime + "\n" +
                                       " End: " + currentEvent.EndDate + " " + formattedEndTime + "\n" +
                                       " Creator: " + currentEvent.Creator + "\n" +
                                       "------------------------------";

                    llbViewEvents.Items.Add(formatted);
                }
            }
            else
            {
                llbViewEvents.Items.Add("THERE ARE CURRENTLY NO EVENTS TO VIEW!");
            }
        }
    }
}
