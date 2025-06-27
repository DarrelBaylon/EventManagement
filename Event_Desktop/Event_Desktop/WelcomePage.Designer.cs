namespace Event_Desktop
{
    partial class frmHomePage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            btnSignup = new Button();
            btnLogin = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Unispace", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(11, 47);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(314, 18);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "WELCOME TO EVENT MANAGEMENT SYSTEM";
            // 
            // btnSignup
            // 
            btnSignup.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSignup.Location = new Point(12, 97);
            btnSignup.Name = "btnSignup";
            btnSignup.Size = new Size(151, 36);
            btnSignup.TabIndex = 1;
            btnSignup.Text = "SIGNUP";
            btnSignup.UseVisualStyleBackColor = true;
            btnSignup.Click += btnSignup_Click;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(174, 97);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(151, 36);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(12, 149);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(313, 36);
            btnExit.TabIndex = 3;
            btnExit.Text = "EXIT";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // frmHomePage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cornsilk;
            ClientSize = new Size(337, 218);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(btnSignup);
            Controls.Add(lblTitle);
            Name = "frmHomePage";
            Text = "EVENT DESKTOP";
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Label lblTitle;
        private Button btnSignup;
        private Button btnLogin;
        private Button btnExit;
    }
}
