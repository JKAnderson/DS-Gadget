namespace DS_Gadget
{
    partial class GadgetTabMisc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.GroupBox gbxEventFlags;
            System.Windows.Forms.Label lblEventFlagsID;
            this.btnEventFlagRead = new System.Windows.Forms.Button();
            this.btnEventFlagWrite = new System.Windows.Forms.Button();
            this.cbxEventFlagValue = new System.Windows.Forms.CheckBox();
            this.txtEventFlagID = new System.Windows.Forms.TextBox();
            this.btnUnlockGestures = new System.Windows.Forms.Button();
            gbxEventFlags = new System.Windows.Forms.GroupBox();
            lblEventFlagsID = new System.Windows.Forms.Label();
            gbxEventFlags.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxEventFlags
            // 
            gbxEventFlags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gbxEventFlags.Controls.Add(this.btnEventFlagRead);
            gbxEventFlags.Controls.Add(this.btnEventFlagWrite);
            gbxEventFlags.Controls.Add(this.cbxEventFlagValue);
            gbxEventFlags.Controls.Add(this.txtEventFlagID);
            gbxEventFlags.Controls.Add(lblEventFlagsID);
            gbxEventFlags.Location = new System.Drawing.Point(4, 4);
            gbxEventFlags.Margin = new System.Windows.Forms.Padding(4);
            gbxEventFlags.Name = "gbxEventFlags";
            gbxEventFlags.Padding = new System.Windows.Forms.Padding(4);
            gbxEventFlags.Size = new System.Drawing.Size(437, 120);
            gbxEventFlags.TabIndex = 2;
            gbxEventFlags.TabStop = false;
            gbxEventFlags.Text = "Event Flags";
            // 
            // btnEventFlagRead
            // 
            this.btnEventFlagRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEventFlagRead.Location = new System.Drawing.Point(221, 69);
            this.btnEventFlagRead.Margin = new System.Windows.Forms.Padding(4);
            this.btnEventFlagRead.Name = "btnEventFlagRead";
            this.btnEventFlagRead.Size = new System.Drawing.Size(100, 28);
            this.btnEventFlagRead.TabIndex = 4;
            this.btnEventFlagRead.Text = "Read";
            this.btnEventFlagRead.UseVisualStyleBackColor = true;
            this.btnEventFlagRead.Click += new System.EventHandler(this.btnEventFlagRead_Click);
            // 
            // btnEventFlagWrite
            // 
            this.btnEventFlagWrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEventFlagWrite.Location = new System.Drawing.Point(329, 69);
            this.btnEventFlagWrite.Margin = new System.Windows.Forms.Padding(4);
            this.btnEventFlagWrite.Name = "btnEventFlagWrite";
            this.btnEventFlagWrite.Size = new System.Drawing.Size(100, 28);
            this.btnEventFlagWrite.TabIndex = 3;
            this.btnEventFlagWrite.Text = "Write";
            this.btnEventFlagWrite.UseVisualStyleBackColor = true;
            this.btnEventFlagWrite.Click += new System.EventHandler(this.btnEventFlagWrite_Click);
            // 
            // cbxEventFlagValue
            // 
            this.cbxEventFlagValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxEventFlagValue.AutoSize = true;
            this.cbxEventFlagValue.Location = new System.Drawing.Point(329, 41);
            this.cbxEventFlagValue.Margin = new System.Windows.Forms.Padding(4);
            this.cbxEventFlagValue.Name = "cbxEventFlagValue";
            this.cbxEventFlagValue.Size = new System.Drawing.Size(82, 21);
            this.cbxEventFlagValue.TabIndex = 2;
            this.cbxEventFlagValue.Text = "Enabled";
            this.cbxEventFlagValue.UseVisualStyleBackColor = true;
            // 
            // txtEventFlagID
            // 
            this.txtEventFlagID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEventFlagID.Location = new System.Drawing.Point(8, 39);
            this.txtEventFlagID.Margin = new System.Windows.Forms.Padding(4);
            this.txtEventFlagID.Name = "txtEventFlagID";
            this.txtEventFlagID.Size = new System.Drawing.Size(313, 22);
            this.txtEventFlagID.TabIndex = 1;
            // 
            // lblEventFlagsID
            // 
            lblEventFlagsID.AutoSize = true;
            lblEventFlagsID.Location = new System.Drawing.Point(8, 20);
            lblEventFlagsID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblEventFlagsID.Name = "lblEventFlagsID";
            lblEventFlagsID.Size = new System.Drawing.Size(21, 17);
            lblEventFlagsID.TabIndex = 0;
            lblEventFlagsID.Text = "ID";
            // 
            // btnUnlockGestures
            // 
            this.btnUnlockGestures.Location = new System.Drawing.Point(4, 132);
            this.btnUnlockGestures.Margin = new System.Windows.Forms.Padding(4);
            this.btnUnlockGestures.Name = "btnUnlockGestures";
            this.btnUnlockGestures.Size = new System.Drawing.Size(144, 28);
            this.btnUnlockGestures.TabIndex = 3;
            this.btnUnlockGestures.Text = "Unlock Gestures";
            this.btnUnlockGestures.UseVisualStyleBackColor = true;
            this.btnUnlockGestures.Click += new System.EventHandler(this.btnUnlockGestures_Click);
            // 
            // GadgetTabMisc
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.Controls.Add(this.btnUnlockGestures);
            this.Controls.Add(gbxEventFlags);
            this.Name = "GadgetTabMisc";
            this.Size = new System.Drawing.Size(445, 166);
            gbxEventFlags.ResumeLayout(false);
            gbxEventFlags.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUnlockGestures;
        private System.Windows.Forms.Button btnEventFlagRead;
        private System.Windows.Forms.Button btnEventFlagWrite;
        private System.Windows.Forms.CheckBox cbxEventFlagValue;
        private System.Windows.Forms.TextBox txtEventFlagID;
    }
}
