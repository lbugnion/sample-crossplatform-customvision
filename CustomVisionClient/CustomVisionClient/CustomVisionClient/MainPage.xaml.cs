﻿using Microsoft.Cognitive.CustomVision.Prediction;
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
        private PredictionEndpoint _endpoint = new PredictionEndpoint
        {
            ApiKey = App.PredictionKey
        };

        public MainPage()
		{
			InitializeComponent();

            GoButton.Clicked += async (s, e) =>
            {
                ResultLabel.Text = "Please wait...";
                DisplayImage.Source = null;

                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable
                    || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert(
                        "No Camera",
                        ":( No camera available.",
                        "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        Directory = "FruitRecognizer",
                        Name = "test.jpg"
                    });

                if (file == null)
                {
                    return;
                }

                // Give the device some time to come back to the UI
                // before starting recognition
                Device.BeginInvokeOnMainThread(() =>
                {
                    ResultLabel.Text = RecognizePicture(file);
                    DeletePhoto(file);
                });
            };
        }

        private string RecognizePicture(MediaFile file)
        {
            var message = "Nothing recognized...";

            try
            {
                if (file != null)
                {
                    IEnumerable<ImageTagPredictionModel> tags = null;

                    using (var stream = file.GetStream())
                    {
                        tags = _endpoint.PredictImage(Guid.Parse(App.ProjectId), stream)
                            .Predictions
                            .OrderByDescending(p => p.Probability);
                    }

                    var bestTag = tags
                        .FirstOrDefault(p => p.Probability > 0.5);

                    if (bestTag != null)
                    {
                        message = $"{bestTag.Tag} ({bestTag.Probability:P1})";
                    }
                    else
                    {
                        message = $"Not quite sure...";

                        foreach (var tag in tags)
                        {
                            message += Environment.NewLine
                                + $"({tag.Tag}, {tag.Probability:P1})";
                        }
                    }

                    DisplayImage.Source = ImageSource.FromFile(file.Path);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return message;
        }

        private void DeletePhoto(MediaFile file)
        {
            var path = file?.Path;

            if (!string.IsNullOrEmpty(path) 
                && File.Exists(path))
            {
                File.Delete(file?.Path);
            }
        }
    }
}
