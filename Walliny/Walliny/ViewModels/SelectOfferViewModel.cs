using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Walliny.Helpers;
using Walliny.Models;
using Walliny.Services;
using Xamarin.Forms;

namespace Walliny.ViewModels
{
    public class SelectOfferViewModel : INotifyPropertyChanged
    {
        ApiServices _apiServices = new ApiServices();
        private List<OfferServices> _offerServices;


        DateTime dateTime;


        public string Keyword { get; set; }
        public string Id_Services { get; set; }

        private bool _loading;



        public SelectOfferViewModel()
        {
            Loading = true;
            this.DateTime = DateTime.Now;

            Device.StartTimer(TimeSpan.FromSeconds(20), () =>
            {
                this.DateTime = DateTime.Now;

                this.OfferServicesCommand.Execute(true);

                return true;
            });
        }

        public DateTime DateTime
        {
            set
            {
                if (dateTime != value)
                {
                    dateTime = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("DateTime"));
                    }
                }
            }
            get
            {
                return dateTime;
            }
        }

        public List<OfferServices> OfferServices
        {
            get { return _offerServices; }
            set
            {
                _offerServices = value;
                OnPropertyChanged();
            }
        }

        public bool Loading
        {
            get
            {
                return _loading;
            }
            private set
            {
                _loading = value;
                OnPropertyChanged();
            }
        }

        public ICommand OfferServicesCommand
        {
            get
            {
                return new Command(async () =>
                {
                   
                    OfferServices = await _apiServices.OfferServicesAsync(Id_Services, Settings.AccessToken);
                    //Loading = true;
                   // await Task.Delay(TimeSpan.FromSeconds(5));
                    Loading = false;

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
