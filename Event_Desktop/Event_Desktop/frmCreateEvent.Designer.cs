namespace Event_Desktop
{
    partial class frmCreateEvent
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
            Label label2;
            btnReturn = new Button();
            lblSignup = new Label();
            btnConfirm = new Button();
            lblEventStartTime = new Label();
            lblEventStartYear = new Label();
            lblEventStartDay = new Label();
            lblEventStartMonth = new Label();
            lblEventName = new Label();
            llbViewEvents = new ListBox();
            label1 = new Label();
            lblText = new Label();
            lblEndDay = new Label();
            lblEndYear = new Label();
            lblEndTime = new Label();
            lblEventEndMonth = new Label();
            lblEventTex = new Label();
            txtEndTime = new TextBox();
            txtStartTime = new TextBox();
            cmbStartDay = new ComboBox();
            cmbEndDay = new ComboBox();
            cmbStartYear = new ComboBox();
            cmbEndYear = new ComboBox();
            cmbStartMonth = new ComboBox();
            txtEventName = new TextBox();
            cmbEndMonth = new ComboBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnReturn
            // 
            btnReturn.Font = new Font("Unispace", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReturn.Location = new Point(196, 379);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(75, 23);
            btnReturn.TabIndex = 27;
            btnReturn.Text = " RETURN";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // lblSignup
            // 
            lblSignup.AutoSize = true;
            lblSignup.Font = new Font("Unispace", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSignup.ForeColor = Color.DimGray;
            lblSignup.Location = new Point(27, 32);
            lblSignup.Name = "lblSignup";
            lblSignup.Size = new Size(193, 29);
            lblSignup.TabIndex = 26;
            lblSignup.Text = "CREATE EVENT";
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirm.Location = new Point(283, 379);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 23);
            btnConfirm.TabIndex = 25;
            btnConfirm.Text = "CONFIRM";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // lblEventStartTime
            // 
            lblEventStartTime.AutoSize = true;
            lblEventStartTime.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEventStartTime.Location = new Point(28, 239);
            lblEventStartTime.Name = "lblEventStartTime";
            lblEventStartTime.Size = new Size(98, 18);
            lblEventStartTime.TabIndex = 24;
            lblEventStartTime.Text = "START TIME";
            // 
            // lblEventStartYear
            // 
            lblEventStartYear.AutoSize = true;
            lblEventStartYear.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEventStartYear.Location = new Point(28, 200);
            lblEventStartYear.Name = "lblEventStartYear";
            lblEventStartYear.Size = new Size(98, 18);
            lblEventStartYear.TabIndex = 23;
            lblEventStartYear.Text = "START YEAR";
            // 
            // lblEventStartDay
            // 
            lblEventStartDay.AutoSize = true;
            lblEventStartDay.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEventStartDay.Location = new Point(28, 162);
            lblEventStartDay.Name = "lblEventStartDay";
            lblEventStartDay.Size = new Size(89, 18);
            lblEventStartDay.TabIndex = 22;
            lblEventStartDay.Text = "START DAY";
            // 
            // lblEventStartMonth
            // 
            lblEventStartMonth.AutoSize = true;
            lblEventStartMonth.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEventStartMonth.Location = new Point(28, 124);
            lblEventStartMonth.Name = "lblEventStartMonth";
            lblEventStartMonth.Size = new Size(107, 18);
            lblEventStartMonth.TabIndex = 21;
            lblEventStartMonth.Text = "START MONTH";
            // 
            // lblEventName
            // 
            lblEventName.AutoSize = true;
            lblEventName.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEventName.Location = new Point(28, 86);
            lblEventName.Name = "lblEventName";
            lblEventName.Size = new Size(98, 18);
            lblEventName.TabIndex = 20;
            lblEventName.Text = "EVENT NAME";
            lblEventName.Click += lblUsername_Click;
            // 
            // llbViewEvents
            // 
            llbViewEvents.FormattingEnabled = true;
            llbViewEvents.ItemHeight = 15;
            llbViewEvents.Location = new Point(28, 290);
            llbViewEvents.Name = "llbViewEvents";
            llbViewEvents.Size = new Size(488, 79);
            llbViewEvents.TabIndex = 29;
            llbViewEvents.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1030, 243);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 30;
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblText.Location = new Point(326, -61);
            lblText.Name = "lblText";
            lblText.Size = new Size(140, 14);
            lblText.TabIndex = 31;
            lblText.Text = "HERE ARE THE EVENTS";
            // 
            // lblEndDay
            // 
            lblEndDay.AutoSize = true;
            lblEndDay.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEndDay.Location = new Point(287, 162);
            lblEndDay.Name = "lblEndDay";
            lblEndDay.Size = new Size(71, 18);
            lblEndDay.TabIndex = 33;
            lblEndDay.Text = "END DAY";
            // 
            // lblEndYear
            // 
            lblEndYear.AutoSize = true;
            lblEndYear.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEndYear.Location = new Point(287, 200);
            lblEndYear.Name = "lblEndYear";
            lblEndYear.Size = new Size(80, 18);
            lblEndYear.TabIndex = 35;
            lblEndYear.Text = "END YEAR";
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEndTime.Location = new Point(287, 239);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(80, 18);
            lblEndTime.TabIndex = 37;
            lblEndTime.Text = "END TIME";
            // 
            // lblEventEndMonth
            // 
            lblEventEndMonth.AutoSize = true;
            lblEventEndMonth.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEventEndMonth.Location = new Point(287, 124);
            lblEventEndMonth.Name = "lblEventEndMonth";
            lblEventEndMonth.Size = new Size(89, 18);
            lblEventEndMonth.TabIndex = 39;
            lblEventEndMonth.Text = "END MONTH";
            // 
            // lblEventTex
            // 
            lblEventTex.AutoSize = true;
            lblEventTex.BackColor = Color.Transparent;
            lblEventTex.Font = new Font("Unispace", 8.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblEventTex.Location = new Point(28, 273);
            lblEventTex.Name = "lblEventTex";
            lblEventTex.Size = new Size(140, 14);
            lblEventTex.TabIndex = 40;
            lblEventTex.Text = "HERE ARE THE EVENTS";
            lblEventTex.Click += lblEventTex_Click;
            // 
            // txtEndTime
            // 
            txtEndTime.Location = new Point(409, 234);
            txtEndTime.Name = "txtEndTime";
            txtEndTime.Size = new Size(107, 23);
            txtEndTime.TabIndex = 48;
            // 
            // txtStartTime
            // 
            txtStartTime.Location = new Point(164, 234);
            txtStartTime.Name = "txtStartTime";
            txtStartTime.Size = new Size(107, 23);
            txtStartTime.TabIndex = 49;
            // 
            // cmbStartDay
            // 
            cmbStartDay.FormattingEnabled = true;
            cmbStartDay.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" });
            cmbStartDay.Location = new Point(164, 157);
            cmbStartDay.Name = "cmbStartDay";
            cmbStartDay.Size = new Size(107, 23);
            cmbStartDay.TabIndex = 50;
            // 
            // cmbEndDay
            // 
            cmbEndDay.FormattingEnabled = true;
            cmbEndDay.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" });
            cmbEndDay.Location = new Point(409, 157);
            cmbEndDay.Name = "cmbEndDay";
            cmbEndDay.Size = new Size(107, 23);
            cmbEndDay.TabIndex = 51;
            // 
            // cmbStartYear
            // 
            cmbStartYear.FormattingEnabled = true;
            cmbStartYear.Items.AddRange(new object[] { "2025", "2026", "2027", "2028", "2029", "2030" });
            cmbStartYear.Location = new Point(164, 195);
            cmbStartYear.Name = "cmbStartYear";
            cmbStartYear.Size = new Size(107, 23);
            cmbStartYear.TabIndex = 52;
            // 
            // cmbEndYear
            // 
            cmbEndYear.FormattingEnabled = true;
            cmbEndYear.Items.AddRange(new object[] { "2025", "2026", "2027", "2028", "2029", "2030" });
            cmbEndYear.Location = new Point(409, 195);
            cmbEndYear.Name = "cmbEndYear";
            cmbEndYear.Size = new Size(107, 23);
            cmbEndYear.TabIndex = 53;
            // 
            // cmbStartMonth
            // 
            cmbStartMonth.FormattingEnabled = true;
            cmbStartMonth.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            cmbStartMonth.Location = new Point(164, 119);
            cmbStartMonth.Name = "cmbStartMonth";
            cmbStartMonth.Size = new Size(107, 23);
            cmbStartMonth.TabIndex = 54;
            cmbStartMonth.SelectedIndexChanged += comboBox5_SelectedIndexChanged;
            // 
            // txtEventName
            // 
            txtEventName.Location = new Point(164, 81);
            txtEventName.Name = "txtEventName";
            txtEventName.Size = new Size(107, 23);
            txtEventName.TabIndex = 55;
            txtEventName.TextChanged += txtEventName_TextChanged;
            // 
            // cmbEndMonth
            // 
            cmbEndMonth.FormattingEnabled = true;
            cmbEndMonth.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            cmbEndMonth.Location = new Point(409, 119);
            cmbEndMonth.Name = "cmbEndMonth";
            cmbEndMonth.Size = new Size(107, 23);
            cmbEndMonth.TabIndex = 56;
            cmbEndMonth.SelectedIndexChanged += cmbEndMonth_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Cornsilk;
            label2.Font = new Font("Unispace", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.GrayText;
            label2.Location = new Point(287, 85);
            label2.Name = "label2";
            label2.Size = new Size(238, 14);
            label2.TabIndex = 57;
            label2.Text = "ENTER TIME ON THIS FORMAT (HH:MM)";
            // 
            // frmCreateEvent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cornsilk;
            ClientSize = new Size(557, 414);
            Controls.Add(label2);
            Controls.Add(cmbEndMonth);
            Controls.Add(txtEventName);
            Controls.Add(cmbStartMonth);
            Controls.Add(cmbEndYear);
            Controls.Add(cmbStartYear);
            Controls.Add(cmbEndDay);
            Controls.Add(cmbStartDay);
            Controls.Add(txtStartTime);
            Controls.Add(txtEndTime);
            Controls.Add(lblEventTex);
            Controls.Add(lblEventEndMonth);
            Controls.Add(lblEndTime);
            Controls.Add(lblEndYear);
            Controls.Add(lblEndDay);
            Controls.Add(lblText);
            Controls.Add(label1);
            Controls.Add(llbViewEvents);
            Controls.Add(btnReturn);
            Controls.Add(lblSignup);
            Controls.Add(btnConfirm);
            Controls.Add(lblEventStartTime);
            Controls.Add(lblEventStartYear);
            Controls.Add(lblEventStartDay);
            Controls.Add(lblEventStartMonth);
            Controls.Add(lblEventName);
            Name = "frmCreateEvent";
            Text = "CREATE EVENT";
            Load += frmCreateEvent_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnReturn;
        private Label lblSignup;
        private Button btnConfirm;
        private Label lblEventStartTime;
        private Label lblEventStartYear;
        private Label lblEventStartDay;
        private Label lblEventStartMonth;
        private Label lblEventName;
        private TextBox txtEmail;
        private TextBox txtPhoneNumber;
        private TextBox txtAge;
        private TextBox txtPassword;
        private ListBox llbViewEvents;
        private Label label1;
        private Label lblText;
        private Label lblEndDay;
        private TextBox txtEventName;
        private Label lblEndYear;
        private TextBox textBox2;
        private Label lblEndTime;
        private Label lblEventEndMonth;
        private TextBox textBox4;
        private Label lblEventTex;
        private TextBox txtEndTime;
        private TextBox txtStartTime;
        private ComboBox cmbStartDay;
        private ComboBox cmbEndDay;
        private ComboBox cmbStartYear;
        private ComboBox cmbEndYear;
        private ComboBox cmbStartMonth;
        private ComboBox cmbEndMonth;
    }
}