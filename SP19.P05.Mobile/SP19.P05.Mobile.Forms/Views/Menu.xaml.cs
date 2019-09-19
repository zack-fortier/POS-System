using SP19.P05.Mobile.Forms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace SP19.P05.Mobile.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            StackLayout stacklayout = new StackLayout();
            BackgroundColor = Constants.BackgroundColor;
            Padding = new Thickness(60, 20, 60, 20);
            var Lbl_meals = new Label { Text = "Meals" };
            var meals = new Xamarin.Forms.ImageButton { Source = "meal.jpg", BackgroundColor = Color.Transparent };

            var Lbl_drinks = new Label { Text = "Drinks" };
            var drinks = new Xamarin.Forms.ImageButton { Source = "drinkss.jpg", BackgroundColor = Color.Transparent };

            var Lbl_sides = new Label { Text = "Sides" };
            var sides = new Xamarin.Forms.ImageButton { Source = "side.jpg", BackgroundColor = Color.Transparent };

            var Lbl_specials = new Label { Text = "Specials" };
            var specials = new Xamarin.Forms.ImageButton { Source = "specials.jpg", BackgroundColor = Color.Transparent };

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { Lbl_meals, meals, Lbl_sides, sides, Lbl_drinks, drinks, Lbl_specials, specials }
            };

            ScrollView scroll = new ScrollView
            {
                Content = Content
            };
            Content = scroll;

            meals.Clicked += (object s, EventArgs e) =>
            {
                Navigation.PushAsync(new Meals());

            };

            drinks.Clicked += (object s, EventArgs e) =>
            {
                Navigation.PushAsync(new Drinks());

            };
            sides.Clicked += (object s, EventArgs e) =>
            {
                Navigation.PushAsync(new Sides());

            };
        }
    }
}