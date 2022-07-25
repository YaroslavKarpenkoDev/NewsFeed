using Android.Content;
using Android.Text;
using Android.Views;
using NewsFeed.Controls;
using System;
using NewsFeed.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntryRenderer))]
namespace NewsFeed.Droid.Renderers
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        public BorderlessEntryRenderer(Context context)
            : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.Background = null;
                Control.SetPadding(0, 0, 0, 0);

                var entry = (BorderlessEntry)Element;
                if (entry.Keyboard == Keyboard.Numeric && entry.ClassId == "pin")
                    Control.InputType = InputTypes.ClassNumber;
            }
        }

        public override bool DispatchKeyEvent(KeyEvent e)
        {
            try
            {
                if (e.Action == KeyEventActions.Down && e.KeyCode == Keycode.Del)
                    ((BorderlessEntry)Element).OnBackspacePressed();

                return base.DispatchKeyEvent(e);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }
        }
    }
}