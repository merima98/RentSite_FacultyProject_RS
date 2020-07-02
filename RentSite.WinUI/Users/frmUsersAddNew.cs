using RentSite.Model;
using RentSite.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentSite.WinUI.Users
{
    public partial class frmUsersAddNew : Form
    {

        private readonly APIService _userService = new APIService("User");
        private readonly APIService _typeOfUserService = new APIService("TypeOfUser");

        
        private int? _userID = null;
        public frmUsersAddNew(int ?userID=null)
        {
            InitializeComponent();
            _userID = userID;
        }
        private async void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {

                var request = new UsersInsertRequest()
                {
                    Email = txtEmail.Text,
                    FirstName = txtName.Text,
                    LastName = txtLastName.Text,
                    PasswordHash = txtPassword.Text,
                    PasswordSalt = txtPassConfirmation.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    Username = txtUsername.Text,
                    TypeOfUserId = Convert.ToInt32(numTypeOfUser.Value),
                    Status = cbActive.Checked
                };
                if (_userID.HasValue)
                {
                    await _userService.Update<User>(_userID, request);
                }
                else
                {
                    await _userService.Insert<User>(request);
                }
                MessageBox.Show("Operation successfully performed!");
            }

        }
        private async void frmUsersAddNew_Load(object sender, EventArgs e)
        {
            var typeOfUser = await _typeOfUserService.Get<IList<TypeOfUser>>(null);


            if (_userID.HasValue)
            {
                var user = await _userService.GetById<Model.User>(_userID);
                txtEmail.Text = user.Email;
                txtLastName.Text = user.LastName;
                txtName.Text = user.FirstName;
                txtPhoneNumber.Text = user.PhoneNumber;
                txtUsername.Text = user.Username;
                if (user.Status==true)
                {
                    cbActive.Checked = true;
                }

                numTypeOfUser.Value = Convert.ToInt32(user.TypeOfUserId);
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtName, null);
                e.Cancel = false;

            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorProvider.SetError(txtLastName, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtLastName, null);
                e.Cancel = false;

            }
        }

        private void txtPhoneNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                errorProvider.SetError(txtPhoneNumber, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPhoneNumber, null);
                e.Cancel = false;

            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            

            else
            {
                errorProvider.SetError(txtEmail, null);
                e.Cancel = false;

            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider.SetError(txtUsername, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtUsername, null);
                e.Cancel = false;

            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text)  ) // potrebno je imati razilicto
            {
                errorProvider.SetError(txtPassConfirmation, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
              if (!string.IsNullOrWhiteSpace(txtPassword.Text) && !string.IsNullOrWhiteSpace(txtUsername.Text) && txtPassword.Text == txtUsername.Text)
            {
                errorProvider1.SetError(txtPassword, "Reqiured field and mus be different from Username!");
                e.Cancel = true;
            }
              if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider.SetError(txtPassword, null);
                e.Cancel = false;

            }
            if(!string.IsNullOrWhiteSpace(txtPassword.Text) && !string.IsNullOrWhiteSpace(txtUsername.Text) && txtPassword.Text != txtUsername.Text)
            {
                errorProvider1.SetError(txtPassword, null);
                e.Cancel = false;

            }
        }

        private void txtPassConfirmation_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassConfirmation.Text))
            {
                errorProvider.SetError(txtPassConfirmation, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
             if (!string.IsNullOrWhiteSpace(txtPassConfirmation.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text) && txtPassword.Text != txtPassConfirmation.Text)
            {
              
                errorProvider2.SetError(txtPassConfirmation, "Reqiured field and must be same as Password!");
                e.Cancel = true;
            }
              if (!string.IsNullOrWhiteSpace(txtPassConfirmation.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text) && txtPassword.Text == txtPassConfirmation.Text)
            {
                errorProvider.SetError(txtPassConfirmation, null);
                e.Cancel = false;

            }
            if (!string.IsNullOrWhiteSpace(txtPassConfirmation.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text) && txtPassword.Text == txtPassConfirmation.Text)
            {
                errorProvider2.SetError(txtPassConfirmation, null);
                e.Cancel = false;

            }
        }


        private void numTypeOfUser_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(numTypeOfUser.ToString()))
            {
                errorProvider.SetError(numTypeOfUser, Properties.Resources.RequiredField);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(numTypeOfUser, null);
                e.Cancel = false;

            }
        }
    }
}
