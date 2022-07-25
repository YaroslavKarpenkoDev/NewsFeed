using System;
using Xamarin.Forms;

namespace NewsFeed.Controls
{
    public class BorderlessEntry : Entry
    {
        public delegate void BackspaceEventHandler(object sender, EventArgs e);

        public event EventHandler<EventArgs> OnBackspace;

        public static BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(BorderlessEntry), new Thickness(5));

        public Thickness Padding
        {
            get => (Thickness)GetValue(PaddingProperty);
            set => SetValue(PaddingProperty, value);
        }

        public void OnBackspacePressed()
        {
            OnBackspace?.Invoke(null, null);
        }
    }
}