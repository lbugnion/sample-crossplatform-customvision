using Xamarin.Forms;

namespace CustomVisionClient
{
    public partial class App : Application
    {
        public const string PredictionKey = "3a23be17748a44cdbbedf9ad2ff36c93";
        public const string ProjectId = "02447956-3451-4be8-bf32-bdc652c94b83";

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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