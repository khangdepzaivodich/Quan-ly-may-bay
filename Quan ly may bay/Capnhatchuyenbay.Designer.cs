namespace Quan_ly_may_bay
{
    partial class Capnhatchuyenbay
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
            this.lblStt = new System.Windows.Forms.Label();
            this.Add = new System.Windows.Forms.PictureBox();
            this.Substract = new System.Windows.Forms.PictureBox();
            this.pAdd = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.Add)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Substract)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelTicket
            // 
            this.PanelTicket.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PanelTicket.Location = new System.Drawing.Point(28, 27);
            this.PanelTicket.Name = "PanelTicket";
            this.PanelTicket.Size = new System.Drawing.Size(765, 505);
            this.PanelTicket.TabIndex = 15;
            this.PanelTicket.WrapContents = false;
            // 
            // lblStt
            // 
            this.lblStt.Font = new System.Drawing.Font("Itim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStt.ForeColor = System.Drawing.Color.White;
            this.lblStt.Location = new System.Drawing.Point(383, 535);
            this.lblStt.Name = "lblStt";
            this.lblStt.Size = new System.Drawing.Size(47, 49);
            this.lblStt.TabIndex = 22;
            this.lblStt.Text = "0";
            this.lblStt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStt.TextChanged += new System.EventHandler(this.lblStt_TextChanged);
            // 
            // Add
            // 
            this.Add.BackgroundImage = global::Quan_ly_may_bay.Properties.Resources.arrow_right__1_;
            this.Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Add.Location = new System.Drawing.Point(436, 535);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(53, 50);
            this.Add.TabIndex = 21;
            this.Add.TabStop = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Substract
            // 
            this.Substract.BackgroundImage = global::Quan_ly_may_bay.Properties.Resources.arrow_left;
            this.Substract.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Substract.Location = new System.Drawing.Point(324, 535);
            this.Substract.Name = "Substract";
            this.Substract.Size = new System.Drawing.Size(53, 50);
            this.Substract.TabIndex = 20;
            this.Substract.TabStop = false;
            this.Substract.Click += new System.EventHandler(this.Substract_Click);
            // 
            // pAdd
            // 
            this.pAdd.Location = new System.Drawing.Point(757, 577);
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
            this.pAdd.TabIndex = 32;
            this.pAdd.Values.Text = "";
            this.pAdd.Click += new System.EventHandler(this.pAdd_Click);
            // 
            // Capnhatchuyenbay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(821, 644);
            this.Controls.Add(this.pAdd);
            this.Controls.Add(this.lblStt);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Substract);
            this.Controls.Add(this.PanelTicket);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Capnhatchuyenbay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Border.Rounding = 30;
            this.Text = "QLMB";
            ((System.ComponentModel.ISupportInitialize)(this.Add)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Substract)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel PanelTicket;
        private System.Windows.Forms.Label lblStt;
        private System.Windows.Forms.PictureBox Add;
        private System.Windows.Forms.PictureBox Substract;
        private ComponentFactory.Krypton.Toolkit.KryptonButton pAdd;
    }
}