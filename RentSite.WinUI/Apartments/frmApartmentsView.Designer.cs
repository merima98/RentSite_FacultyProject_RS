using System.Windows.Forms;

namespace RentSite.WinUI.Apartments
{
    partial class frmApartmentsView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmApartmentsView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvApartments = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Floor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfRooms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NubmerOfFloors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArmoredDoor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeOfHeating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewlyBuilt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfRenewal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfPublication = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CityId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeOfResidentialBuildingId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Picture = new System.Windows.Forms.DataGridViewImageColumn();
            this.Rented = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.cmbTypeOfApartment = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApartments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OldLace;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dgvApartments);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbCity);
            this.panel1.Controls.Add(this.cmbTypeOfApartment);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1082, 637);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(407, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "City";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(407, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Type of apartment";
            // 
            // dgvApartments
            // 
            this.dgvApartments.AllowUserToAddRows = false;
            this.dgvApartments.AllowUserToDeleteRows = false;
            this.dgvApartments.BackgroundColor = System.Drawing.Color.OldLace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApartments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvApartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApartments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Floor,
            this.NumberOfRooms,
            this.NubmerOfFloors,
            this.ArmoredDoor,
            this.TypeOfHeating,
            this.Area,
            this.NewlyBuilt,
            this.DateOfRenewal,
            this.DateOfPublication,
            this.CityId,
            this.TypeOfResidentialBuildingId,
            this.Description,
            this.Address,
            this.Picture,
            this.Rented,
            this.Price});
            this.dgvApartments.Location = new System.Drawing.Point(12, 235);
            this.dgvApartments.Name = "dgvApartments";
            this.dgvApartments.ReadOnly = true;
            this.dgvApartments.RowHeadersWidth = 100;
            this.dgvApartments.RowTemplate.Height = 100;
            this.dgvApartments.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApartments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApartments.Size = new System.Drawing.Size(1058, 276);
            this.dgvApartments.TabIndex = 6;
            this.dgvApartments.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvApartments_MouseDoubleClick);
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
            // Floor
            // 
            this.Floor.DataPropertyName = "Floor";
            this.Floor.HeaderText = "Floor";
            this.Floor.MinimumWidth = 6;
            this.Floor.Name = "Floor";
            this.Floor.ReadOnly = true;
            this.Floor.Visible = false;
            this.Floor.Width = 125;
            // 
            // NumberOfRooms
            // 
            this.NumberOfRooms.DataPropertyName = "NumberOfRooms";
            this.NumberOfRooms.HeaderText = "NumberOfRooms";
            this.NumberOfRooms.MinimumWidth = 6;
            this.NumberOfRooms.Name = "NumberOfRooms";
            this.NumberOfRooms.ReadOnly = true;
            this.NumberOfRooms.Visible = false;
            this.NumberOfRooms.Width = 125;
            // 
            // NubmerOfFloors
            // 
            this.NubmerOfFloors.DataPropertyName = "NubmerOfFloors";
            this.NubmerOfFloors.HeaderText = "NubmerOfFloors";
            this.NubmerOfFloors.MinimumWidth = 6;
            this.NubmerOfFloors.Name = "NubmerOfFloors";
            this.NubmerOfFloors.ReadOnly = true;
            this.NubmerOfFloors.Visible = false;
            this.NubmerOfFloors.Width = 125;
            // 
            // ArmoredDoor
            // 
            this.ArmoredDoor.DataPropertyName = "ArmoredDoor";
            this.ArmoredDoor.HeaderText = "ArmoredDoor";
            this.ArmoredDoor.MinimumWidth = 6;
            this.ArmoredDoor.Name = "ArmoredDoor";
            this.ArmoredDoor.ReadOnly = true;
            this.ArmoredDoor.Visible = false;
            this.ArmoredDoor.Width = 125;
            // 
            // TypeOfHeating
            // 
            this.TypeOfHeating.DataPropertyName = "TypeOfHeating";
            this.TypeOfHeating.HeaderText = "TypeOfHeating";
            this.TypeOfHeating.MinimumWidth = 6;
            this.TypeOfHeating.Name = "TypeOfHeating";
            this.TypeOfHeating.ReadOnly = true;
            this.TypeOfHeating.Visible = false;
            this.TypeOfHeating.Width = 125;
            // 
            // Area
            // 
            this.Area.DataPropertyName = "Area";
            this.Area.HeaderText = "Area";
            this.Area.MinimumWidth = 6;
            this.Area.Name = "Area";
            this.Area.ReadOnly = true;
            this.Area.Width = 125;
            // 
            // NewlyBuilt
            // 
            this.NewlyBuilt.DataPropertyName = "NewlyBuilt";
            this.NewlyBuilt.HeaderText = "NewlyBuilt";
            this.NewlyBuilt.MinimumWidth = 6;
            this.NewlyBuilt.Name = "NewlyBuilt";
            this.NewlyBuilt.ReadOnly = true;
            this.NewlyBuilt.Visible = false;
            this.NewlyBuilt.Width = 125;
            // 
            // DateOfRenewal
            // 
            this.DateOfRenewal.DataPropertyName = "DateOfRenewal";
            this.DateOfRenewal.HeaderText = "DateOfRenewal";
            this.DateOfRenewal.MinimumWidth = 6;
            this.DateOfRenewal.Name = "DateOfRenewal";
            this.DateOfRenewal.ReadOnly = true;
            this.DateOfRenewal.Visible = false;
            this.DateOfRenewal.Width = 125;
            // 
            // DateOfPublication
            // 
            this.DateOfPublication.DataPropertyName = "DateOfPublication";
            this.DateOfPublication.HeaderText = "Date of publication";
            this.DateOfPublication.MinimumWidth = 6;
            this.DateOfPublication.Name = "DateOfPublication";
            this.DateOfPublication.ReadOnly = true;
            this.DateOfPublication.Width = 125;
            // 
            // CityId
            // 
            this.CityId.DataPropertyName = "CityId";
            this.CityId.HeaderText = "CityId";
            this.CityId.MinimumWidth = 6;
            this.CityId.Name = "CityId";
            this.CityId.ReadOnly = true;
            this.CityId.Visible = false;
            this.CityId.Width = 125;
            // 
            // TypeOfResidentialBuildingId
            // 
            this.TypeOfResidentialBuildingId.DataPropertyName = "TypeOfResidentialBuildingId";
            this.TypeOfResidentialBuildingId.HeaderText = "TypeOfResidentialBuildingId";
            this.TypeOfResidentialBuildingId.MinimumWidth = 6;
            this.TypeOfResidentialBuildingId.Name = "TypeOfResidentialBuildingId";
            this.TypeOfResidentialBuildingId.ReadOnly = true;
            this.TypeOfResidentialBuildingId.Visible = false;
            this.TypeOfResidentialBuildingId.Width = 125;
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
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.MinimumWidth = 6;
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 125;
            // 
            // Picture
            // 
            this.Picture.DataPropertyName = "Picture";
            this.Picture.HeaderText = "Picture";
            this.Picture.MinimumWidth = 6;
            this.Picture.Name = "Picture";
            this.Picture.ReadOnly = true;
            this.Picture.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Picture.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Picture.Width = 200;
            // 
            // Rented
            // 
            this.Rented.DataPropertyName = "Rented";
            this.Rented.HeaderText = "Rented";
            this.Rented.MinimumWidth = 6;
            this.Rented.Name = "Rented";
            this.Rented.ReadOnly = true;
            this.Rented.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Rented.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Rented.Width = 125;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calisto MT", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Apartments - View";
            // 
            // cmbCity
            // 
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(552, 100);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(121, 28);
            this.cmbCity.TabIndex = 3;
            this.cmbCity.SelectedIndexChanged += new System.EventHandler(this.cmbCity_SelectedIndexChanged);
            // 
            // cmbTypeOfApartment
            // 
            this.cmbTypeOfApartment.FormattingEnabled = true;
            this.cmbTypeOfApartment.Location = new System.Drawing.Point(552, 34);
            this.cmbTypeOfApartment.Name = "cmbTypeOfApartment";
            this.cmbTypeOfApartment.Size = new System.Drawing.Size(121, 28);
            this.cmbTypeOfApartment.TabIndex = 0;
            this.cmbTypeOfApartment.SelectedIndexChanged += new System.EventHandler(this.cmbTypeOfApartment_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(216, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 206);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // frmApartmentsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 637);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmApartmentsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apartment view";
            this.Load += new System.EventHandler(this.frmApartmentsView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApartments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbCity;
        private System.Windows.Forms.ComboBox cmbTypeOfApartment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvApartments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Floor;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfRooms;
        private System.Windows.Forms.DataGridViewTextBoxColumn NubmerOfFloors;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArmoredDoor;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeOfHeating;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewlyBuilt;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfRenewal;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfPublication;
        private System.Windows.Forms.DataGridViewTextBoxColumn CityId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeOfResidentialBuildingId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewImageColumn Picture;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Rented;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
    }
}