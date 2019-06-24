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

        public static string PredictionKey
        {
            get => AppSettings.GetValueOrDefault(nameof(PredictionKey), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(PredictionKey), value);
        }

        public static string ProjectId
        {
            get => AppSettings.GetValueOrDefault(nameof(ProjectId), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(ProjectId), value);
        }

        public static string PublishedName
        {
            get => AppSettings.GetValueOrDefault(nameof(PublishedName), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(PublishedName), value);
        }

        public static string Endpoint
        {
            get => AppSettings.GetValueOrDefault(nameof(Endpoint), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Endpoint), value);
        }

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
