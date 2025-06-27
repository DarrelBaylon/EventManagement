namespace Event_Desktop
{
    partial class EventForm
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
            btnRemoveEvent = new Button();
            btnViewEvent = new Button();
            btnCreateEvent = new Button();
            lblTitle = new Label();
            btnUpdateEvent = new Button();
            btnLogout = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // btnRemoveEvent
            // 
            btnRemoveEvent.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemoveEvent.Location = new Point(198, 148);
            btnRemoveEvent.Name = "btnRemoveEvent";
            btnRemoveEvent.Size = new Size(151, 36);
            btnRemoveEvent.TabIndex = 7;
            btnRemoveEvent.Text = "REMOVE EVENT";
            btnRemoveEvent.UseVisualStyleBackColor = true;
            btnRemoveEvent.Click += btnRemoveEvent_Click;
            // 
            // btnViewEvent
            // 
            btnViewEvent.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewEvent.Location = new Point(198, 96);
            btnViewEvent.Name = "btnViewEvent";
            btnViewEvent.Size = new Size(151, 36);
            btnViewEvent.TabIndex = 6;
            btnViewEvent.Text = "VIEW EVENT";
            btnViewEvent.UseVisualStyleBackColor = true;
            btnViewEvent.Click += btnViewEvent_Click;
            // 
            // btnCreateEvent
            // 
            btnCreateEvent.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCreateEvent.Location = new Point(23, 96);
            btnCreateEvent.Name = "btnCreateEvent";
            btnCreateEvent.Size = new Size(151, 36);
            btnCreateEvent.TabIndex = 5;
            btnCreateEvent.Text = "CREATE EVENT";
            btnCreateEvent.UseVisualStyleBackColor = true;
            btnCreateEvent.Click += btnCreateEvent_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Unispace", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(12, 37);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(152, 18);
            lblTitle.TabIndex = 4;
            lblTitle.Text = "SELECT AN ACTION";
            lblTitle.Click += lblTitle_Click;
            // 
            // btnUpdateEvent
            // 
            btnUpdateEvent.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdateEvent.Location = new Point(25, 148);
            btnUpdateEvent.Name = "btnUpdateEvent";
            btnUpdateEvent.Size = new Size(151, 36);
            btnUpdateEvent.TabIndex = 8;
            btnUpdateEvent.Text = "UPDATE EVENT";
            btnUpdateEvent.UseVisualStyleBackColor = true;
            btnUpdateEvent.Click += btnUpdateEvent_Click;
            // 
            // btnLogout
            // 
            btnLogout.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.Location = new Point(118, 222);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(58, 19);
            btnLogout.TabIndex = 9;
            btnLogout.Text = "LOGOUT";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(198, 222);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(48, 19);
            btnExit.TabIndex = 10;
            btnExit.Text = "EXIT";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // EventForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cornsilk;
            ClientSize = new Size(374, 274);
            Controls.Add(btnExit);
            Controls.Add(btnLogout);
            Controls.Add(btnUpdateEvent);
            Controls.Add(btnRemoveEvent);
            Controls.Add(btnViewEvent);
            Controls.Add(btnCreateEvent);
            Controls.Add(lblTitle);
            Name = "EventForm";
            Text = "EventForm";
            Load += EventForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRemoveEvent;
        private Button btnViewEvent;
        private Button btnCreateEvent;
        private Label lblTitle;
        private Button btnUpdateEvent;
        private Button btnLogout;
        private Button btnExit;
    }
}