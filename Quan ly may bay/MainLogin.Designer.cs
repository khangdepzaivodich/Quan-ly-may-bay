﻿namespace Quan_ly_may_bay
{
    partial class MainLogin
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelObject = new System.Windows.Forms.Panel();
            this.XemThongTin = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label1 = new System.Windows.Forms.Label();
            this.fpanelBtn = new System.Windows.Forms.FlowLayoutPanel();
            this.NameObject = new System.Windows.Forms.Label();
            this.ImageUsername = new System.Windows.Forms.PictureBox();
            this.panelObject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageUsername)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMain.Location = new System.Drawing.Point(251, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(821, 643);
            this.panelMain.TabIndex = 0;
            // 
            // panelObject
            // 
            this.panelObject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelObject.Controls.Add(this.XemThongTin);
            this.panelObject.Controls.Add(this.label1);
            this.panelObject.Controls.Add(this.fpanelBtn);
            this.panelObject.Controls.Add(this.NameObject);
            this.panelObject.Controls.Add(this.ImageUsername);
            this.panelObject.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelObject.Location = new System.Drawing.Point(0, 0);
            this.panelObject.Name = "panelObject";
            this.panelObject.Size = new System.Drawing.Size(252, 643);
            this.panelObject.TabIndex = 1;
            // 
            // XemThongTin
            // 
            this.XemThongTin.Location = new System.Drawing.Point(13, 85);
            this.XemThongTin.Name = "XemThongTin";
            this.XemThongTin.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.XemThongTin.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.XemThongTin.OverrideDefault.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.XemThongTin.Size = new System.Drawing.Size(42, 32);
            this.XemThongTin.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.XemThongTin.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.XemThongTin.StateCommon.Back.Image = global::Quan_ly_may_bay.Properties.Resources.id_badge_2;
            this.XemThongTin.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.Stretch;
            this.XemThongTin.StateCommon.Border.DrawBorders = ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.None;
            this.XemThongTin.TabIndex = 4;
            this.XemThongTin.Values.Text = "";
            this.XemThongTin.Click += new System.EventHandler(this.xemThongTin);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Itim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(107, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Khách hàng";
            // 
            // fpanelBtn
            // 
            this.fpanelBtn.AutoScroll = true;
            this.fpanelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fpanelBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fpanelBtn.Location = new System.Drawing.Point(0, 123);
            this.fpanelBtn.Name = "fpanelBtn";
            this.fpanelBtn.Size = new System.Drawing.Size(252, 520);
            this.fpanelBtn.TabIndex = 2;
            // 
            // NameObject
            // 
            this.NameObject.AutoSize = true;
            this.NameObject.BackColor = System.Drawing.Color.Transparent;
            this.NameObject.Font = new System.Drawing.Font("Itim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameObject.ForeColor = System.Drawing.Color.White;
            this.NameObject.Location = new System.Drawing.Point(107, 12);
            this.NameObject.Name = "NameObject";
            this.NameObject.Size = new System.Drawing.Size(106, 24);
            this.NameObject.TabIndex = 1;
            this.NameObject.Text = "Username";
            // 
            // ImageUsername
            // 
            this.ImageUsername.BackColor = System.Drawing.Color.Transparent;
            this.ImageUsername.BackgroundImage = global::Quan_ly_may_bay.Properties.Resources.user;
            this.ImageUsername.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImageUsername.Location = new System.Drawing.Point(12, 12);
            this.ImageUsername.Name = "ImageUsername";
            this.ImageUsername.Size = new System.Drawing.Size(69, 67);
            this.ImageUsername.TabIndex = 0;
            this.ImageUsername.TabStop = false;
            // 
            // MainLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Quan_ly_may_bay.Properties.Resources.hinh_anh_may_bay1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1072, 643);
            this.Controls.Add(this.panelObject);
            this.Controls.Add(this.panelMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainLogin";
            this.panelObject.ResumeLayout(false);
            this.panelObject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageUsername)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelObject;
        private System.Windows.Forms.Label NameObject;
        private System.Windows.Forms.PictureBox ImageUsername;
        private System.Windows.Forms.FlowLayoutPanel fpanelBtn;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton XemThongTin;
    }
}