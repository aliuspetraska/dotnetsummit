using DotNetSummitMobileApp.Services;
using Xamarin.Forms;

namespace DotNetSummitMobileApp.Pages
{
    public partial class SpeakersPage : ContentPage
    {
        private static DataService _dataService;

        public SpeakersPage()
        {
            InitializeComponent();

            _dataService = new DataService();

            SpeakersListView.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => {
                SpeakersListView.SelectedItem = null;
            };
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            InvertControlsVisibility(true);

            var data = await _dataService.GetAllData();
            SpeakersListView.ItemsSource = data.Speakers;

            InvertControlsVisibility(false);
        }

        private void InvertControlsVisibility(bool visible)
        {
			SpeakersListView.IsVisible = !visible;
			ActivityIndicatorView.IsVisible = visible;
        }
    }
}
