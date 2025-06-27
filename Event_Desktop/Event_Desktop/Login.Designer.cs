namespace Event_Desktop
{
    partial class frmLogin
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
            lblPassword = new Label();
            lblUsername = new Label();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            lblLogin = new Label();
            btnReturn = new Button();
            btnConfirm = new Button();
            SuspendLayout();
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(12, 123);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(80, 18);
            lblPassword.TabIndex = 19;
            lblPassword.Text = "PASSWORD";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(12, 85);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(80, 18);
            lblUsername.TabIndex = 18;
            lblUsername.Text = "USERNAME";
            lblUsername.Click += lblUsername_Click;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(116, 118);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(125, 23);
            txtPassword.TabIndex = 14;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(116, 80);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(125, 23);
            txtUsername.TabIndex = 13;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Unispace", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLogin.ForeColor = Color.DimGray;
            lblLogin.Location = new Point(12, 20);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(88, 29);
            lblLogin.TabIndex = 12;
            lblLogin.Text = "LOGIN";
            lblLogin.Click += label1_Click;
            // 
            // btnReturn
            // 
            btnReturn.Font = new Font("Unispace", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReturn.Location = new Point(68, 166);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(75, 23);
            btnReturn.TabIndex = 24;
            btnReturn.Text = "RETURN";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirm.Location = new Point(166, 166);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 23);
            btnConfirm.TabIndex = 23;
            btnConfirm.Text = "CONFIRM";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cornsilk;
            ClientSize = new Size(253, 215);
            Controls.Add(btnReturn);
            Controls.Add(btnConfirm);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblLogin);
            Name = "frmLogin";
            Text = "Login";
            Load += frmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblPassword;
        private Label lblUsername;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Label lblLogin;
        private Button btnReturn;
        private Button btnConfirm;
    }
}