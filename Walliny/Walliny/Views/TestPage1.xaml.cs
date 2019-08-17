using Plugin.Geolocator;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Walliny.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage1 : ContentPage
    {
        public TestPage1()
        {
            InitializeComponent();
           
        }
        private async void GetGpsOnclicked(object sender, EventArgs e)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

            LongitudeLabel.Text = position.Longitude.ToString();
            LatitudeLabel.Text = position.Latitude.ToString();
    
        }


        async void OnClickButtonOne(object sender, EventArgs e)
        {
            var blnResponse = await App.Current.MainPage.DisplayAlert("Título", "Coloque uma mensagem aqui..", "Ok", "Cancelar");

            string strMessage = (blnResponse ? "Apertou Ok!" : "Apertou Cancelar");
            await App.Current.MainPage.DisplayAlert("Título", strMessage, "Ok");
        }

        async void OnClickButtonTwo(object sender, EventArgs e)
        {
            await App.Current.MainPage.DisplayAlert("Título", "Alert de confirmação", "Ok");
        }

        async void OnClickButtonThree(object sender, EventArgs e)
        {
            await App.Current.MainPage.DisplayAlert("Título", "Pesquisa", "Ok");
        }

       
           


        
    }

}