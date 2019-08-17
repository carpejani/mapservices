using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walliny.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Walliny.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogoutPage : ContentPage
    {
        public LogoutPage()
        {
            InitializeComponent();
            Logout_Clicked();
        }

        private async void Logout_Clicked()
        {
            Settings.AccessToken = "";
            Settings.Username = "";
            Settings.Password = "";

            await Navigation.PushAsync(new LoginPage());
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return false;
        }
    }
}