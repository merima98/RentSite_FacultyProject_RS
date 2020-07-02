using RentSite.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RentSite.MobileApp.ViewModels
{


    public class LoginViewModel :BaseViewModel
    {
        private readonly APIService _service = new APIService("TypeOfResidentialBuilding");
        private readonly APIService _userService = new APIService("User");

        public LoginViewModel()
        {
            LoginCommand = new Command(async()=>await Login());
        }

        string _username = string.Empty;

        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }


        int _ID = 0;  
        public int ID
        {
            get { return _ID; }
            set { SetProperty(ref _ID, value); }
        }

        public ICommand LoginCommand { get; set; }


        async Task Login()   
        {
            IsBusy = true;
            APIService.Username = Username;
            APIService.Password = Password;

            

            try
            {
                List<Model.User> list = await _userService.Get<List<Model.User>>();
                foreach (var x in list)
                {
                    if (x.Username == Username)
                    {
                        APIService.UserId = x.Id;
                    }
                }

                await _service.Get<dynamic>(null);
                Application.Current.MainPage = new MainPage();

            }
            catch (Exception ex)
            {

            }
        }

    }
}
