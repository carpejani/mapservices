using Ideas.Models;
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
    public partial class ServicePage : ContentPage
    {
        public ServicePage()
        {
            InitializeComponent();
        }

        private async void NavigateToSearchIdea_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new SearchPage());

            //var homepage = new NavigationPage(new SearchPage());

            await Navigation.PushModalAsync(new SearchPage());

            //await Navigation.PushAsync(new SearchPage());

            // Navigation.RemovePage(this);

        }
        private async void ServicesListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var service = e.Item as Service;
            //await Navigation.PushAsync(new EditIdeaPage(idea));
            await Navigation.PushModalAsync(new SelectServicePage(service));
        }

        
    }
}