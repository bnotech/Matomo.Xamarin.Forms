using System.ComponentModel;
using Xamarin.Forms;
using MatomoSample.ViewModels;
using Matomo.Xamarin.Forms;

namespace MatomoSample.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.MatomoAnalytics.TrackPage(Shell.Current.Title, ShellHelper.Instance.CurrentPath);
        }
    }
}
