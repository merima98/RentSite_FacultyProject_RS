namespace RentSite.WinUI.Apartments
{
    partial class frmApartmentsAddNew
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.KM = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.numFloorOne = new System.Windows.Forms.NumericUpDown();
            this.numRooms = new System.Windows.Forms.NumericUpDown();
            this.numFloors = new System.Windows.Forms.NumericUpDown();
            this.btnDeleteApartment = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.clbLineOfTransport = new System.Windows.Forms.CheckedListBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnAddPicture = new System.Windows.Forms.Button();
            this.txtPicture = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.picAddApartment = new System.Windows.Forms.PictureBox();
            this.btnSaveApartment = new System.Windows.Forms.Button();
            this.cbRented = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbNewlyBuilt = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTypeOfHeating = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbArmoredDoor = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbTypeOfApartment = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.dtpDateOfRenewal = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFloorOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFloors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddApartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OldLace;
            this.panel1.Controls.Add(this.KM);
            this.panel1.Controls.Add(this.numPrice);
            this.panel1.Controls.Add(this.numFloorOne);
            this.panel1.Controls.Add(this.numRooms);
            this.panel1.Controls.Add(this.numFloors);
            this.panel1.Controls.Add(this.btnDeleteApartment);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.clbLineOfTransport);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.btnAddPicture);
            this.panel1.Controls.Add(this.txtPicture);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.picAddApartment);
            this.panel1.Controls.Add(this.btnSaveApartment);
            this.panel1.Controls.Add(this.cbRented);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.cbNewlyBuilt);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtTypeOfHeating);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.cbArmoredDoor);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cmbTypeOfApartment);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cmbCity);
            this.panel1.Controls.Add(this.dtpDateOfRenewal);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtArea);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtAddress);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 606);
            this.panel1.TabIndex = 0;
            // 
            // KM
            // 
            this.KM.AutoSize = true;
            this.KM.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KM.Location = new System.Drawing.Point(375, 156);
            this.KM.Name = "KM";
            this.KM.Size = new System.Drawing.Size(35, 17);
            this.KM.TabIndex = 41;
            this.KM.Text = "KM";
            // 
            // numPrice
            // 
            this.numPrice.Location = new System.Drawing.Point(269, 151);
            this.numPrice.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(100, 22);
            this.numPrice.TabIndex = 41;
            this.numPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPrice.Validating += new System.ComponentModel.CancelEventHandler(this.numPrice_Validating);
            // 
            // numFloorOne
            // 
            this.numFloorOne.Location = new System.Drawing.Point(632, 91);
            this.numFloorOne.Name = "numFloorOne";
            this.numFloorOne.Size = new System.Drawing.Size(100, 22);
            this.numFloorOne.TabIndex = 40;
            this.numFloorOne.Validating += new System.ComponentModel.CancelEventHandler(this.numFloorOne_Validating);
            // 
            // numRooms
            // 
            this.numRooms.Location = new System.Drawing.Point(269, 248);
            this.numRooms.Name = "numRooms";
            this.numRooms.Size = new System.Drawing.Size(100, 22);
            this.numRooms.TabIndex = 39;
            this.numRooms.Validating += new System.ComponentModel.CancelEventHandler(this.numRooms_Validating);
            // 
            // numFloors
            // 
            this.numFloors.Location = new System.Drawing.Point(269, 200);
            this.numFloors.Name = "numFloors";
            this.numFloors.Size = new System.Drawing.Size(100, 22);
            this.numFloors.TabIndex = 38;
            this.numFloors.Validating += new System.ComponentModel.CancelEventHandler(this.numFloors_Validating);
            // 
            // btnDeleteApartment
            // 
            this.btnDeleteApartment.BackColor = System.Drawing.Color.Tomato;
            this.btnDeleteApartment.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteApartment.Location = new System.Drawing.Point(147, 550);
            this.btnDeleteApartment.Name = "btnDeleteApartment";
            this.btnDeleteApartment.Size = new System.Drawing.Size(100, 44);
            this.btnDeleteApartment.TabIndex = 37;
            this.btnDeleteApartment.Text = "Delete";
            this.btnDeleteApartment.UseVisualStyleBackColor = false;
            this.btnDeleteApartment.Click += new System.EventHandler(this.btnDeleteApartment_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(499, 454);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(115, 17);
            this.label17.TabIndex = 36;
            this.label17.Text = "Line of transport";
            // 
            // clbLineOfTransport
            // 
            this.clbLineOfTransport.FormattingEnabled = true;
            this.clbLineOfTransport.Location = new System.Drawing.Point(642, 454);
            this.clbLineOfTransport.Name = "clbLineOfTransport";
            this.clbLineOfTransport.Size = new System.Drawing.Size(60, 140);
            this.clbLineOfTransport.TabIndex = 35;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(269, 57);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(100, 22);
            this.txtDescription.TabIndex = 34;
            this.txtDescription.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescription_Validating);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(27, 59);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(82, 17);
            this.label16.TabIndex = 33;
            this.label16.Text = "Description";
            // 
            // btnAddPicture
            // 
            this.btnAddPicture.Location = new System.Drawing.Point(502, 396);
            this.btnAddPicture.Name = "btnAddPicture";
            this.btnAddPicture.Size = new System.Drawing.Size(105, 24);
            this.btnAddPicture.TabIndex = 32;
            this.btnAddPicture.Text = "Add picture";
            this.btnAddPicture.UseVisualStyleBackColor = true;
            this.btnAddPicture.Click += new System.EventHandler(this.btnAddPicture_Click);
            // 
            // txtPicture
            // 
            this.txtPicture.Location = new System.Drawing.Point(502, 368);
            this.txtPicture.Name = "txtPicture";
            this.txtPicture.Size = new System.Drawing.Size(105, 22);
            this.txtPicture.TabIndex = 31;
            this.txtPicture.Validating += new System.ComponentModel.CancelEventHandler(this.txtPicture_Validating);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(499, 334);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 17);
            this.label15.TabIndex = 30;
            this.label15.Text = "Picture";
            // 
            // picAddApartment
            // 
            this.picAddApartment.Location = new System.Drawing.Point(623, 310);
            this.picAddApartment.Name = "picAddApartment";
            this.picAddApartment.Size = new System.Drawing.Size(79, 61);
            this.picAddApartment.TabIndex = 29;
            this.picAddApartment.TabStop = false;
            // 
            // btnSaveApartment
            // 
            this.btnSaveApartment.Location = new System.Drawing.Point(269, 550);
            this.btnSaveApartment.Name = "btnSaveApartment";
            this.btnSaveApartment.Size = new System.Drawing.Size(100, 44);
            this.btnSaveApartment.TabIndex = 28;
            this.btnSaveApartment.Text = "Save";
            this.btnSaveApartment.UseVisualStyleBackColor = true;
            this.btnSaveApartment.Click += new System.EventHandler(this.btnSaveApartment_Click);
            // 
            // cbRented
            // 
            this.cbRented.AutoSize = true;
            this.cbRented.Location = new System.Drawing.Point(632, 287);
            this.cbRented.Name = "cbRented";
            this.cbRented.Size = new System.Drawing.Size(18, 17);
            this.cbRented.TabIndex = 27;
            this.cbRented.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(499, 287);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 17);
            this.label14.TabIndex = 26;
            this.label14.Text = "Is Rented? ";
            // 
            // cbNewlyBuilt
            // 
            this.cbNewlyBuilt.AutoSize = true;
            this.cbNewlyBuilt.Location = new System.Drawing.Point(632, 240);
            this.cbNewlyBuilt.Name = "cbNewlyBuilt";
            this.cbNewlyBuilt.Size = new System.Drawing.Size(18, 17);
            this.cbNewlyBuilt.TabIndex = 25;
            this.cbNewlyBuilt.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(499, 240);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 17);
            this.label13.TabIndex = 24;
            this.label13.Text = "Newly built?";
            // 
            // txtTypeOfHeating
            // 
            this.txtTypeOfHeating.Location = new System.Drawing.Point(632, 193);
            this.txtTypeOfHeating.Name = "txtTypeOfHeating";
            this.txtTypeOfHeating.Size = new System.Drawing.Size(100, 22);
            this.txtTypeOfHeating.TabIndex = 23;
            this.txtTypeOfHeating.Validating += new System.ComponentModel.CancelEventHandler(this.txtTypeOfHeating_Validating);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(499, 192);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 17);
            this.label12.TabIndex = 22;
            this.label12.Text = "Type of heating";
            // 
            // cbArmoredDoor
            // 
            this.cbArmoredDoor.AutoSize = true;
            this.cbArmoredDoor.Location = new System.Drawing.Point(632, 140);
            this.cbArmoredDoor.Name = "cbArmoredDoor";
            this.cbArmoredDoor.Size = new System.Drawing.Size(18, 17);
            this.cbArmoredDoor.TabIndex = 21;
            this.cbArmoredDoor.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(499, 140);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 17);
            this.label11.TabIndex = 20;
            this.label11.Text = "Armored door?";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(499, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "Floor";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(499, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Type of apartment";
            // 
            // cmbTypeOfApartment
            // 
            this.cmbTypeOfApartment.Font = new System.Drawing.Font("Calisto MT", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTypeOfApartment.FormattingEnabled = true;
            this.cmbTypeOfApartment.Location = new System.Drawing.Point(632, 36);
            this.cmbTypeOfApartment.Name = "cmbTypeOfApartment";
            this.cmbTypeOfApartment.Size = new System.Drawing.Size(100, 23);
            this.cmbTypeOfApartment.TabIndex = 16;
            this.cmbTypeOfApartment.Validating += new System.ComponentModel.CancelEventHandler(this.cmbTypeOfApartment_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(31, 396);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "City";
            // 
            // cmbCity
            // 
            this.cmbCity.Font = new System.Drawing.Font("Calisto MT", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(269, 389);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(100, 23);
            this.cmbCity.TabIndex = 14;
            this.cmbCity.Validating += new System.ComponentModel.CancelEventHandler(this.cmbCity_Validating);
            // 
            // dtpDateOfRenewal
            // 
            this.dtpDateOfRenewal.CalendarFont = new System.Drawing.Font("Calisto MT", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateOfRenewal.Location = new System.Drawing.Point(147, 344);
            this.dtpDateOfRenewal.Name = "dtpDateOfRenewal";
            this.dtpDateOfRenewal.Size = new System.Drawing.Size(222, 22);
            this.dtpDateOfRenewal.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(27, 347);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Date of renewal";
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(269, 304);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(100, 22);
            this.txtArea.TabIndex = 10;
            this.txtArea.Validating += new System.ComponentModel.CancelEventHandler(this.txtArea_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Area";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Number of rooms";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Number of floors";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Price";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(269, 102);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(100, 22);
            this.txtAddress.TabIndex = 2;
            this.txtAddress.Validating += new System.ComponentModel.CancelEventHandler(this.txtAddress_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Address";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calisto MT", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "New apartment";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmApartmentsAddNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 606);
            this.Controls.Add(this.panel1);
            this.Name = "frmApartmentsAddNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmApartmentsAddNew";
            this.Load += new System.EventHandler(this.frmApartmentsAddNew_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFloorOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFloors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAddApartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTypeOfHeating;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox cbArmoredDoor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbTypeOfApartment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbCity;
        private System.Windows.Forms.DateTimePicker dtpDateOfRenewal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveApartment;
        private System.Windows.Forms.CheckBox cbRented;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox cbNewlyBuilt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnAddPicture;
        private System.Windows.Forms.TextBox txtPicture;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox picAddApartment;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckedListBox clbLineOfTransport;
        private System.Windows.Forms.Button btnDeleteApartment;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.NumericUpDown numFloors;
        private System.Windows.Forms.NumericUpDown numRooms;
        private System.Windows.Forms.NumericUpDown numFloorOne;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label KM;
    }
}