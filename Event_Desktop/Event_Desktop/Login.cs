using EventManagement_BusinessDataLogic;


namespace Event_Desktop
{
    public partial class frmLogin : Form
    {
        EventManagementService eventManagementProcess = new EventManagementService();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            frmHomePage homePage = new frmHomePage();
            this.Hide();
            homePage.Show();
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string currentUsername = txtUsername.Text;
            if (currentUsername != null)
            {
                string password = txtPassword.Text;
                if (password != null)
                {
                    if (eventManagementProcess.ValidLogIn(currentUsername, password))
                    {
                        MessageBox.Show("Login successful!");
                        EventForm eventPage = new EventForm(currentUsername);
                        eventPage.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
