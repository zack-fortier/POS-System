using Newtonsoft.Json;
using SP19.P05.Mobile.Forms.Model;
using SP19.P05.Mobile.Forms.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace SP19.P05.Mobile.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Checkin : ContentPage
    {
        public Checkin()
        {
            InitializeComponent();

        }
        private async void Button_Click(object sender, EventArgs e)
        {
            try
            {
                var httpClient = new HttpClient();
                var scan = new ZXingScannerPage();
                await Navigation.PushAsync(scan);
                scan.OnScanResult += (result) =>
                {
                Device.BeginInvokeOnMainThread(async () =>
                {
                await Navigation.PopAsync();
                Constants.tableid = result.Text;
                if (Constants.tableid == " ")
                {
                    await DisplayAlert("CheckIn", "CheckIn Failed", "OK");
                }
                else
                {
                    checkInDto dto = new checkInDto();
                            dto.CustomerId = 2;
                        dto.TableId = int.Parse(Constants.tableid);
                            var content = JsonConvert.SerializeObject(dto);
                            HttpContent httpContent = new StringContent(content);
                            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                            var response = await httpClient.PutAsync("https://fancypos-sp19-p05-g01-lopsided-desk.azurewebsites.net/api/Tables/CheckIn", httpContent);
                            await Navigation.PushModalAsync(new CheckinMain());
                            App.Current.MainPage = new NavigationPage(new CheckinMain());
                    }
                });
                };
            }
            catch (Exception ex)
            {
                string er = ex.ToString();
               await DisplayAlert("Sorry...", "Something went wrong. Try again later", "OK");
            }
        }

        private async void Reserve_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Reservation());

        }
    }
}