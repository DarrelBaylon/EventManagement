
namespace Event_Desktop
{
    public partial class EventForm : Form
    {
        private string username;

        public EventForm(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void EventForm_Load(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmHomePage homePage = new frmHomePage();
            this.Hide();
            homePage.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCreateEvent_Click(object sender, EventArgs e)
        {
            frmCreateEvent createEventForm = new frmCreateEvent(username);
            createEventForm.Show();
            this.Hide();
        }

        private void btnViewEvent_Click(object sender, EventArgs e)
        {
            frmViewEvent viewEventForm = new frmViewEvent();
            viewEventForm.Show();
            this.Hide();
        }

        private void btnUpdateEvent_Click(object sender, EventArgs e)
        {
            frmUpdateEvent updateEventForm = new frmUpdateEvent();
            updateEventForm.Show();
            this.Hide();
        }

        private void btnRemoveEvent_Click(object sender, EventArgs e)
        {
            frmRemoveEvent removeEventForm = new frmRemoveEvent();
            removeEventForm.Show();
            this.Hide();
        }
    }
}
