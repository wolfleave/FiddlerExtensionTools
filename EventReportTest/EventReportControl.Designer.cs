namespace EventReportTest
{
    partial class EventReportControl
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
            this.EventID = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // EventID
            // 
            this.EventID.FormattingEnabled = true;
            this.EventID.ItemHeight = 12;
            this.EventID.Location = new System.Drawing.Point(25, 20);
            this.EventID.Name = "EventID";
            this.EventID.Size = new System.Drawing.Size(830, 544);
            this.EventID.TabIndex = 0;
            // 
            // EventReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EventID);
            this.Name = "EventReportControl";
            this.Size = new System.Drawing.Size(875, 815);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox EventID;
    }
}
