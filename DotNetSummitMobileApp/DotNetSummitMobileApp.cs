using DotNetSummitMobileApp.Pages;
using Xamarin.Forms;

namespace DotNetSummitMobileApp
{
    public class App : Application
    {
        public App()
        {
			var tabbedPage = new TabbedPage
			{
				Title = "#dotnetsummit",
                BarBackgroundColor = Color.FromHex("6B459A"),
                BarTextColor = Color.White
			};

            tabbedPage.Children.Add(new SpeakersPage()
            {
                Title = "Speakers",
                Icon = "conference.png"
			});

			tabbedPage.Children.Add(new ProgramPage()
			{
				Title = "Program",
                Icon = "presentation.png"
			});

			// The root page of your application
			MainPage = new NavigationPage(tabbedPage) {
				BarBackgroundColor = Color.FromHex("6B459A"),
				BarTextColor = Color.White
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
