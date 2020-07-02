using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentSite.WinUI.Login
{
    public partial class frmLogin : Form
    {
        APIService _service = new APIService("TypeOfResidentialBuilding");
        APIService _userService = new APIService("User");
        public frmLogin()
        {
            InitializeComponent();
        }
        
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                APIService.Username = txtUsername.Text;
                APIService.Password = txtPassword.Text;
                List<Model.User> list =await _userService.Get<List<Model.User>>();

                foreach (var findUsername in list)
                {
                    if (findUsername.Username == APIService.Username)
                    {
                        APIService.UserId = findUsername.Id;
                    }
                }

                await _service.Get<dynamic>(null);  
                MDIParent1 frm = new MDIParent1();
                frm.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Autentikacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
