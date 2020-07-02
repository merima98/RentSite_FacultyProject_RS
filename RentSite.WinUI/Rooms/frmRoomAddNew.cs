using RentSite.Model;
using RentSite.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentSite.WinUI.Rooms
{
    public partial class frmRoomAddNew : Form
    {
        private readonly APIService _roomService = new APIService("Room");
        private readonly APIService _lineOfTransportService = new APIService("LineOfTransport");
        private readonly APIService _cityServiceService = new APIService("City");
        private readonly APIService _typeOfRoomService = new APIService("TypeOfRoom");

        private int? _roomID = null;
        public frmRoomAddNew( int ?roomID=null)
        {
            InitializeComponent();
            _roomID = roomID;
        }

        private async void frmRoomAddNew_Load(object sender, EventArgs e)
        {
            await LoadCity();
            await LoadTypeOfRoom();

            var typeOfLineTransport = await _lineOfTransportService.Get<IList<Model.LineOfTransport>>(null);

            clbLineOfTransport.DataSource = typeOfLineTransport;
            clbLineOfTransport.DisplayMember = "Name";

            if (_roomID.HasValue)
            {
                var room = await _roomService.GetById<Model.Room>(_roomID);
                txtAddress.Text = room.Address;
                txtArea.Text = room.Area;
                txtDescription.Text = room.Description;
                numFloor.Value =Convert.ToInt32( room.Floor);
                numPrice.Value = Convert.ToDecimal(room.Price);
                txtTypeOfHeating.Text = room.TypeOfHeating;
            }
        }

        private async Task LoadCity()
        {
            var result = await _cityServiceService.Get<List<Model.City>>(null);
            result.Insert(0, new Model.City());
            cmbCity.DataSource = result;
            cmbCity.DisplayMember = "Name";
            cmbCity.ValueMember = "Id";
        }

        private async Task LoadTypeOfRoom()
        {
            var result = await _typeOfRoomService.Get<List<Model.TypeOfRoom>>(null);
            result.Insert(0, new Model.TypeOfRoom());
            cmbTypeOfRoom.DataSource = result;
            cmbTypeOfRoom.DisplayMember = "Name";
            cmbTypeOfRoom.ValueMember = "Id";
        }

        RoomInsertRequest request = new RoomInsertRequest();

        private async void btnSaveRoom_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var lineOfTransportList = clbLineOfTransport.CheckedItems.Cast<LineOfTransport>();
                var lineOfTransportListId = lineOfTransportList.Select(x => x.Id).ToList();

                

                if (_roomID == null)  //insert
                {
                    var idCityId = cmbCity.SelectedValue;

                    if (int.TryParse(idCityId.ToString(), out int idCity))
                    {
                        request.CityId = idCity;
                    }

                    var typeOfRoom = cmbTypeOfRoom.SelectedValue;
                    if (int.TryParse(typeOfRoom.ToString(), out int idTypeOfApartment))
                    {
                        request.TypeOfRoomId = idTypeOfApartment;
                    }
                    request.LineOfTransport = lineOfTransportListId;
                    request.DateOfPublication = DateTime.Now;
                    request.Description = txtDescription.Text;
                    request.Address = txtAddress.Text;
                    request.Area = txtArea.Text;
                    request.ArmoredDoor = cbArmoredDoor.Checked;
                    request.DateOfRenewal = dtpDateOfRenewal.Value;
                    request.Price = Convert.ToDecimal(numPrice.Value);
                    request.Floor = Convert.ToInt32(numFloor.Value);
                    request.TypeOfHeating = txtTypeOfHeating.Text;
                    request.Rented = cbRented.Checked;
                    request.NewlyBuilt = cbNewlyBuilt.Checked;

                    var room = await _roomService.Insert<Model.Room>(request);
                }
                else //update
                {
                    var idCityId = cmbCity.SelectedValue;

                    if (int.TryParse(idCityId.ToString(), out int idCity))
                    {
                        request.CityId = idCity;
                    }

                    var typeOfRoom = cmbTypeOfRoom.SelectedValue;
                    if (int.TryParse(typeOfRoom.ToString(), out int idTypeOfApartment))
                    {
                        request.TypeOfRoomId = idTypeOfApartment;
                    }
                    request.LineOfTransport = lineOfTransportListId;
                    request.DateOfPublication = DateTime.Now;
                    request.Description = txtDescription.Text;
                    request.Address = txtAddress.Text;
                    request.Area = txtArea.Text;
                    request.ArmoredDoor = cbArmoredDoor.Checked;
                    request.DateOfRenewal = dtpDateOfRenewal.Value;
                    request.Price = Convert.ToDecimal(numPrice.Value);
                    request.Floor = Convert.ToInt32(numFloor.Value);
                    request.TypeOfHeating = txtTypeOfHeating.Text;
                    request.Rented = cbRented.Checked;
                    request.NewlyBuilt = cbNewlyBuilt.Checked;

                    var room = await _roomService.Update<Model.Room>(_roomID, request);
                }
                MessageBox.Show("Operation successfully performed!");
                this.Close(); 
            }
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;

                var file = File.ReadAllBytes(fileName);

                request.Picture = file;
                txtPicture.Text = fileName;

                Image image = Image.FromFile(fileName);
                image = Resize(image, 50, 50);
                picAddApartment.Image = image;
            }
        }
        private Image Resize(Image img, int iWidth, int iHeight) 
        {
            Bitmap bmp = new Bitmap(iWidth, iHeight);
            Graphics graphic = Graphics.FromImage((Image)bmp);
            graphic.DrawImage(img, 0, 0, iWidth, iHeight);

            return (Image)bmp;
        }
        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                errorProvider.SetError(txtDescription, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtDescription, null);
            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                errorProvider.SetError(txtAddress, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtAddress, null);
            }
        }

        private void txtArea_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtArea.Text))
            {
                errorProvider.SetError(txtArea, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtArea, null);
            }
        }

        private void cmbCity_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbCity.Text))
            {
                errorProvider.SetError(cmbCity, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbCity, null);
            }
        }

        private void txtPicture_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPicture.Text))
            {
                errorProvider.SetError(txtPicture, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPicture, null);
            }
        }

        private void cmbTypeOfRoom_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbTypeOfRoom.Text))
            {
                errorProvider.SetError(cmbTypeOfRoom, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(cmbTypeOfRoom, null);
            }
        }

        private void txtTypeOfHeating_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTypeOfHeating.Text))
            {
                errorProvider.SetError(txtTypeOfHeating, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtTypeOfHeating, null);
            }
        }

        private async void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (_roomID != null) 
            {
                await _roomService.Delete<Model.Room>(_roomID);
                MessageBox.Show("Operation successfully performed!");
                this.Close();

            }
        }

        private void numPrice_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(numPrice.Value.ToString()))
            {
                errorProvider.SetError(numPrice, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(numPrice, null);
            }
        }

        private void numFloor_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(numFloor.Value.ToString()))
            {
                errorProvider.SetError(numFloor, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(numFloor, null);
            }
        }

     
    }
}
