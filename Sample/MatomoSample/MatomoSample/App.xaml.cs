using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MatomoSample.Services;
using MatomoSample.Views;
using Matomo.Xamarin.Forms;

namespace MatomoSample
{
    public partial class App : Application
    {
        private static object _matomoSyncRoot = new object();
        private static MatomoAnalytics _matomoAnalytics;
        public static MatomoAnalytics MatomoAnalytics
        {
            get
            {
                lock (_matomoSyncRoot)
                    if (_matomoAnalytics == null)
                    {
                        _matomoAnalytics = new MatomoAnalytics("https://url.to.matomo.instance/", 1);
                        _matomoAnalytics.AppUrl = "https://app/";
                    }
                return _matomoAnalytics;
            }
        }

        public App ()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
            MatomoAnalytics.LeavingTheApp();
        }

        protected override void OnResume ()
        {
        }
    }
}

