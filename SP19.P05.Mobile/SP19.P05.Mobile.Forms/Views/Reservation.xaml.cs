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
    public partial class Reservation : ContentPage
    {
        public Reservation()
        {
            StackLayout stacklayout = new StackLayout();
            BackgroundColor = Constants.BackgroundColor;

            Padding = new Thickness(60, 60, 60, 0);

            var reserve = new Label { Text = "Reserve a Table", FontSize = 25 };

            var fname = new Entry { Placeholder = "First Name" };

            var lname = new Entry { Placeholder = "Last Name" };

            var email = new Entry { Placeholder = "Email" };

            email.Keyboard = Keyboard.Email;

            var phone = new Entry { Placeholder = "Phone No." };

            var Reserve = new Button { Text = "Reserve" };

            var numguests = new Entry { Placeholder = "Number Of Guests" };

            TimePicker timePicker = new TimePicker
            {
                Time = new TimeSpan(4, 15, 26) // Time set to "04:15:26"
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { reserve, fname, lname, email, phone, numguests, timePicker, Reserve }
            };

            Reserve.Clicked += (object sender, EventArgs e) =>
                {
                    try
                    {
                        if (fname.Text == null || email.Text == null || lname.Text == null || phone.Text == null )
                        {
                            DisplayAlert("Error", "Please fill in all the fields", "OK");
                        }

                        else
                        {
                            DisplayAlert("Success", "Your Reservation has been made for specified time ",  "OK");
                            Navigation.PushModalAsync(new Main());
                            App.Current.MainPage = new NavigationPage(new Main());
                        }
                    }

                    catch (Exception ex)
                    {
                        string er = ex.ToString();
                        DisplayAlert("Sorry...", "Something went wrong. Try again later", "OK");
                        Navigation.PushAsync(new Login());
                    }

                };
        }
    }
}