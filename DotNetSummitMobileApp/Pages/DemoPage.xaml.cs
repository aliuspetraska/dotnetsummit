using DotNetSummitMobileApp.CustomComponents;
using Xamarin.Forms;

namespace DotNetSummitMobileApp.Pages
{
    public partial class DemoPage : ContentPage
    {
        public DemoPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LayoutRoot.Children.Add(new CustomEntry{
                Placeholder = "Placeholder..."
            });
        }
    }
}
