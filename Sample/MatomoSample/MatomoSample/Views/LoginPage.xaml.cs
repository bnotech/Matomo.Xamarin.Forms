using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matomo.Xamarin.Forms;
using MatomoSample.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MatomoSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.MatomoAnalytics.TrackPage(Shell.Current.Title, ShellHelper.Instance.CurrentPath);
        }
    }
}
