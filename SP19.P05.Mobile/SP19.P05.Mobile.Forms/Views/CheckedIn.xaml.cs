using Newtonsoft.Json;
using SP19.P05.Mobile.Forms.Model;
using SP19.P05.Mobile.Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SP19.P05.Mobile.Forms.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CheckedIn : ContentPage
	{
		public CheckedIn ()
		{
            this.Title = "Checked In";
            BackgroundColor = Constants.BackgroundColor;

            StackLayout stacklayout = new StackLayout();
            Padding = new Thickness(60, 0, 60, 0);
            Image chkin = new Image { Source = "Checkin.png", HeightRequest = Constants.LoginIconHeight, Margin = new Thickness(0, 60, 0, 0) };

            var lbl_greet = new Label { Text = "Hello Krishna!! ", TextColor = Color.Green, HorizontalTextAlignment= TextAlignment.Center };
            var lbl_table = new Label { Text="You are checked in table no. " + Constants.tableid ,TextColor= Color.Green, HorizontalTextAlignment = TextAlignment.Center };
            var assist = new Button { Text = "Call Server", BackgroundColor = Color.Red, TextColor= Color.White,FontAttributes = FontAttributes.Bold };
            var pay = new Button { Text = "Pay", BackgroundColor = Color.Green, TextColor = Color.White, FontAttributes= FontAttributes.Bold };
            var water = new Button { Text = "Drink Refil", BackgroundColor = Color.Green, TextColor = Color.White, FontAttributes = FontAttributes.Bold };
            var sauce = new Button { Text = "Sauce Refil", BackgroundColor = Color.Green, TextColor = Color.White, FontAttributes = FontAttributes.Bold };

            assist.Clicked += (object s, EventArgs e) =>
            {
                HttpClient httpClient = new HttpClient();
                Attention dto = new Attention();
                dto.TableId = int.Parse(Constants.tableid);
                var content = JsonConvert.SerializeObject(dto);
                HttpContent httpContent = new StringContent(content);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = httpClient.PutAsync("https://fancypos-sp19-p05-g01-lopsided-desk.azurewebsites.net/api/Tables/NeedAttention", httpContent);
            };
            sauce.Clicked += (object s, EventArgs e) =>
            {
                HttpClient httpClient = new HttpClient();
                RefilDto dto = new RefilDto();
                dto.TableId = int.Parse(Constants.tableid);
                dto.refil = 's';
                var content = JsonConvert.SerializeObject(dto);
                HttpContent httpContent = new StringContent(content);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = httpClient.PutAsync("https://fancypos-sp19-p05-g01-lopsided-desk.azurewebsites.net/api/Tables/NeedRefil", httpContent);
            };
            water.Clicked += (object s, EventArgs e) =>
            {
                HttpClient httpClient = new HttpClient();
                RefilDto dto = new RefilDto();
                dto.TableId = int.Parse(Constants.tableid);
                dto.refil = 'w';
                var content = JsonConvert.SerializeObject(dto);
                HttpContent httpContent = new StringContent(content);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = httpClient.PutAsync("https://fancypos-sp19-p05-g01-lopsided-desk.azurewebsites.net/api/Tables/NeedRefil", httpContent);
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { chkin,lbl_greet, lbl_table,assist, water, sauce, pay }
            };

        }
	}
}