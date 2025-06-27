using EventCommon;
using EventManagement_BusinessDataLogic;

namespace Event_Desktop
{
    public partial class frmRemoveEvent : Form
    {
        EventManagementService eventManagementProcess = new EventManagementService();
        private string currentUsername;
        private string username;
        public frmRemoveEvent()
        {
            InitializeComponent();
            LoadEventsToListBox();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            EventForm eventForm = new EventForm(username);
            this.Hide();
            eventForm.Show();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            List<EventInfo> eventList = eventManagementProcess.GetAllEvents();
            string input = txtEventIndex.Text;
            if (eventList.Count != 0)
            {
                if (eventManagementProcess.ValidEventSelector(input, out int selectedIndex))
                {
                    int index = selectedIndex - 1;
                    if (index >= 0 && index < eventList.Count)
                    {
                        string selectedEvent = eventList[index].Name;
                        bool result = eventManagementProcess.DeleteEvent(selectedEvent.Trim(), currentUsername.Trim());
                        if (result)
                        {
                            MessageBox.Show($"SUCCESSFULLY DELETED THE EVENT: [{selectedEvent}]", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtEventIndex.Clear();
                            LoadEventsToListBox();
                            EventForm eventForm = new EventForm(username);
                            eventForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show($"YOU ARE NOT AUTHORIZED TO DELETE THE EVENT: [{selectedEvent}]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid event index. Please enter a valid index.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid input. Please enter a valid event index.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("THERE ARE CURRENTLY NO EVENTS TO DELETE!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        }

        private void frmRemoveEvent_Load(object sender, EventArgs e)
        {

        }
    }
}
