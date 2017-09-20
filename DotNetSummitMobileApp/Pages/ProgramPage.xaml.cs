using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DotNetSummitMobileApp.Models;
using DotNetSummitMobileApp.Services;
using Xamarin.Forms;

namespace DotNetSummitMobileApp.Pages
{
    public partial class ProgramPage : ContentPage
    {
        private static DataService _dataService;

        public ProgramPage()
        {
            InitializeComponent();

            _dataService = new DataService();

			ProgramListView.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => {
                if (e.SelectedItem != null) 
                {
                    var track = e.SelectedItem as Track;

                    if (track.FullName != "Networking")
                    {
                        Navigation.PushAsync(new SpeakerDetails(track.FullName));
                    }

					ProgramListView.SelectedItem = null;
                }
			};

            ProgramListView.IsGroupingEnabled = true;
		}

        public ObservableCollection<Grouping<string, Track>> TracksGrouped { get; set; }

		protected override async void OnAppearing()
		{
			base.OnAppearing();

            InvertControlsVisibility(true);

			var data = await _dataService.GetAllData();

			// Use linq to sorty our monkeys by name and then group them by the new name sort property
			var sorted = from track in data.Tracks
						 orderby track.Time
						 group track by track.Time into tracksGroup
						 select new Grouping<string, Track>(tracksGroup.Key.ToString("HH:mm"), tracksGroup);

			// Create a new collection of groups
			TracksGrouped = new ObservableCollection<Grouping<string, Track>>(sorted);

			ProgramListView.ItemsSource = TracksGrouped;

			InvertControlsVisibility(false);
		}

		private void InvertControlsVisibility(bool visible)
		{
			ProgramListView.IsVisible = !visible;
			ActivityIndicatorView.IsVisible = visible;
		}
    }

	public class Grouping<K, T> : ObservableCollection<T>
	{
		public K Key { get; private set; }

		public Grouping(K key, IEnumerable<T> items)
		{
			Key = key;

            foreach (var item in items) {
                this.Items.Add(item);
            }
		}
	}
}
