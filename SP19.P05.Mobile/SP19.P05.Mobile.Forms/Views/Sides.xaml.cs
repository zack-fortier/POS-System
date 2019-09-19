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
	public partial class Sides : ContentPage
	{
		public Sides ()
		{
            StackLayout stacklayout = new StackLayout();
            BackgroundColor = Constants.BackgroundColor;
            Padding = new Thickness(60, 20, 60, 20);

            var Lbl_fries = new Label { Text = "Happytite SFries", TextColor = Color.Black };
            var p1 = new Label { Text = "Price: 4$" };
            var fries = new Xamarin.Forms.ImageButton { Source = "side.jpg", BackgroundColor = Color.Transparent };
            var add1 = new Button { Text = "Add to cart" };

            var Lbl_salad = new Label { Text = "Chicken Ceasar Salad", TextColor = Color.Black };
            var p2 = new Label { Text = "Price: 5$" };
            var salad = new Xamarin.Forms.ImageButton { Source = "Salad.jpg", BackgroundColor = Color.Transparent };
            var add2 = new Button { Text = "Add to cart" };

           
            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { Lbl_fries, p1,fries,add1, Lbl_salad,p2,salad,add2 }
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
        }
	}
}