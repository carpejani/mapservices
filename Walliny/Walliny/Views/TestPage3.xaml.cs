using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Walliny.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage3 : ContentPage
    {
        Geocoder geoCoder;

        public TestPage3()
        {
            InitializeComponent();
            geoCoder = new Geocoder();
        }

        async void OnReverseGeocodeButtonClicked(object sender, EventArgs e)
        {

            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

            var LongitudeLabel = position.Longitude;
            var LatitudeLabel = position.Latitude;

            inputEntry.Text = Convert.ToString(position.Latitude) + "," + Convert.ToString(position.Longitude);

            if (!string.IsNullOrWhiteSpace(inputEntry.Text))
            {
                var coordinates = inputEntry.Text.Split(',');
                double? latitude = Convert.ToDouble(coordinates.FirstOrDefault());
                double? longitude = Convert.ToDouble(coordinates.Skip(1).FirstOrDefault());

                if (latitude != null && longitude != null)
                {
                    var positionn = new Position(LatitudeLabel, LongitudeLabel);
                    var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(positionn);
                    foreach (var address in possibleAddresses)
                        reverseGeocodedOutputLabel.Text += address + "\n";
                }
            }
        }
    }
}