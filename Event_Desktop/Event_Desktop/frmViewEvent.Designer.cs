namespace Event_Desktop
{
    partial class frmViewEvent
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
            lblEventTex = new Label();
            llbViewEvents = new ListBox();
            btnReturn = new Button();
            lblSignup = new Label();
            SuspendLayout();
            // 
            // lblEventTex
            // 
            lblEventTex.AutoSize = true;
            lblEventTex.BackColor = Color.Transparent;
            lblEventTex.Font = new Font("Unispace", 8.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblEventTex.Location = new Point(11, 68);
            lblEventTex.Name = "lblEventTex";
            lblEventTex.Size = new Size(140, 14);
            lblEventTex.TabIndex = 71;
            lblEventTex.Text = "HERE ARE THE EVENTS";
            // 
            // llbViewEvents
            // 
            llbViewEvents.FormattingEnabled = true;
            llbViewEvents.ItemHeight = 15;
            llbViewEvents.Location = new Point(11, 85);
            llbViewEvents.Name = "llbViewEvents";
            llbViewEvents.Size = new Size(394, 124);
            llbViewEvents.TabIndex = 66;
            // 
            // btnReturn
            // 
            btnReturn.Font = new Font("Unispace", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReturn.Location = new Point(330, 56);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(75, 23);
            btnReturn.TabIndex = 65;
            btnReturn.Text = " RETURN";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // lblSignup
            // 
            lblSignup.AutoSize = true;
            lblSignup.Font = new Font("Unispace", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSignup.ForeColor = Color.DimGray;
            lblSignup.Location = new Point(11, 11);
            lblSignup.Name = "lblSignup";
            lblSignup.Size = new Size(163, 29);
            lblSignup.TabIndex = 64;
            lblSignup.Text = "VIEW EVENT";
            // 
            // frmViewEvent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cornsilk;
            ClientSize = new Size(419, 231);
            Controls.Add(lblEventTex);
            Controls.Add(llbViewEvents);
            Controls.Add(btnReturn);
            Controls.Add(lblSignup);
            Name = "frmViewEvent";
            Text = "frmViewEvent";
            Load += frmViewEvent_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblEventTex;
        private ListBox llbViewEvents;
        private Button btnReturn;
        private Label lblSignup;
    }
}