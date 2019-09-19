using SP19.P05.Mobile.Forms.Views;
using Xamarin.Forms;
using System.IO;
using System;
using Xamarin.Forms.Xaml;

namespace SP19.P05.Mobile.Forms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

     }
}
