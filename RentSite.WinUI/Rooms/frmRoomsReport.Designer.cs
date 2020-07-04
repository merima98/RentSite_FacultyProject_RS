namespace RentSite.WinUI.Rooms
{
    partial class frmRoomsReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoomsReport));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tytFilterByYear = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSelected = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvRoomsReport = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BeginRentalDateString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndRentalDateString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BeginRentalDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndRentalDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResidentialBuildingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Picture = new System.Windows.Forms.DataGridViewImageColumn();
            this.Rented = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelPrinting1 = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomsReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panelPrinting1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calisto MT", 13.8F);
            this.label1.Location = new System.Drawing.Point(28, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 28);
            this.label1.TabIndex = 13;
            this.label1.Text = "Rooms - report";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(587, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 23);
            this.label2.TabIndex = 15;
            this.label2.Text = "Filter by year";
            // 
            // tytFilterByYear
            // 
            this.tytFilterByYear.Location = new System.Drawing.Point(591, 46);
            this.tytFilterByYear.Name = "tytFilterByYear";
            this.tytFilterByYear.Size = new System.Drawing.Size(118, 22);
            this.tytFilterByYear.TabIndex = 16;
            this.tytFilterByYear.Validating += new System.ComponentModel.CancelEventHandler(this.tytFilterByYear_Validating);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(591, 74);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(118, 32);
            this.btnFilter.TabIndex = 17;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(275, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(239, 198);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // txtSelected
            // 
            this.txtSelected.Location = new System.Drawing.Point(410, 494);
            this.txtSelected.Name = "txtSelected";
            this.txtSelected.Size = new System.Drawing.Size(90, 22);
            this.txtSelected.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calisto MT", 13.8F);
            this.label5.Location = new System.Drawing.Point(531, 489);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 28);
            this.label5.TabIndex = 20;
            this.label5.Text = "KM";
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Location = new System.Drawing.Point(641, 485);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(122, 38);
            this.btnPrintPreview.TabIndex = 21;
            this.btnPrintPreview.Text = "Print preview";
            this.btnPrintPreview.UseVisualStyleBackColor = true;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calisto MT", 13.8F);
            this.label6.Location = new System.Drawing.Point(31, 488);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(313, 28);
            this.label6.TabIndex = 18;
            this.label6.Text = "Total profit for selected year: ";
            // 
            // dgvRoomsReport
            // 
            this.dgvRoomsReport.AllowUserToAddRows = false;
            this.dgvRoomsReport.AllowUserToDeleteRows = false;
            this.dgvRoomsReport.BackgroundColor = System.Drawing.Color.OldLace;
            this.dgvRoomsReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoomsReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Description,
            this.BeginRentalDateString,
            this.EndRentalDateString,
            this.TotalPrice,
            this.BeginRentalDate,
            this.EndRentalDate,
            this.UserId,
            this.ResidentialBuildingId,
            this.FirstName,
            this.LastName,
            this.Year,
            this.Picture,
            this.Rented});
            this.dgvRoomsReport.Location = new System.Drawing.Point(18, 211);
            this.dgvRoomsReport.Name = "dgvRoomsReport";
            this.dgvRoomsReport.ReadOnly = true;
            this.dgvRoomsReport.RowHeadersWidth = 51;
            this.dgvRoomsReport.RowTemplate.Height = 24;
            this.dgvRoomsReport.Size = new System.Drawing.Size(1009, 255);
            this.dgvRoomsReport.TabIndex = 23;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 125;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 125;
            // 
            // BeginRentalDateString
            // 
            this.BeginRentalDateString.DataPropertyName = "BeginRentalDateString";
            this.BeginRentalDateString.HeaderText = "Begin rental date";
            this.BeginRentalDateString.MinimumWidth = 6;
            this.BeginRentalDateString.Name = "BeginRentalDateString";
            this.BeginRentalDateString.ReadOnly = true;
            this.BeginRentalDateString.Width = 125;
            // 
            // EndRentalDateString
            // 
            this.EndRentalDateString.DataPropertyName = "EndRentalDateString";
            this.EndRentalDateString.HeaderText = "End rental date";
            this.EndRentalDateString.MinimumWidth = 6;
            this.EndRentalDateString.Name = "EndRentalDateString";
            this.EndRentalDateString.ReadOnly = true;
            this.EndRentalDateString.Width = 125;
            // 
            // TotalPrice
            // 
            this.TotalPrice.DataPropertyName = "TotalPrice";
            this.TotalPrice.HeaderText = "Total price in KM";
            this.TotalPrice.MinimumWidth = 6;
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.ReadOnly = true;
            this.TotalPrice.Width = 125;
            // 
            // BeginRentalDate
            // 
            this.BeginRentalDate.DataPropertyName = "BeginRentalDate";
            this.BeginRentalDate.HeaderText = "BeginRentalDate";
            this.BeginRentalDate.MinimumWidth = 6;
            this.BeginRentalDate.Name = "BeginRentalDate";
            this.BeginRentalDate.ReadOnly = true;
            this.BeginRentalDate.Visible = false;
            this.BeginRentalDate.Width = 125;
            // 
            // EndRentalDate
            // 
            this.EndRentalDate.DataPropertyName = "EndRentalDate";
            this.EndRentalDate.HeaderText = "EndRentalDate";
            this.EndRentalDate.MinimumWidth = 6;
            this.EndRentalDate.Name = "EndRentalDate";
            this.EndRentalDate.ReadOnly = true;
            this.EndRentalDate.Visible = false;
            this.EndRentalDate.Width = 125;
            // 
            // UserId
            // 
            this.UserId.DataPropertyName = "UserId";
            this.UserId.HeaderText = "UserId";
            this.UserId.MinimumWidth = 6;
            this.UserId.Name = "UserId";
            this.UserId.ReadOnly = true;
            this.UserId.Visible = false;
            this.UserId.Width = 125;
            // 
            // ResidentialBuildingId
            // 
            this.ResidentialBuildingId.DataPropertyName = "RoomId";
            this.ResidentialBuildingId.HeaderText = "RoomId";
            this.ResidentialBuildingId.MinimumWidth = 6;
            this.ResidentialBuildingId.Name = "ResidentialBuildingId";
            this.ResidentialBuildingId.ReadOnly = true;
            this.ResidentialBuildingId.Visible = false;
            this.ResidentialBuildingId.Width = 125;
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.HeaderText = "First name";
            this.FirstName.MinimumWidth = 6;
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            this.FirstName.Width = 125;
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "LastName";
            this.LastName.HeaderText = "Last name";
            this.LastName.MinimumWidth = 6;
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            this.LastName.Width = 125;
            // 
            // Year
            // 
            this.Year.DataPropertyName = "Year";
            this.Year.HeaderText = "Year";
            this.Year.MinimumWidth = 6;
            this.Year.Name = "Year";
            this.Year.ReadOnly = true;
            this.Year.Visible = false;
            this.Year.Width = 125;
            // 
            // Picture
            // 
            this.Picture.DataPropertyName = "Picture";
            this.Picture.HeaderText = "Picture";
            this.Picture.MinimumWidth = 6;
            this.Picture.Name = "Picture";
            this.Picture.ReadOnly = true;
            this.Picture.Visible = false;
            this.Picture.Width = 125;
            // 
            // Rented
            // 
            this.Rented.DataPropertyName = "Rented";
            this.Rented.HeaderText = "Rented";
            this.Rented.MinimumWidth = 6;
            this.Rented.Name = "Rented";
            this.Rented.ReadOnly = true;
            this.Rented.Visible = false;
            this.Rented.Width = 125;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // panelPrinting1
            // 
            this.panelPrinting1.Controls.Add(this.pictureBox1);
            this.panelPrinting1.Controls.Add(this.txtSelected);
            this.panelPrinting1.Controls.Add(this.dgvRoomsReport);
            this.panelPrinting1.Controls.Add(this.label5);
            this.panelPrinting1.Controls.Add(this.label1);
            this.panelPrinting1.Controls.Add(this.btnPrintPreview);
            this.panelPrinting1.Controls.Add(this.label2);
            this.panelPrinting1.Controls.Add(this.label6);
            this.panelPrinting1.Controls.Add(this.btnFilter);
            this.panelPrinting1.Controls.Add(this.tytFilterByYear);
            this.panelPrinting1.Location = new System.Drawing.Point(35, 12);
            this.panelPrinting1.Name = "panelPrinting1";
            this.panelPrinting1.Size = new System.Drawing.Size(1054, 526);
            this.panelPrinting1.TabIndex = 24;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmRoomsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(1127, 583);
            this.Controls.Add(this.panelPrinting1);
            this.Name = "frmRoomsReport";
            this.Text = "frmRoomsReport";
            this.Load += new System.EventHandler(this.frmRoomsReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomsReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panelPrinting1.ResumeLayout(false);
            this.panelPrinting1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tytFilterByYear;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtSelected;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvRoomsReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn BeginRentalDateString;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndRentalDateString;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn BeginRentalDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndRentalDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResidentialBuildingId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewImageColumn Picture;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Rented;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel panelPrinting1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}