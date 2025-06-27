namespace Event_Desktop
{
    partial class frmRemoveEvent
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
            btnConfirm = new Button();
            txtEventIndex = new TextBox();
            lblEventName = new Label();
            lblEventTex = new Label();
            llbViewEvents = new ListBox();
            btnReturn = new Button();
            lblSignup = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Cornsilk;
            label2.Font = new Font("Unispace", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.GrayText;
            label2.Location = new Point(21, 52);
            label2.Name = "label2";
            label2.Size = new Size(329, 14);
            label2.TabIndex = 86;
            label2.Text = "ENTER THE NUMBER THAT YOU WOULD LIKE TO DELETE";
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirm.Location = new Point(266, 281);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 23);
            btnConfirm.TabIndex = 87;
            btnConfirm.Text = "CONFIRM";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // txtEventIndex
            // 
            txtEventIndex.Location = new Point(134, 79);
            txtEventIndex.Name = "txtEventIndex";
            txtEventIndex.Size = new Size(107, 23);
            txtEventIndex.TabIndex = 85;
            // 
            // lblEventName
            // 
            lblEventName.AutoSize = true;
            lblEventName.Font = new Font("Unispace", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEventName.Location = new Point(21, 84);
            lblEventName.Name = "lblEventName";
            lblEventName.Size = new Size(107, 18);
            lblEventName.TabIndex = 84;
            lblEventName.Text = "EVENT INDEX";
            // 
            // lblEventTex
            // 
            lblEventTex.AutoSize = true;
            lblEventTex.BackColor = Color.Transparent;
            lblEventTex.Font = new Font("Unispace", 8.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblEventTex.Location = new Point(12, 124);
            lblEventTex.Name = "lblEventTex";
            lblEventTex.Size = new Size(140, 14);
            lblEventTex.TabIndex = 83;
            lblEventTex.Text = "HERE ARE THE EVENTS";
            // 
            // llbViewEvents
            // 
            llbViewEvents.FormattingEnabled = true;
            llbViewEvents.ItemHeight = 15;
            llbViewEvents.Location = new Point(12, 141);
            llbViewEvents.Name = "llbViewEvents";
            llbViewEvents.Size = new Size(338, 124);
            llbViewEvents.TabIndex = 82;
            // 
            // btnReturn
            // 
            btnReturn.Font = new Font("Unispace", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReturn.Location = new Point(166, 281);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(75, 23);
            btnReturn.TabIndex = 81;
            btnReturn.Text = " RETURN";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // lblSignup
            // 
            lblSignup.AutoSize = true;
            lblSignup.Font = new Font("Unispace", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSignup.ForeColor = Color.DimGray;
            lblSignup.Location = new Point(12, 11);
            lblSignup.Name = "lblSignup";
            lblSignup.Size = new Size(193, 29);
            lblSignup.TabIndex = 80;
            lblSignup.Text = "REMOVE EVENT";
            // 
            // frmRemoveEvent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cornsilk;
            ClientSize = new Size(364, 314);
            Controls.Add(btnConfirm);
            Controls.Add(label2);
            Controls.Add(txtEventIndex);
            Controls.Add(lblEventName);
            Controls.Add(lblEventTex);
            Controls.Add(llbViewEvents);
            Controls.Add(btnReturn);
            Controls.Add(lblSignup);
            Name = "frmRemoveEvent";
            Text = "frmRemoveEvent";
            Load += frmRemoveEvent_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConfirm;
        private TextBox txtEventIndex;
        private Label lblEventName;
        private Label lblEventTex;
        private ListBox llbViewEvents;
        private Button btnReturn;
        private Label lblSignup;
    }
}