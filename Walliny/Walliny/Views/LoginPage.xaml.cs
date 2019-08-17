using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Walliny.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

        }

        private void LoginPage_OnClicked(object sender, EventArgs e)
        {
            //var Username = Username.Text;

            if (Username.Text != "")
            {
                if(Password.Text != null)
                {
                    Navigation.PushModalAsync(new Walliny.MainPage());
                }               
            }
            else
            {
                // this.IsValid = true;
                if (Username.Text == "")
                {
                    Username.TextColor = Color.White;
                    Username.BackgroundColor = Color.Red;
                }
                if (Username.Text == "")
                {
                    Password.TextColor = Color.White;
                    Password.BackgroundColor = Color.Red;
                }

                    context.Text = "Error";
                
            }


           // Navigation.PushModalAsync(new Walliny.MainPage());
           
        }

      //  public static string GetVersion()
      //  {
      //      string versionNumber = ParseVersionNumber(Assembly.GetExecutingAssembly()).ToString();
      //      return versionNumber;
      //  }

      //  private static Version ParseVersionNumber(Assembly assembly)
      //  {
      //      AssemblyName assemblyName = new AssemblyName(assembly.FullName);
      //      return assemblyName.Version;
      //  }    
    }
}