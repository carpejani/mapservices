using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Walliny.Helpers;
using Walliny.Services;
using Xamarin.Forms;

namespace Walliny.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        ApiServices _apiServices = new ApiServices();


        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Cellphone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        private string _Message = "Texto inicial";
        //public string Message { get; set; } = "This is a test!";

        public string Message
        {
            get { return _Message; }
            set
            {
                _Message = value;
                OnPropertyChanged();
            }
        }


        public ICommand RegisterCommand

        {
            get
            {
                return new Command(async () =>
                {

                    var isSuccess = await _apiServices.RegisterAsync(Firstname, Lastname, Cellphone, Username, Password, ConfirmPassword);


                    Settings.Username = Username;
                    Settings.Password = Password;

                    if (isSuccess)
                    {
                        Message = "Registered successfully";
                    }
                    else
                        Message = "Retry later";
                });
            }
        }
    }
}
