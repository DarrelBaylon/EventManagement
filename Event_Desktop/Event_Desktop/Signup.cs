using EventManagement_BusinessDataLogic;

namespace Event_Desktop
{
    public partial class frmSignup : Form
    {
        EventManagementService eventManagementProcess = new EventManagementService();
        public frmSignup()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
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
            string username = txtUsername.Text;
            if (username != "")
            {
                string password = txtPassword.Text;
                if (password != "")
                {
                    string age = txtAge.Text;
                    if (age != "")
                    {
                        string phoneNumber = txtPhoneNumber.Text;

                        if (phoneNumber != "")
                        {
                            string email = txtEmail.Text;
                            if (email != "")
                            {
                                if (eventManagementProcess.DuplicateUser(username, phoneNumber, email))
                                {
                                    MessageBox.Show("Username, phone number, or email already exists. Please try again with different credentials.", "Duplicate User Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                else
                                {
                                    eventManagementProcess.RegisterAccounts(username, password, phoneNumber, email);
                                    MessageBox.Show("Registration successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    frmLogin loginForm = new frmLogin();
                                    loginForm.Show();
                                    this.Hide();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please enter a valid email address.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid phone number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid age.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid password.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid username.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmSignup_Load(object sender, EventArgs e)
        {

        }
    }
}
