namespace Quan_ly_may_bay
{
    partial class ResetPassForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ConfirmPassTextBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.PasswordTexBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SubmitButton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.PasswordError = new System.Windows.Forms.ErrorProvider(this.components);
            this.ConfirmPasswordError = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConfirmPasswordError)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Itim", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(150, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Reset Password";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Quan_ly_may_bay.Properties.Resources.nen_removebg_preview;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(4, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 89);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // ConfirmPassTextBox
            // 
            this.ConfirmPassTextBox.Location = new System.Drawing.Point(250, 233);
            this.ConfirmPassTextBox.Name = "ConfirmPassTextBox";
            this.ConfirmPassTextBox.PasswordChar = '*';
            this.ConfirmPassTextBox.Size = new System.Drawing.Size(258, 39);
            this.ConfirmPassTextBox.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(176)))), ((int)(((byte)(238)))));
            this.ConfirmPassTextBox.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(176)))), ((int)(((byte)(238)))));
            this.ConfirmPassTextBox.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.ConfirmPassTextBox.StateCommon.Border.Rounding = 20;
            this.ConfirmPassTextBox.TabIndex = 13;
            // 
            // PasswordTexBox
            // 
            this.PasswordTexBox.Location = new System.Drawing.Point(250, 181);
            this.PasswordTexBox.Name = "PasswordTexBox";
            this.PasswordTexBox.PasswordChar = '*';
            this.PasswordTexBox.Size = new System.Drawing.Size(258, 39);
            this.PasswordTexBox.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(176)))), ((int)(((byte)(238)))));
            this.PasswordTexBox.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(176)))), ((int)(((byte)(238)))));
            this.PasswordTexBox.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.PasswordTexBox.StateCommon.Border.Rounding = 20;
            this.PasswordTexBox.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Itim", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 28);
            this.label3.TabIndex = 11;
            this.label3.Text = "Confirm Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Itim", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 28);
            this.label2.TabIndex = 10;
            this.label2.Text = "New Password";
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(228, 327);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(176)))), ((int)(((byte)(238)))));
            this.SubmitButton.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(176)))), ((int)(((byte)(238)))));
            this.SubmitButton.OverrideDefault.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.SubmitButton.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(176)))), ((int)(((byte)(238)))));
            this.SubmitButton.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(176)))), ((int)(((byte)(238)))));
            this.SubmitButton.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.SubmitButton.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.SubmitButton.OverrideDefault.Border.Width = 1;
            this.SubmitButton.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.SubmitButton.OverrideDefault.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.SubmitButton.OverrideFocus.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.SubmitButton.OverrideFocus.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.SubmitButton.OverrideFocus.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.SubmitButton.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.SubmitButton.Size = new System.Drawing.Size(111, 51);
            this.SubmitButton.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(176)))), ((int)(((byte)(238)))));
            this.SubmitButton.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(176)))), ((int)(((byte)(238)))));
            this.SubmitButton.StateCommon.Back.ColorAngle = 90F;
            this.SubmitButton.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(176)))), ((int)(((byte)(238)))));
            this.SubmitButton.StateCommon.Border.Color2 = System.Drawing.Color.Cyan;
            this.SubmitButton.StateCommon.Border.ColorAngle = 90F;
            this.SubmitButton.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.SubmitButton.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.SubmitButton.StateCommon.Border.Rounding = 20;
            this.SubmitButton.StateCommon.Border.Width = 1;
            this.SubmitButton.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.SubmitButton.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.SubmitButton.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Itim", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitButton.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(176)))), ((int)(((byte)(238)))));
            this.SubmitButton.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(176)))), ((int)(((byte)(238)))));
            this.SubmitButton.StatePressed.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.SubmitButton.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(176)))), ((int)(((byte)(238)))));
            this.SubmitButton.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(176)))), ((int)(((byte)(238)))));
            this.SubmitButton.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.SubmitButton.StatePressed.Border.Rounding = 20;
            this.SubmitButton.StatePressed.Border.Width = 1;
            this.SubmitButton.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.SubmitButton.StatePressed.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.SubmitButton.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.SubmitButton.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.SubmitButton.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(176)))), ((int)(((byte)(238)))));
            this.SubmitButton.StateTracking.Border.Color2 = System.Drawing.Color.Cyan;
            this.SubmitButton.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.SubmitButton.StateTracking.Border.Rounding = 20;
            this.SubmitButton.StateTracking.Border.Width = 1;
            this.SubmitButton.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(176)))), ((int)(((byte)(238)))));
            this.SubmitButton.StateTracking.Content.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(176)))), ((int)(((byte)(238)))));
            this.SubmitButton.TabIndex = 14;
            this.SubmitButton.TabStop = false;
            this.SubmitButton.Values.Text = "Submit";
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // PasswordError
            // 
            this.PasswordError.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.PasswordError.ContainerControl = this;
            // 
            // ConfirmPasswordError
            // 
            this.ConfirmPasswordError.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ConfirmPasswordError.ContainerControl = this;
            // 
            // ResetPassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 416);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.ConfirmPassTextBox);
            this.Controls.Add(this.PasswordTexBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ResetPassForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.StateCommon.Border.Rounding = 30;
            this.StateCommon.Border.Width = 1;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConfirmPasswordError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox ConfirmPassTextBox;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox PasswordTexBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton SubmitButton;
        private System.Windows.Forms.ErrorProvider PasswordError;
        private System.Windows.Forms.ErrorProvider ConfirmPasswordError;
    }
}