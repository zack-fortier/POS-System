using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SP19.P05.Mobile.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckinMain : TabbedPage
    {
        public CheckinMain ()
        {
            this.Children.Add(new Menu() { Icon = "menu.png", Title = "MENU" });
            this.Children.Add(new CheckedIn() { Icon = "qr.png", Title = "SERVICES" });
            this.Children.Add(new Cart() { Icon = "cart.png", Title = "CART" });
            this.Children.Add(new Settings() { Icon = "settings.png", Title = "SETTINGS" });
        }
    }
}