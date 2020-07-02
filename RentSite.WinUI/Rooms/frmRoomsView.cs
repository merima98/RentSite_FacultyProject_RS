using RentSite.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentSite.WinUI.Rooms
{
    public partial class frmRoomsView : Form
    {
        private readonly APIService _roomService = new APIService("Room");
        private readonly APIService _cityService = new APIService("City");
        private readonly APIService _typefRoom = new APIService("TypeOfRoom");

        public frmRoomsView()
        {
            InitializeComponent();
            this.dgvRooms.DataError += this.DataGridView_DataError;
        }
        void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        protected override void OnClosing(CancelEventArgs e)  //ovo sam zadnje dodala
        {
            this.WindowState = FormWindowState.Normal;
        }

        private async void frmRoomsView_Load(object sender, EventArgs e)
        {
            await LoadCity();
            await LoadTypeOfRoom();

            var list = await _roomService.Get<List<Model.Room>>();
            dgvRooms.DataSource = list;
        }

        private async Task LoadCity()
        {
            var result = await _cityService.Get<List<Model.City>>(null);
            result.Insert(0, new Model.City());
            cmbCity.DataSource = result;
            cmbCity.DisplayMember = "Name";
            cmbCity.ValueMember = "Id";
        }

        private async Task LoadTypeOfRoom()
        {
            var result = await _typefRoom.Get<List<Model.TypeOfRoom>>(null);
            result.Insert(0, new Model.TypeOfRoom());
            cmbTypeOfRoom.DataSource = result;
            cmbTypeOfRoom.DisplayMember = "Name";
            cmbTypeOfRoom.ValueMember = "Id";
        }

        private async void cmbTypeOfRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idTypeOfRoom = cmbTypeOfRoom.SelectedValue;

            if (int.TryParse(idTypeOfRoom.ToString(), out int id))
            {
                await LoadRooms(id);
            }
        }
        private async Task LoadRooms(int id)
        {
            var result = await _roomService.Get<List<Model.Room>>(new RoomSearchRequest()
            {
                TypeOfRoomId = id
            });
            dgvRooms.DataSource = result;
        }

        private async void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idCityObje = cmbCity.SelectedValue;
            if (int.TryParse(idCityObje.ToString(), out int id))
            {
                await LoadCities(id);
            }
        }

        private async Task LoadCities(int cityId)
        {
            var result = await _roomService.Get<List<Model.Room>>(new RoomSearchRequest()
            {
                CityId = cityId
            });
            dgvRooms.DataSource = result;
        }

        private void dgvRooms_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvRooms.SelectedRows[0].Cells[0].Value;

            frmRoomAddNew frm = new frmRoomAddNew(int.Parse(id.ToString()));
            frm.Show();
            this.Close();
        }
    }
}
