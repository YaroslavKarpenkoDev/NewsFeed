
using System;
using System.ComponentModel;
using NewsFeed.Controls;
using NewsFeed.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntryRenderer))]
namespace NewsFeed.iOS.Renderers
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        private IElementController ElementController => Element;

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control != null)
            {
                Control.Layer.BorderWidth = 0;
                Control.BorderStyle = UITextBorderStyle.None;
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var entry = (BorderlessEntry)Element;
                if (entry.Keyboard == Keyboard.Numeric)
                    Control.KeyboardType = UIKeyboardType.NumberPad;
            }
        }

        private void OnEditingChanged(object sender, EventArgs eventArgs)
        {
            ElementController.SetValueFromRenderer(Entry.TextProperty, Control.Text);
        }
    }
}