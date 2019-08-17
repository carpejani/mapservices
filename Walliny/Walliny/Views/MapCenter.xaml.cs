using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace Walliny.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapCenter : ContentPage
    {
        private Position _position;

        public MapCenter()
        {
            InitializeComponent();
     
        }
        protected async override void OnAppearing()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var _position = await locator.GetPositionAsync(TimeSpan.FromSeconds(1000));

            var LongitudeLabel = _position.Longitude;
            var LatitudeLabel = _position.Latitude;

           

            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(LatitudeLabel, LongitudeLabel), Distance.FromMeters(400)));


            var position1 = new Position(-25.4569, -49.2170);
            var position2 = new Position(-25.4578, -49.2146);


            


            var pin1 = new Pin
            {
                //Type = PinType.Place,
                Position = position1,
                Label = "Ovo",
                Address = "www.intilaq.tn",
                Icon = BitmapDescriptorFactory.FromBundle("car.png")


            };


            var pin2 = new Pin
            {
                //Type = PinType.Place,
                Position = position2,
                Label = "Churros",
                Address = "www.groupe-telnet.com",
                Icon = BitmapDescriptorFactory.FromBundle("car.png")
            };

            //Adding the control into view
           // var stack = new StackLayout { Spacing = 0 };

            MyMapStack.Children.Add(MyMap);
           // stack.Children.Add(button);
            //stack.Children.Add(imagem);

            MyMap.Pins.Add(pin1);
            MyMap.Pins.Add(pin2);
            // stack.Children.Add(slider);
           // Content = stack;
            //MyMap = map;
        }

    

        public async void GetPosition()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var myPosition = await locator.GetPositionAsync(TimeSpan.FromSeconds(10000));
            _position = new Position(myPosition.Latitude, myPosition.Longitude);
        }

        private async void NavigateToIdeasPage_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ServicePage());
            // Navigation.RemovePage(this);
        }
    }
}