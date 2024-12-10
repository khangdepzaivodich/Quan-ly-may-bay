namespace Quan_ly_may_bay.UCFlight
{
    partial class UC_btnMainForm
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
            this.TextButton = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // TextButton
            // 
            this.TextButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextButton.Font = new System.Drawing.Font("Itim", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextButton.ForeColor = System.Drawing.Color.White;
            this.TextButton.Location = new System.Drawing.Point(0, 0);
            this.TextButton.Name = "TextButton";
            this.TextButton.Size = new System.Drawing.Size(245, 65);
            this.TextButton.TabIndex = 1;
            this.TextButton.Tag = "0";
            this.TextButton.Text = "View Ticket";
            this.TextButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UC_btnMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.TextButton);
            this.Name = "UC_btnMainForm";
            this.Size = new System.Drawing.Size(245, 65);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TextButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
