namespace Quan_ly_may_bay
{
    partial class Author
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uC_Author5 = new Quan_ly_may_bay.UCFlight.UC_Author();
            this.uC_Author4 = new Quan_ly_may_bay.UCFlight.UC_Author();
            this.uC_Author3 = new Quan_ly_may_bay.UCFlight.UC_Author();
            this.uC_Author2 = new Quan_ly_may_bay.UCFlight.UC_Author();
            this.uC_Author1 = new Quan_ly_may_bay.UCFlight.UC_Author();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Quan_ly_may_bay.Properties.Resources.Cancel;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(313, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 28);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // uC_Author5
            // 
            this.uC_Author5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.uC_Author5.ImageMember = global::Quan_ly_may_bay.Properties.Resources.chuong;
            this.uC_Author5.Location = new System.Drawing.Point(12, 422);
            this.uC_Author5.Mssv = "49.01.104.015";
            this.uC_Author5.Name = "uC_Author5";
            this.uC_Author5.Size = new System.Drawing.Size(331, 83);
            this.uC_Author5.TabIndex = 4;
            this.uC_Author5.Ten = "Nguyễn Hoàng Chương";
            // 
            // uC_Author4
            // 
            this.uC_Author4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.uC_Author4.ImageMember = global::Quan_ly_may_bay.Properties.Resources.bhuy;
            this.uC_Author4.Location = new System.Drawing.Point(12, 122);
            this.uC_Author4.Mssv = "49.01.104.052";
            this.uC_Author4.Name = "uC_Author4";
            this.uC_Author4.Size = new System.Drawing.Size(331, 83);
            this.uC_Author4.TabIndex = 3;
            this.uC_Author4.Ten = "Nguyễn Bảo Huy";
            // 
            // uC_Author3
            // 
            this.uC_Author3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.uC_Author3.ImageMember = global::Quan_ly_may_bay.Properties.Resources.khang;
            this.uC_Author3.Location = new System.Drawing.Point(12, 228);
            this.uC_Author3.Mssv = "49.01.104.066";
            this.uC_Author3.Name = "uC_Author3";
            this.uC_Author3.Size = new System.Drawing.Size(331, 83);
            this.uC_Author3.TabIndex = 2;
            this.uC_Author3.Ten = "Phan Tuấn Khang";
            // 
            // uC_Author2
            // 
            this.uC_Author2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.uC_Author2.ImageMember = global::Quan_ly_may_bay.Properties.Resources.ghuy2;
            this.uC_Author2.Location = new System.Drawing.Point(12, 325);
            this.uC_Author2.Mssv = "49.01.104.053";
            this.uC_Author2.Name = "uC_Author2";
            this.uC_Author2.Size = new System.Drawing.Size(331, 83);
            this.uC_Author2.TabIndex = 1;
            this.uC_Author2.Ten = "Nguyễn Gia Huy";
            // 
            // uC_Author1
            // 
            this.uC_Author1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.uC_Author1.ImageMember = global::Quan_ly_may_bay.Properties.Resources.ky1;
            this.uC_Author1.Location = new System.Drawing.Point(12, 25);
            this.uC_Author1.Mssv = "49.01.104.079";
            this.uC_Author1.Name = "uC_Author1";
            this.uC_Author1.Size = new System.Drawing.Size(331, 83);
            this.uC_Author1.TabIndex = 0;
            this.uC_Author1.Ten = "Phang Anh Kỳ";
            // 
            // Author
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(355, 511);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.uC_Author5);
            this.Controls.Add(this.uC_Author4);
            this.Controls.Add(this.uC_Author3);
            this.Controls.Add(this.uC_Author2);
            this.Controls.Add(this.uC_Author1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Author";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Border.Rounding = 20;
            this.Text = "Author";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UCFlight.UC_Author uC_Author1;
        private UCFlight.UC_Author uC_Author2;
        private UCFlight.UC_Author uC_Author3;
        private UCFlight.UC_Author uC_Author4;
        private UCFlight.UC_Author uC_Author5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}