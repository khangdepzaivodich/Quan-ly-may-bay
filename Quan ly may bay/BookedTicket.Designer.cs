namespace Quan_ly_may_bay
{
    partial class BookedTicket
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
            this.PanelTicket = new System.Windows.Forms.FlowLayoutPanel();
            this.Substract = new System.Windows.Forms.PictureBox();
            this.lblStt = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Substract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Add)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelTicket
            // 
            this.PanelTicket.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PanelTicket.Location = new System.Drawing.Point(50, 44);
            this.PanelTicket.Name = "PanelTicket";
            this.PanelTicket.Size = new System.Drawing.Size(727, 483);
            this.PanelTicket.TabIndex = 0;
            this.PanelTicket.WrapContents = false;
            // 
            // Substract
            // 
            this.Substract.BackgroundImage = global::Quan_ly_may_bay.Properties.Resources.arrow_left;
            this.Substract.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Substract.Location = new System.Drawing.Point(332, 566);
            this.Substract.Name = "Substract";
            this.Substract.Size = new System.Drawing.Size(53, 50);
            this.Substract.TabIndex = 12;
            this.Substract.TabStop = false;
            this.Substract.Click += new System.EventHandler(this.Substract_Click);
            // 
            // lblStt
            // 
            this.lblStt.Font = new System.Drawing.Font("Itim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStt.ForeColor = System.Drawing.Color.White;
            this.lblStt.Location = new System.Drawing.Point(391, 566);
            this.lblStt.Name = "lblStt";
            this.lblStt.Size = new System.Drawing.Size(47, 49);
            this.lblStt.TabIndex = 14;
            this.lblStt.Text = "0";
            this.lblStt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Add
            // 
            this.Add.BackgroundImage = global::Quan_ly_may_bay.Properties.Resources.arrow_right__1_;
            this.Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Add.Location = new System.Drawing.Point(444, 566);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(53, 50);
            this.Add.TabIndex = 13;
            this.Add.TabStop = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // BookedTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(821, 643);
            this.Controls.Add(this.lblStt);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Substract);
            this.Controls.Add(this.PanelTicket);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BookedTicket";
            this.Opacity = 0.8D;
            this.Text = "BookedTicket";
            ((System.ComponentModel.ISupportInitialize)(this.Substract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Add)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel PanelTicket;
        private System.Windows.Forms.PictureBox Substract;
        private System.Windows.Forms.Label lblStt;
        private System.Windows.Forms.PictureBox Add;
    }
}