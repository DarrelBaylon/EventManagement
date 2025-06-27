namespace Event_Desktop
{
    partial class frmSignup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtAge = new TextBox();
            txtPhoneNumber = new TextBox();
            txtEmail = new TextBox();
            lblUsername = new Label();
            lblPassword = new Label();
            lblAge = new Label();
            lblPhoneNumber = new Label();
            lblEmail = new Label();
            btnConfirm = new Button();
            lblSignup = new Label();
            btnReturn = new Button();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(134, 105);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(107, 23);
            txtUsername.TabIndex = 1;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(134, 143);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(107, 23);
            txtPassword.TabIndex = 2;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(134, 181);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(107, 23);
            txtAge.TabIndex = 3;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(134, 219);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(107, 23);
            txtPhoneNumber.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(134, 258);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(107, 23);
            txtEmail.TabIndex = 5;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(12, 110);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(80, 18);
            lblUsername.TabIndex = 6;
            lblUsername.Text = "USERNAME";
            lblUsername.Click += label2_Click;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(12, 148);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(80, 18);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "PASSWORD";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAge.Location = new Point(12, 186);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(35, 18);
            lblAge.TabIndex = 8;
            lblAge.Text = "AGE";
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPhoneNumber.Location = new Point(12, 224);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(107, 18);
            lblPhoneNumber.TabIndex = 9;
            lblPhoneNumber.Text = "PHONENUMBER";
            lblPhoneNumber.Click += label5_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(12, 263);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(62, 18);
            lblEmail.TabIndex = 10;
            lblEmail.Text = "E-MAIL";
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirm.Location = new Point(160, 313);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 23);
            btnConfirm.TabIndex = 11;
            btnConfirm.Text = "CONFIRM";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // lblSignup
            // 
            lblSignup.AutoSize = true;
            lblSignup.Font = new Font("Unispace", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSignup.ForeColor = Color.DimGray;
            lblSignup.Location = new Point(12, 21);
            lblSignup.Name = "lblSignup";
            lblSignup.Size = new Size(103, 29);
            lblSignup.TabIndex = 13;
            lblSignup.Text = "SIGNUP";
            lblSignup.Click += label7_Click;
            // 
            // btnReturn
            // 
            btnReturn.Font = new Font("Unispace", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReturn.Location = new Point(64, 313);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(75, 23);
            btnReturn.TabIndex = 14;
            btnReturn.Text = " RETURN";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // frmSignup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cornsilk;
            ClientSize = new Size(253, 375);
            Controls.Add(btnReturn);
            Controls.Add(lblSignup);
            Controls.Add(btnConfirm);
            Controls.Add(lblEmail);
            Controls.Add(lblPhoneNumber);
            Controls.Add(lblAge);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(txtEmail);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtAge);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Name = "frmSignup";
            Text = "SIGNUP PAGE";
            Load += frmSignup_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtAge;
        private TextBox txtPhoneNumber;
        private TextBox txtEmail;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblAge;
        private Label lblPhoneNumber;
        private Label lblEmail;
        private Button btnConfirm;
        private Label lblSignup;
        private Button btnReturn;
    }
}