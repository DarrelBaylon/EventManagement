using EventCommon;
using EventManagement_BusinessDataLogic;
using EventManagementDataService;

namespace Event_Desktop
{
    public partial class frmCreateEvent : Form
    {
        EventManagementService eventManagementProcess = new EventManagementService();
        EventDataService eventDataService = new EventDataService();
        private string currentUsername;
        private string username;
        public frmCreateEvent(string username)
        {
            InitializeComponent();
            currentUsername = username;
            LoadEventsToListBox();
        }

        private void frmCreateEvent_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string eventName = txtEventName.Text;

            int startMonth = Convert.ToInt16(cmbStartMonth.SelectedItem);
            int endMonth = Convert.ToInt16(cmbEndMonth.SelectedItem);
            int startDay = Convert.ToByte(cmbStartDay.SelectedItem);
            int endDay = Convert.ToByte(cmbEndDay.SelectedItem);
            int startYear = Convert.ToInt32(cmbStartYear.SelectedItem);
            int endYear = Convert.ToInt32(cmbEndYear.SelectedItem);

            string startDate = FormatDate(startYear, startMonth, startDay);
            string endDate = FormatDate(endYear, endMonth, endDay);

            string startTime = FormatTime(txtStartTime.Text);
            string endTime = FormatTime(txtEndTime.Text);


            if (eventDataService.Months.Contains(startMonth))
            {

                if (eventManagementProcess.CheckStartDate(startMonth, startDay))
                {   
                    if (eventDataService.Months.Contains(endMonth))
                    {
                        if (eventManagementProcess.CheckEndDate(endMonth, endDay))
                        {
                            if (endYear - startYear >= 0)
                            {
                                if (eventManagementProcess.CreateEvent(eventName, startDate, endDate, startTime,
                                                    endTime, currentUsername))
                                {
                                    MessageBox.Show($"SUCCESSFULLY CREATED THE EVENT: [{eventName}] by [{currentUsername}]", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    EventForm eventForm = new EventForm(username);
                                    eventForm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Failed to create event. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }
                            }
                        }
                    }
                }

            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            EventForm eventForm = new EventForm(username);
            this.Hide();
            eventForm.Show();
        }

        private void cmbEndMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtEventName_TextChanged(object sender, EventArgs e)
        {

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

        private void lblEventTex_Click(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }
        private string FormatDate(int year, int month, int day)
        {
            return new DateTime(year, month, day).ToString("MM-dd-yyyy");
        }

        private string FormatTime(string inputTime)
        {
            return DateTime.ParseExact(inputTime, "H:mm", null).ToString("HH:mm");
        }
    }
}
