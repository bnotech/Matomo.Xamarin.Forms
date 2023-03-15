using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MatomoSample.Models;
using MatomoSample.ViewModels;
using Matomo.Xamarin.Forms;

namespace MatomoSample.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.MatomoAnalytics.TrackPage(Shell.Current.Title, ShellHelper.Instance.CurrentPath);
        }
    }
}
