using Plugin.Geolocator;
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
    public partial class TestPage2 : ContentPage
    {
        public TestPage2()
        {
            Title = "Walliny";
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {


            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

            var LongitudeLabel = position.Longitude;
            var LatitudeLabel = position.Latitude;

            var map = new Map();
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(LatitudeLabel, LongitudeLabel), Distance.FromMeters(500)), true);

            //Adding the map Control in c#
            // var map = new Map(
            //                 MapSpan.FromCenterAndRadius(
            //                 new Position(LatitudeLabel, LongitudeLabel), Distance.FromMiles(0.2)))
            // {
            //     IsShowingUser = true,
            //     HeightRequest = 200,
            ///     WidthRequest = 460,
            //     VerticalOptions = LayoutOptions.FillAndExpand
            //  };

            //Using the Slider for zoom in/out feature
            var slider = new Slider(1, 18, 1);
            slider.ValueChanged += (sender, e) =>
            {
                var zoomLevel = e.NewValue; // between 1 and 18
                //var zoomLevel = 16;
                var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
                map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
            };


            Button button = new Button
            {
                // Text = "Click Me!",
                // BorderWidth = 1,
                // HorizontalOptions = LayoutOptions.Center,
                //VerticalOptions = LayoutOptions.CenterAndExpand

                Text = "Search keyword",
                FontSize = 30,
                TextColor = Color.White,
                BackgroundColor = Color.DodgerBlue,
            };
            button.Clicked += NavigateToIdeasPage_OnClicked;



            var position1 = new Position(-25.4581, -49.2157);
            var position2 = new Position(-25.4568, -49.2169);


            var pin1 = new Pin
            {
                Type = PinType.Place,
                Position = position1,
                Label = "IntilaQ",
                Address = "www.intilaq.tn",

            };

            var imagem = new Image
            {
                Source = "car.png"
            };


            var pin2 = new Pin
            {
                //Type = PinType.Place,
                Position = position2,
                Label = "Telnet R&D",
                Address = "www.groupe-telnet.com",
                //ResourceNameImg = "Icon-76.png"
                //Source = "car.png"
                // BindingContext = imagem,

            };

            //Adding the control into view
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            stack.Children.Add(button);
            //stack.Children.Add(imagem);

            map.Pins.Add(pin1);
            map.Pins.Add(pin2);
            // stack.Children.Add(slider);
            Content = stack;
            //MyMap = map;
        }

        private async void NavigateToIdeasPage_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ServicePage());
            // Navigation.RemovePage(this);
        }
    }
}