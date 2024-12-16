namespace Quan_ly_may_bay
{
    partial class PQ
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
            this.label1 = new System.Windows.Forms.Label();
            this.sqlDataAdapter1 = new Microsoft.Data.SqlClient.SqlDataAdapter();
            this.datas = new System.Windows.Forms.DataGridView();
            this.PhanQuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ViewTicket = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FlightItinerary = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CreateFlight = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ManageStaff = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FinancialStatistic = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.datas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Itim", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(236, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "BẢNG PHÂN QUYỀN";
            // 
            // datas
            // 
            this.datas.AllowUserToOrderColumns = true;
            this.datas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PhanQuyen,
            this.ViewTicket,
            this.FlightItinerary,
            this.CreateFlight,
            this.ManageStaff,
            this.FinancialStatistic});
            this.datas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.datas.Location = new System.Drawing.Point(0, 124);
            this.datas.Name = "datas";
            this.datas.RowHeadersWidth = 51;
            this.datas.RowTemplate.Height = 24;
            this.datas.Size = new System.Drawing.Size(800, 435);
            this.datas.TabIndex = 4;
            this.datas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_CellClick);
            // 
            // PhanQuyen
            // 
            this.PhanQuyen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PhanQuyen.DataPropertyName = "PQ";
            this.PhanQuyen.HeaderText = "PhanQuyen";
            this.PhanQuyen.MinimumWidth = 6;
            this.PhanQuyen.Name = "PhanQuyen";
            // 
            // ViewTicket
            // 
            this.ViewTicket.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ViewTicket.DataPropertyName = "ViewTicket";
            this.ViewTicket.HeaderText = "ViewTicket";
            this.ViewTicket.MinimumWidth = 6;
            this.ViewTicket.Name = "ViewTicket";
            this.ViewTicket.Width = 79;
            // 
            // FlightItinerary
            // 
            this.FlightItinerary.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.FlightItinerary.DataPropertyName = "FlightItinerary";
            this.FlightItinerary.HeaderText = "Flight Itinerary";
            this.FlightItinerary.MinimumWidth = 6;
            this.FlightItinerary.Name = "FlightItinerary";
            this.FlightItinerary.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FlightItinerary.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.FlightItinerary.Width = 118;
            // 
            // CreateFlight
            // 
            this.CreateFlight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.CreateFlight.DataPropertyName = "CreateFlight";
            this.CreateFlight.HeaderText = "Create Flight";
            this.CreateFlight.MinimumWidth = 6;
            this.CreateFlight.Name = "CreateFlight";
            this.CreateFlight.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CreateFlight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CreateFlight.Width = 111;
            // 
            // ManageStaff
            // 
            this.ManageStaff.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ManageStaff.DataPropertyName = "ManageStaff";
            this.ManageStaff.HeaderText = "Manage Staff";
            this.ManageStaff.MinimumWidth = 6;
            this.ManageStaff.Name = "ManageStaff";
            this.ManageStaff.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ManageStaff.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ManageStaff.Width = 115;
            // 
            // FinancialStatistic
            // 
            this.FinancialStatistic.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.FinancialStatistic.DataPropertyName = "FinancialStatistics";
            this.FinancialStatistic.HeaderText = "Financial Statistics";
            this.FinancialStatistic.MinimumWidth = 6;
            this.FinancialStatistic.Name = "FinancialStatistic";
            this.FinancialStatistic.Width = 111;
            // 
            // PQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 559);
            this.Controls.Add(this.datas);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PQ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PQ";
            ((System.ComponentModel.ISupportInitialize)(this.datas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Microsoft.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
        private System.Windows.Forms.DataGridView datas;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhanQuyen;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ViewTicket;
        private System.Windows.Forms.DataGridViewCheckBoxColumn FlightItinerary;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CreateFlight;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ManageStaff;
        private System.Windows.Forms.DataGridViewCheckBoxColumn FinancialStatistic;
    }
}