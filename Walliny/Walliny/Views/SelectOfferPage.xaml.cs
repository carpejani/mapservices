using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walliny.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Walliny.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectOfferPage : ContentPage
    {
        public SelectOfferPage(string Id_Services, string UserId, string Title, string Description, string InputEntry,
                string Longitude, string Latitude, string reverseGeocodedOutputLabel)
        {
            InitializeComponent();

            UserIdd.Text = UserId;
            Id_Servicess.Text = Id_Services;
            Titlee.Text = Title;
            Descriptionn.Text = Description;
            reverseGeocodedOutputLabell.Text = reverseGeocodedOutputLabel;

            //actIndBackground.IsVisible = true;
            //frameLayer.IsVisible = true;
            //indicatorLoader.IsVisible = true;
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();

            //MainPage = new NavigationPage(new LoginPage());

            // Navigation.PopAsync(new MainPage());

            Navigation.PushModalAsync(new MainPage());

            return true;
        }

        private void ServicesConfirm_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var ServiceConfirm = e.Item as OfferServices;

            Navigation.PushModalAsync(new SelectConfirmPage(ServiceConfirm,Id_Servicess.Text, UserIdd.Text, Titlee.Text, Descriptionn.Text, InputEntry.Text,
                Longitude.Text, Latitude.Text, reverseGeocodedOutputLabell.Text));
        }
    }
}