using App1.Managers;
using App1.Pages;
using Plugin.Connectivity;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App1
{
    public partial class App : Application
    {
        public static string setType = "";
        public App()
        {
            InitializeComponent();
            DatabaseManager.Create();

            var seconds = TimeSpan.FromSeconds(60);
            Device.StartTimer(seconds,
                () =>
                {
                    return ConnectionManager.CheckConnection();
                });

            MainPage = new SetPage();
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
