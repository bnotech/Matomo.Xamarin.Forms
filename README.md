# Matomo.Xamarin.Forms

This library provides [Matomo](https://matomo.org) Tracking for Xamarin.Forms Apps.

## Status

[![Continuous Integration](https://github.com/bfn-tech/Matomo.Xamarin.Forms/actions/workflows/ci.yml/badge.svg)](https://github.com/bfn-tech/Matomo.Xamarin.Forms/actions/workflows/ci.yml)

## Initial Setup

Getting started with Matomo.Xamarin.Forms is pretty easy:

1. Add the Matomo.Xamarin.Forms Nuget to your project

2. In your App.xaml.cs add:

```
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
```

The code above connects your app to site number 1 on your Matomo instance, change the Url and the Site ID accordingly.
In addition this code will Expose the MatomoAnalytics class to your App by just calling `App.MatomoAnalytics`.

3. In your App.xaml.cs OnSleep Method add:

```
MatomoAnalytics.LeavingTheApp();
```

The library will batch submit the tracking data upon the app going into Background, without this call you will not receive any Tracking Data!

4. When using Shell navigation tracking page visits is made simple with the `ShellHelper`: Add to your OnAppearing methods the following call:

```
App.MatomoAnalytics.TrackPage(Shell.Current.Title, ShellHelper.Instance.CurrentPath);
```

`ShellHelper.Instance.CurrentPath` generates you the full path to the Page you are currently starting to watch.

## Documentation

You can find a reference documentation [here](https://bfn-tech.github.io/Matomo.Xamarin.Forms/html/index.html).

And a sample project in the `Sample/` folder.

## Credit

This work is based on the work done at [zauberzeug/xamarin.piwik](https://github.com/zauberzeug/xamarin.piwik)

## License

This project retains the [MIT license](https://github.com/bfn-tech/Matomo.Maui/blob/main/LICENSE.md) as per the original project.

## Support

In case of issues with the library feel free to provide feedback via the Issues tab or if you want to support the project feel free to contribute via Pull Request.

If you need assistance getting started with Matomo and .NET MAUI feel free to [reach out](https://www.bnotech.com/en/contact.html).