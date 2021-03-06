﻿using System;
using DotNetSummitMobileApp.CustomComponents;
using DotNetSummitMobileApp.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace DotNetSummitMobileApp.iOS.CustomRenderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
                Control.BorderStyle = UITextBorderStyle.None;
			}
		}
    }
}
