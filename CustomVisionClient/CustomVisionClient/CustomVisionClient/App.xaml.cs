using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Xamarin.Forms;

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

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }
    }
}