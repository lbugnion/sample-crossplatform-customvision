using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomVisionClient
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage ()
		{
			InitializeComponent ();

            PredictionKeyEntry.TextChanged += (s, e) =>
            {
                App.PredictionKey = ((Entry)s).Text;
            };

            PredictionKeyEntry.Text = App.PredictionKey;

            ProjectIdEntry.TextChanged += (s, e) =>
            {
                App.ProjectId = ((Entry)s).Text;
            };

            ProjectIdEntry.Text = App.ProjectId;

            PublishedNameEntry.TextChanged += (s, e) =>
            {
                App.PublishedName = ((Entry)s).Text;
            };

            PublishedNameEntry.Text = App.PublishedName;

            EndpointEntry.TextChanged += (s, e) =>
            {
                App.Endpoint = ((Entry)s).Text;
            };

            EndpointEntry.Text = App.Endpoint;
        }
    }
}