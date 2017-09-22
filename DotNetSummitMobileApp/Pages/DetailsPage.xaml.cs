using System;
using DotNetSummitMobileApp.Models;
using DotNetSummitMobileApp.Services;
using Xamarin.Forms;

namespace DotNetSummitMobileApp.Pages
{
    public partial class DetailsPage : ContentPage
    {
		private static DataService _dataService;

		private static string _fullName = string.Empty;

        public DetailsPage(string fullName)
        {
			InitializeComponent();

			_dataService = new DataService();

			_fullName = fullName;
        }

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			InvertControlsVisibility(true);

			var data = await _dataService.GetAllData();

			var speaker = FindSpeaker(data, _fullName);
			var track = FindTrack(data, _fullName);

			SpeakerPhoto.Source = ImageSource.FromUri(new Uri(speaker.Photo));

			FullName.Text = speaker.FullName;
			Position.Text = speaker.Position;

			Bio.Text = speaker.Bio;

			Topic.Text = track.Topic;
			Description.Text = track.Description;

			InvertControlsVisibility(false);
		}

		private Speaker FindSpeaker(Conference conference, string fullName)
		{
			return conference.Speakers.Find(x => x.FullName == fullName);
		}

		private Track FindTrack(Conference conference, string fullName)
		{
			return conference.Tracks.Find(x => x.FullName == fullName);
		}

		private void InvertControlsVisibility(bool visible)
		{
			DetailsScrollView.IsVisible = !visible;
			ActivityIndicatorView.IsVisible = visible;
		}
    }
}
