using SP19.P05.Mobile.Forms.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SP19.P05.Mobile.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            NavigationPage.SetHasBackButton(this, false);

            StackLayout stacklayout = new StackLayout();
            BackgroundColor = Constants.BackgroundColor;
            Padding = new Thickness(60, 60, 60, 0);

            var logout = new Button { Text = "Logout" };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { logout }
            };

            logout.Clicked += (object sender, EventArgs e) =>
           {
               NavigationPage NP = new NavigationPage(new Login());
               Navigation.PushModalAsync(new Login());

               App.Current.MainPage = NP;

           };
        }
    }
}

