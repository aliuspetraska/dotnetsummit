using System;
using DotNetSummitMobileApp.CustomComponents;
using DotNetSummitMobileApp.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace DotNetSummitMobileApp.Droid.CustomRenderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
                Control.SetPadding(16, 16, 16, 16);
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
			}
		}
    }
}
