using Xamarin.Forms;

namespace CustomVisionClient
{
    public partial class App : Application
    {
        public const string PredictionKey = "PREDICTIONKEY";
        public const string ProjectId = "PROJECTID";

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