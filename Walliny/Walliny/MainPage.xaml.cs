using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Walliny.Helpers;
using Walliny.MenuItems;
using Walliny.Views;
using Xamarin.Forms;

namespace Walliny
{
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }

        public MainPage()
        {
            InitializeComponent();

            menuList = new List<MasterPageItem>();

            LabelUsername.Text = Settings.Username;

            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var page1 = new MasterPageItem() { Title = "Home", Icon = "itemIcon1.png", TargetType = typeof(MainCenterPage) };
            var page2 = new MasterPageItem() { Title = "Perfil", Icon = "itemIcon2.png", TargetType = typeof(TestPage2) };
            var page3 = new MasterPageItem() { Title = "Meus Pedidos", Icon = "itemIcon3.png", TargetType = typeof(TestPage2) };
            var page4 = new MasterPageItem() { Title = "Item 4", Icon = "itemIcon4.png", TargetType = typeof(TestPage1) };
            var page5 = new MasterPageItem() { Title = "Endereco", Icon = "itemIcon5.png", TargetType = typeof(TestPage3) };
            var page6 = new MasterPageItem() { Title = "Logout", Icon = "itemIcon6.png", TargetType = typeof(LogoutPage) };
            // var page7 = new MasterPageItem() { Title = "Item 7", Icon = "itemIcon7.png", TargetType = typeof(TestPage1) };
            // var page8 = new MasterPageItem() { Title = "Item 8", Icon = "itemIcon8.png", TargetType = typeof(TestPage2) };
            // var page9 = new MasterPageItem() { Title = "Item 9", Icon = "itemIcon9.png", TargetType = typeof(TestPage2) };

            // Adding menu items to menuList
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
            menuList.Add(page5);
            menuList.Add(page6);
            //menuList.Add(page7);
            //menuList.Add(page8);
            //menuList.Add(page9);

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(MainCenterPage)));


            //  ToolbarItems.Add(new ToolbarItem
            //  {
            //      Name = "OK",
            //      Icon = "ok.png",
            //      Order = ToolbarItemOrder.Primary,
            //      Command = new Command(() => Navigation.PushAsync(new TestPage1()))
            //  });



        }
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
       

        protected override bool OnBackButtonPressed()
        {
           base.OnBackButtonPressed();
            return false;
        }
    }
}
