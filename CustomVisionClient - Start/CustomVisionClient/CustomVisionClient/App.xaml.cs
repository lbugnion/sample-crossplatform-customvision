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

        public const string PredictionKey = "PREDICTIONKEY";
        public static string ProjectId = "PROJECTID";

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
