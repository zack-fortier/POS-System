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
    public partial class Drinks : ContentPage
    {
        public Drinks()
        {
            StackLayout stacklayout = new StackLayout();
            BackgroundColor = Constants.BackgroundColor;
            Padding = new Thickness(60, 20, 60, 20);
            var lbl_coke = new Label { Text = "Coke", TextColor = Color.Black };
            var p1 = new Label { Text = "Price: 1.5$" };
            var coke = new Xamarin.Forms.ImageButton { Source = "coke.jpg", BackgroundColor = Color.Transparent };
            var add1 = new Button { Text = "Add to cart" };

            var lbl_sprite = new Label { Text = "Sprite", TextColor = Color.Black };
            var p2 = new Label { Text = "Price: 1.5$" };
            var sprite = new Xamarin.Forms.ImageButton { Source = "sprite.jpg", BackgroundColor = Color.Transparent };
            var add2 = new Button { Text = "Add to cart" };

            var lbl_fanta = new Label { Text = "Fanta", TextColor = Color.Black };
            var p3 = new Label { Text = "Price: 1.5$" };
            var fanta = new Xamarin.Forms.ImageButton { Source = "fanta.png", BackgroundColor = Color.Transparent };
            var add3 = new Button { Text = "Add to cart" };

            var lbl_lemon = new Label { Text = "Iced Tea", TextColor = Color.Black };
            var p4 = new Label { Text = "Price: 1.5$" };
            var lemon = new Xamarin.Forms.ImageButton { Source = "lemon.png", BackgroundColor = Color.Transparent };
            var add4 = new Button { Text = "Add to cart" };

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {  lbl_coke, p1, coke, add1, lbl_sprite, p2, sprite, add2, lbl_fanta, p3, fanta, add3, lbl_lemon, p4, lemon, add4 }
            };

            ScrollView scroll = new ScrollView
            {
                Content = Content
            };
            Content = scroll;

            add1.Clicked += (object s, EventArgs e) =>
            {
            };

            add2.Clicked += (object s, EventArgs e) =>
            {
            };

            add3.Clicked += (object s, EventArgs e) =>
            {
            };

            add4.Clicked += (object s, EventArgs e) =>
            {
            };
        }
    }
}