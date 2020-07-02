using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RentSite.MobileApp.ViewModels
{
    public class UserInformationsViewModel : BaseViewModel
    {
        private readonly APIService _userService = new APIService("User");
        public UserInformationsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ICommand LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    APIService.Username = "";
                    APIService.Password = "";
                    APIService.UserId = 0;
                });
            }
        }

        string _firstName = string.Empty;

        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        string _lastName = string.Empty;

        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        string _phoneNumber = string.Empty;

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { SetProperty(ref _phoneNumber, value); }
        }

        string _email = string.Empty;

        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        string _userName = string.Empty;

        public string Username
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        string _isActive = string.Empty;

        public string isActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value); }
        }

        string _typeOfUser = string.Empty;

        public string TypeOfUser
        {
            get { return _typeOfUser; }
            set { SetProperty(ref _typeOfUser, value); }
        }

        public Model.User User { get; set; } = new Model.User();

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var list = await _userService.GetById<Model.User>(APIService.UserId);

            User = list;  
            FirstName = User.FirstName;
            LastName = User.LastName;
            PhoneNumber = User.PhoneNumber;
            Email = User.Email;
            Username = User.Username;

            if (User.Status==true)
            {
                isActive = "Active";
            }
            else
            {
                isActive = "Non active user!";
            }

            if (User.TypeOfUserId==1)
            {
                TypeOfUser = "Administrator";
            }
            else
            {
                TypeOfUser = "User";
            }
        }
    }
}
