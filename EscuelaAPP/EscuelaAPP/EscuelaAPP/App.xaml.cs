using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EscuelaAPP.Services;
using EscuelaAPP.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EscuelaAPP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            ///Pagina del inicio
            MainPage = new NavigationPage(new MainPage());
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
