using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CustomVisionClient
{
    public partial class App : Application
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public const string PredictionKey = "726e925bfa0b49a8afadf9307809ec7f";
        public static string ProjectId = "bbd446b4-57ee-4a2e-8de0-793f1b154544";

        public App()
        {
            InitializeComponent();

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
