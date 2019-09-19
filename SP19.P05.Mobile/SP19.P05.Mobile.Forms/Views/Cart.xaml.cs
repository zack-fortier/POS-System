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
	public partial class Cart : ContentPage
	{
		public Cart ()
		{
            StackLayout stacklayout = new StackLayout();
            BackgroundColor = Constants.BackgroundColor;
            Padding = new Thickness(60, 60, 60, 0);

            var cart = new Label { Text = "This is your shopping cart", FontSize = 25 };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { cart }
            };

        }
    }
}