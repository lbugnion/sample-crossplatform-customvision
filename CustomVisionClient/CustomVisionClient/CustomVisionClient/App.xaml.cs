using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CustomVisionClient
{
	public partial class App : Application
	{
        public const string PredictionKey = "10531f37553c4c999c6a3f0f06ca6393";
        public const string ProjectId = "9dbf6cd8-e25b-4fab-8275-4df2ef5ae82e";

        public App ()
		{
			InitializeComponent();

			MainPage = new CustomVisionClient.MainPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
