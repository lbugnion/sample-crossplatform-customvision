using Microsoft.Cognitive.CustomVision.Prediction;
using Microsoft.Cognitive.CustomVision.Prediction.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace CustomVisionClient
{
    public partial class MainPage : ContentPage
    {
        private PredictionEndpoint _endpoint;

        public MainPage()
        {
            InitializeComponent();

            GoButton.Clicked += async (s, e) =>
            {
            };
        }
    }
}
