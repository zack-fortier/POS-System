using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SP19.P05.Mobile.Forms.Model;

namespace SP19.P05.Mobile.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Meals : ContentPage
    {
        public Meals()
        {
            StackLayout stacklayout = new StackLayout();
            BackgroundColor = Constants.BackgroundColor;
            Padding = new Thickness(60, 20, 60, 20);
            var description = new Label { Text = "Meal items come with fries and drink", TextColor = Color.Black };

            var Lbl_chicken = new Label { Text = "Chicken Sandwich Meal", TextColor = Color.Black };
            var p1 = new Label { Text = "Price: 12$" };
            var chicken = new Xamarin.Forms.ImageButton { Source = "chicken.jpg", BackgroundColor = Color.Transparent };
            var add1 = new Button { Text = "Add to cart" };

            var Lbl_ham = new Label { Text = "Ham Burger Meal", TextColor = Color.Black };
            var  p2 = new Label { Text = "Price: 10$" };
            var ham = new Xamarin.Forms.ImageButton { Source = "ham.jpg", BackgroundColor = Color.Transparent };
            var add2 = new Button { Text = "Add to cart" };

            var Lbl_bacon = new Label { Text = "Bacon Cheeseburger Meal", TextColor = Color.Black };
            var p3 = new Label { Text = "Price: 15$" };
            var bacon = new Xamarin.Forms.ImageButton { Source = "bacon.jpg", BackgroundColor = Color.Transparent };
            var add3 = new Button { Text = "Add to cart" };

            var Lbl_wings = new Label { Text = "12 Pc Wings Meal", TextColor = Color.Black };
            var p4 = new Label { Text = "Price: 12$" };
            var wings = new Xamarin.Forms.ImageButton { Source = "wings.jpg", BackgroundColor = Color.Transparent };
            var add4 = new Button { Text = "Add to cart" };

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { description, Lbl_chicken, p1, chicken,add1, Lbl_bacon, p2, bacon, add2,Lbl_ham, p3, ham, add3,Lbl_wings, p4, wings,add4 }
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