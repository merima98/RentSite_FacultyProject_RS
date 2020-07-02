using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using Flurl;
using RentSite.Model.Requests;
using RentSite.Model;

namespace RentSite.WinUI.Users
{
    public partial class frmUsersView : Form
    {
        private readonly APIService _userService = new APIService("User");
        public frmUsersView()
        {
            InitializeComponent();
        }
        protected override void OnClosing(CancelEventArgs e)  //ovo sam zadnje dodala
        {
            this.WindowState = FormWindowState.Normal;
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {

            UsersSearchRequest searchRequest = new UsersSearchRequest()
            {
                FirstName = txtFilter.Text,
                LastName = txtFilter.Text
            };

            var list = await _userService.Get<List<Model.User>>(searchRequest);

            dgvUsers.DataSource = list;
        }

        private void dgvUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvUsers.SelectedRows[0].Cells[0].Value;

            frmUsersAddNew frm = new frmUsersAddNew(int.Parse(id.ToString()));
            frm.Show();

            this.Close(); //zatvaranje ove 
        }

    }
}
