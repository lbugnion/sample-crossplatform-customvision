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
        private PredictionEndpoint _endpoint;

        public MainPage()
        {
            InitializeComponent();

            GoButton.Clicked += async (s, e) =>
            {
                if (string.IsNullOrEmpty(App.PredictionKey)
                    || string.IsNullOrEmpty(App.ProjectId))
                {
                    await DisplayAlert(
                        "Set the values first",
                        "You must set the values in the Settings page first",
                        "OK");
                    return;
                }

                if (_endpoint == null)
                {
                    _endpoint = new PredictionEndpoint
                    {
                        ApiKey = App.PredictionKey
                    };
                }

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
                    DisplayImage.Source = ImageSource.FromFile(file.Path);
                });
            };

            SettingsButton.Clicked += (s, e) =>
            {
                Navigation.PushAsync(new SettingsPage());
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
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return message;
        }
    }
}
