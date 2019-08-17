using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Walliny.Helpers;
using Walliny.Views;
using Xamarin.Forms;

namespace Walliny
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new TestPage1());
            //MainPage = new Walliny.MainPage();
            SetMainPage();
        }

        private void SetMainPage()
        {
            if (!string.IsNullOrEmpty(Settings.AccessToken))
            {
                // if (DateTime.UtcNow.AddHours(1) > Settings.AccessTokenexpiration)
                //{
                // var vm = new LoginViewModel();
                // vm.LoginCommand.Execute(null);
                //}

                //MainPage = new NavigationPage(new IdeasPage());
                MainPage = new Walliny.MainPage();
            }
            else if (!string.IsNullOrEmpty(Settings.Username)
                  && !string.IsNullOrEmpty(Settings.Password))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new RegisterPage());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
