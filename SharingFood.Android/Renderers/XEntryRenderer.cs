using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using SharingFood.Droid.Renderers;
using System;
using SharingFood.Controls;

[assembly: ExportRenderer(typeof(XEntry), typeof(XEntryRenderer))]
namespace SharingFood.Droid.Renderers
{
    public class XEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
}