using SP19.P05.Mobile.Forms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SP19.P05.Mobile.Forms.Views
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            NavigationPage.SetHasBackButton(this, false);

            BackgroundColor = Constants.BackgroundColor;

            this.Title = "Login";
            StackLayout stacklayout = new StackLayout();

            Image Logo = new Image { Source = "logn.png", HeightRequest = Constants.LoginIconHeight, Margin = new Thickness(0, 60, 0, 0) };

            Padding = new Thickness(60, 0, 60, 0);

            var username = new Entry { Placeholder = "Username" };
            var password = new Entry { IsPassword = true, Placeholder = "Password" };
            var login = new Button { Text = "Login" };
            var Lbl_signup = new Label { Text = "Not a Member? Sign up now!" };
            var signup = new Button { Text = "Sign up" };

            username.Completed += (s, e) => password.Focus();

            password.Completed += (s, e) => login.Focus();


            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { Logo, username, password, login, Lbl_signup, signup }
            };


            login.Clicked += (object s, EventArgs e) =>
             {
                 User user = new User(username.Text, password.Text);
                 if (username.Text == null || password.Text == null)
                 {
                     DisplayAlert("Login", "Login Failed", "OK");
                 }
                 else
                 {
                     App.Current.MainPage = new NavigationPage(new Main());
                     Navigation.PushModalAsync(new Main());
                 }
             };

            signup.Clicked += (object Sender, EventArgs e) =>
            {
                Navigation.PushModalAsync(new Signup());
                Navigation.PopAsync();
            };
        }
    }
}