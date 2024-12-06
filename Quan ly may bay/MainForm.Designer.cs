namespace Quan_ly_may_bay
{
    partial class MainForm
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
            this.ucInfo11 = new Quan_ly_may_bay.UCFlight.UCInfo1();
            this.ucManageFlight1 = new Quan_ly_may_bay.UCFlight.UCManageFlight();
            this.SuspendLayout();
            // 
            // ucInfo11
            // 
            this.ucInfo11.BackColor = System.Drawing.Color.Transparent;
            this.ucInfo11.Location = new System.Drawing.Point(83, 51);
            this.ucInfo11.Name = "ucInfo11";
            this.ucInfo11.Size = new System.Drawing.Size(1082, 150);
            this.ucInfo11.TabIndex = 0;
            // 
            // ucManageFlight1
            // 
            this.ucManageFlight1.BackColor = System.Drawing.Color.Transparent;
            this.ucManageFlight1.Location = new System.Drawing.Point(85, 323);
            this.ucManageFlight1.Name = "ucManageFlight1";
            this.ucManageFlight1.Size = new System.Drawing.Size(1080, 150);
            this.ucManageFlight1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 541);
            this.Controls.Add(this.ucManageFlight1);
            this.Controls.Add(this.ucInfo11);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Vietnam Airline";
            this.ResumeLayout(false);

        }

        #endregion

        private UCFlight.UCInfo1 ucInfo11;
        private UCFlight.UCManageFlight ucManageFlight1;
    }
}

