using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Walliny.Helpers;
using Walliny.Models;
using Walliny.Services;
using Walliny.Views;
using Xamarin.Forms;

namespace Walliny.ViewModels
{
    public class SelectServiceViewModel:INotifyPropertyChanged
    {
        ApiServices _apiServices = new ApiServices();
        public Service Service { get; set; }

        public RequestService _requestService;

        public string UserId { get; set; }
        public int Id { get; set; }       
        public string Lat_start_user { get; set; }
        public string Log_end_user { get; set; }
        public string InputEntry { get; set; }
        public string _id_Services { get; set; }

        public RequestService RequestService
        {
            get { return _requestService; }
            set
            {
                _requestService = value;
                OnPropertyChanged();
            }
        }

        public string Id_Services
        {
            get { return _id_Services; }
            set
            {
                _id_Services = value;
                OnPropertyChanged();
            }
        }

        public ICommand RequestServiceCommand
        {
            get
            {
                return new Command(async () =>
                {
                   
                    var request = new Request
                    {
                      //  Id_tb_users = Service.UserId,
                      //  Id_tb_tipo_services = Service.Id,
                        Lat_start_user = Lat_start_user,
                        Log_end_user = Log_end_user,
                        InputEntry = InputEntry
                   };
                    Id_Services = await _apiServices.PostRequestServiceAsync(request, Settings.AccessToken);
                    //var teste = Id_Services;
                });
            }

        }


       


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

