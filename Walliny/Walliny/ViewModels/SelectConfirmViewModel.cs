using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Walliny.Helpers;
using Walliny.Models;
using Walliny.Services;
using Xamarin.Forms;

namespace Walliny.ViewModels
{
    public class SelectConfirmViewModel
    {
        ApiServices _apiServices = new ApiServices();
       // public RequestService RequestService { get; set; }

        public string UserId { get; set; }
        public string Id_Services { get; set; }
        public string PriceLabel { get; set; }
        public string SelectedBookTitle { get; set; }

        

        public ICommand ServiceConfirmPutCommand
        {
            get
            {
               

                return new Command(async () =>
                {
                    if (SelectedBookTitle != null) {

                    var requestService = new RequestService
                    {
                          Id_tb_tipo_services = Id_Services,
                          Id_tb_users = UserId,
                          Price = PriceLabel 
                        //  Lat_start_user = 
                        //   Log_end_user =
                        //   Estimation = 


                    };

                    await _apiServices.PutServiceConfirmAsync(requestService, Settings.AccessToken);

                        await App.Current.MainPage.DisplayAlert("Request", "request accepted", "Ok");
                        await Application.Current.MainPage.Navigation.PushModalAsync(new MainPage());
                       
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Payment", "Select payment method", "Ok");
                       
                    }
                   
                });
            }
        }
    }
}
