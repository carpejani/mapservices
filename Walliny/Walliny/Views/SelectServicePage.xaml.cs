using Plugin.Geolocator;
using System;
using System.Linq;
using System.Threading.Tasks;
using Walliny.Models;
using Walliny.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Walliny.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectServicePage : ContentPage
    {
        Geocoder geoCoder;

        public SelectServicePage(Service service)
        {
            InitializeComponent();

            // var SelectServiceViewModel = new SelectServiceViewModel();
            // SelectServiceViewModel.Service = service;           

            BindingContext = new SelectServiceViewModel();

            Id.Text = Convert.ToString(service.Id);
            UserId.Text = Convert.ToString(service.UserId);
            Title.Text = Convert.ToString(service.Title);
            Description.Text = Convert.ToString(service.Description);

            geoCoder = new Geocoder();

            OnReverseGeocodeButtonClicked();

        }

        async void OnReverseGeocodeButtonClicked()
        {


            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

            var LongitudeLabel = position.Longitude;
            var LatitudeLabel = position.Latitude;

            Longitude.Text = Convert.ToString(position.Longitude);
            Latitude.Text = Convert.ToString(position.Latitude);

            InputEntry.Text = Convert.ToString(position.Latitude) + "," + Convert.ToString(position.Longitude);


            //var inputEntry = Convert.ToString(position.Latitude) + "," + Convert.ToString(position.Longitude);

            if (!string.IsNullOrWhiteSpace(InputEntry.Text))
            //if (!string.IsNullOrWhiteSpace(inputEntry))
            {
                var coordinates = InputEntry.Text.Split(',');
                // var coordinates = inputEntry.Split(',');
                double? latitude = Convert.ToDouble(coordinates.FirstOrDefault());
                double? longitude = Convert.ToDouble(coordinates.Skip(1).FirstOrDefault());

                if (latitude != null && longitude != null)
                {
                    var positionn = new Position(LatitudeLabel, LongitudeLabel);

                    // var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(positionn);
                    // foreach (var address in possibleAddresses)
                    //     reverseGeocodedOutputLabel.Text += address + "\n";
                    reverseGeocodedOutputLabel.Text = "1000 Rua João Jose Curitiba Paraná 82949-000 Brasil";
                }
            }
        }

        private async void RequestService(object sender, EventArgs e)
        {

            frameLayer.IsVisible = true;
            indicatorLoader.IsVisible = true;
            RequestServiceButton.IsVisible = false;
            //CanselRequestButton.IsVisible = true;

            await Task.Run(async () =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    //if your code requires UI then wrap it in BeginInvokeOnMainThread
                    //otherwise just run your code
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        // Id_Services.Text = $"Wait {i}";
                    });
                    await Task.Delay(1000);
                }
            });

            // Id_Services.Text = "0";


            // frameLayer.IsVisible = true;
            // indicatorLoader.IsVisible = true;
            // RequestServiceButton.IsVisible = false;
            // CanselRequestButton.IsVisible = true;


            // var service = e.Item as Service;
            //await Navigation.PushAsync(new EditIdeaPage(idea));
            await Navigation.PushModalAsync(
                new SelectOfferPage(Id_Services.Text, UserId.Text, Title.Text, Description.Text, InputEntry.Text, 
                Longitude.Text, Latitude.Text, reverseGeocodedOutputLabel.Text));
        }
    }
}

