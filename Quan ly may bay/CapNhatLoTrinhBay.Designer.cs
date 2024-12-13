namespace Quan_ly_may_bay
{
    partial class CapNhatLoTrinhBay
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
            this.pAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblStt = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.PictureBox();
            this.Substract = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Add)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Substract)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelTicket
            // 
            this.PanelTicket.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PanelTicket.Location = new System.Drawing.Point(47, 29);
            this.PanelTicket.Name = "PanelTicket";
            this.PanelTicket.Size = new System.Drawing.Size(735, 504);
            this.PanelTicket.TabIndex = 1;
            this.PanelTicket.WrapContents = false;
            // 
            // pAdd
            // 
            this.pAdd.Location = new System.Drawing.Point(757, 592);
            this.pAdd.Name = "pAdd";
            this.pAdd.OverrideDefault.Back.Color1 = System.Drawing.Color.Aqua;
            this.pAdd.OverrideDefault.Back.Color2 = System.Drawing.Color.Aquamarine;
            this.pAdd.Size = new System.Drawing.Size(52, 50);
            this.pAdd.StateCommon.Back.Color1 = System.Drawing.Color.Aqua;
            this.pAdd.StateCommon.Back.Color2 = System.Drawing.Color.Aquamarine;
            this.pAdd.StateCommon.Back.Image = global::Quan_ly_may_bay.Properties.Resources.plus;
            this.pAdd.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.pAdd.StateCommon.Border.Color1 = System.Drawing.Color.Aqua;
            this.pAdd.StateCommon.Border.Color2 = System.Drawing.Color.Aquamarine;
            this.pAdd.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.pAdd.StateCommon.Border.Image = global::Quan_ly_may_bay.Properties.Resources.plus;
            this.pAdd.StateCommon.Border.Rounding = 10;
            this.pAdd.TabIndex = 31;
            this.pAdd.Values.Text = "";
            this.pAdd.Click += new System.EventHandler(this.pAdd_Click);
            // 
            // lblStt
            // 
            this.lblStt.Font = new System.Drawing.Font("Itim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStt.ForeColor = System.Drawing.Color.White;
            this.lblStt.Location = new System.Drawing.Point(387, 536);
            this.lblStt.Name = "lblStt";
            this.lblStt.Size = new System.Drawing.Size(47, 49);
            this.lblStt.TabIndex = 34;
            this.lblStt.Text = "0";
            this.lblStt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStt.TextChanged += new System.EventHandler(this.lblStt_TextChanged);
            // 
            // Add
            // 
            this.Add.BackgroundImage = global::Quan_ly_may_bay.Properties.Resources.arrow_right__1_;
            this.Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Add.Location = new System.Drawing.Point(440, 536);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(53, 50);
            this.Add.TabIndex = 33;
            this.Add.TabStop = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Substract
            // 
            this.Substract.BackgroundImage = global::Quan_ly_may_bay.Properties.Resources.arrow_left;
            this.Substract.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Substract.Location = new System.Drawing.Point(328, 536);
            this.Substract.Name = "Substract";
            this.Substract.Size = new System.Drawing.Size(53, 50);
            this.Substract.TabIndex = 32;
            this.Substract.TabStop = false;
            this.Substract.Click += new System.EventHandler(this.Substract_Click);
            // 
            // CapNhatLoTrinhBay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(821, 654);
            this.Controls.Add(this.lblStt);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Substract);
            this.Controls.Add(this.pAdd);
            this.Controls.Add(this.PanelTicket);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CapNhatLoTrinhBay";
            this.Opacity = 0.8D;
            this.Text = "CapNhatLoTrinhBay";
            ((System.ComponentModel.ISupportInitialize)(this.Add)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Substract)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel PanelTicket;
        private ComponentFactory.Krypton.Toolkit.KryptonButton pAdd;
        private System.Windows.Forms.Label lblStt;
        private System.Windows.Forms.PictureBox Add;
        private System.Windows.Forms.PictureBox Substract;
    }
}