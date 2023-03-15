using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MatomoSample.Models;
using MatomoSample.Views;
using MatomoSample.ViewModels;
using Matomo.Xamarin.Forms;

namespace MatomoSample.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
            App.MatomoAnalytics.TrackPage(Shell.Current.Title, ShellHelper.Instance.CurrentPath);
        }
    }
}
