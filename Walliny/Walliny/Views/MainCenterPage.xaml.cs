using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Walliny.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainCenterPage : TabbedPage
    {
        public MainCenterPage()
        {
            Title = "Walliny";
            InitializeComponent();
        }
    }
}