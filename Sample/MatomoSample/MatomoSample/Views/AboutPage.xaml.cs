using System;
using System.ComponentModel;
using Matomo.Xamarin.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MatomoSample.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.MatomoAnalytics.TrackPage(Shell.Current.Title, ShellHelper.Instance.CurrentPath);
        }
    }
}
