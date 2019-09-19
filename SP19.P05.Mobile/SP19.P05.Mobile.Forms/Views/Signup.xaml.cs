using SP19.P05.Mobile.Forms.Controller;
using SP19.P05.Mobile.Forms.Model;
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
    public partial class Signup : ContentPage
    {
        private CustomersController _customersController = new CustomersController();

        public Signup()
        {
            NavigationPage.SetHasBackButton(this, false);

            BackgroundColor = Constants.BackgroundColor;

            this.Title = "Sign up";

            var scroll = new ScrollView();
            Content = scroll;

            StackLayout stacklayout = new StackLayout();

            var back = new Button { Text = "Back" };
            
            Image Logo = new Image { Source = "login.png", HeightRequest = Constants.SignupIconHeight, Margin = new Thickness(0, 40, 0, 0) };

            Padding = new Thickness(60, 0, 60, 0);

            var name = new Entry { Placeholder = "Name" };

            var username = new Entry { Placeholder = "Username" };

            var email = new Entry { Placeholder = "Email" };

            email.Keyboard = Keyboard.Email;

            var password = new Entry { IsPassword = true, Placeholder = "Password" };

            var address = new Entry { Placeholder = "Address" };

            var signup = new Button { Text = "Sign up" };



            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { Logo, name, address, email, username, password, signup }
            };

            back.Clicked += (object Sender, EventArgs e) =>
            {
                Navigation.PushModalAsync(new Login());
            };

            signup.Clicked += (object Sender, EventArgs e) =>
            {
                try
                {
                    if (name.Text == null || email.Text == null || username.Text == null || password.Text == null || address.Text == null)
                    {
                        DisplayAlert("Error", "Please fill in all the fields", "OK");
                    }

                    else
                    {
                        Customer newCustomerToRegister = new Customer()
                        {
                            Username = username.Text,
                            Password = password.Text,
                            Email = email.Text,
                            MailingAddress = address.Text,
                        };
                        _customersController.RegisterUser(newCustomerToRegister);
                        DisplayAlert("Success", "Saved Succesfully. Login Now ! ", "OK");
                        Navigation.PushModalAsync(new Login());
                        Navigation.PopAsync();

                    }
                }

                catch (Exception ex)
                {
                    string er = ex.ToString();
                    DisplayAlert("Sorry...", "Something went wrong. Try again later", "OK");
                    Navigation.PushModalAsync(new Login());
                }

            };
        }
    }
}




