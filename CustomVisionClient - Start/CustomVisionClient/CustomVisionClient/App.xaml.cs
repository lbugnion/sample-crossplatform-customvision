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
        public const string PredictionKey = "PREDICTIONKEY";
        public const string ProjectId = "PROJECTID";
        public const string PublishedName = "PUBLISHEDNAME";
        public const string Endpoint = "ENDPOINT";
        
        public static Guid ProjectGuid
        {
            get
            {
                var id = ProjectId;

                if (string.IsNullOrEmpty(id))
                {
                    return Guid.Empty;
                }

                return Guid.Parse(id);
            }
        }

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
