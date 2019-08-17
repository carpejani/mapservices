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
    public partial class SelectConfirmPage : ContentPage
    {
        public SelectConfirmPage(OfferServices ServiceConfirm, string Id_Servicess, string UserIdd, string Titlee, string Descriptionn, string InputEntry,
                string Longitude, string Latitude, string reverseGeocodedOutputLabell)
        {
            InitializeComponent();

            PriceLabel.Text = ServiceConfirm.Price;

            UserId.Text = UserIdd;
            Id_Services.Text = Id_Servicess;
            Title.Text = Titlee;
            Description.Text = Descriptionn;
            reverseGeocodedOutputLabel.Text = reverseGeocodedOutputLabell;
        }
    }
}

