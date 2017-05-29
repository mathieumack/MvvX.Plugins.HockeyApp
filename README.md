# MvvX.HockeyApp

Use HockeyApp SDK on a MvvmCross application.
=========

## Build 

[![Build status](https://ci.appveyor.com/api/projects/status/qoqollxlhlus880l?svg=true)](https://ci.appveyor.com/project/mathieumack/mvvx-plugins-hockeyapp)

## Nuget

[![NuGet package](https://buildstats.info/nuget/MvvX.Plugins.HockeyApp?includePreReleases=true)](https://nuget.org/packages/MvvX.Plugins.HockeyApp)

The SDK for the http://www.hockeyapp.com for application that use https://mvvmcross.com/.

## Platform Support

| Platform | Available 
| --- | --- |
| WPF 4.5 | &#x2713; | 
| UWP | &#x2713; | 
| Xamarin.Android | &#x2713; |
| Xamarin.iOS | &#x2713; |

### Minimum MvvmCross version

This plugin is compatible with MvvmCross 4.2.2 min.

## Onboarding Instructions 
1. Add nuget package: 

    Install-Package MvvX.Plugins.HockeyApp

2. In App.xaml.cs file add the following line in usage declaration section:
    <pre>MvvX.Plugins.HockeyApp;</pre>
3. In App.xaml.cs file add the following line in App class constructor: 
```C#
        var hockeyAppClientId = "Set HockeyApp Id here";
        var buildVersion = "Set your application build version here"; 
        // ex : Assembly.GetExecutingAssembly().GetName().Version.ToString()
        var hockeyClient = Mvx.Resolve<IHockeyClient>();
        hockeyClient.Configure(hockeyAppClientId, buildVersion, true, true, true);
```

## IHockeyClient methods support

| Method | WPF 4.5 | Xamarin.Android | Xamarin.iOS | UWP
| --- | --- | --- | --- | --- |
| Configure(...) | &#x2713; | &#x2713; | &#x2713; |  &#x2713; |
| SendCrashesAsync() | &#x2713; | --- | --- |  --- |
| Flush() | &#x2713; | --- | --- |  &#x2713; |
| TrackEvent(...) | &#x2713; | &#x2713; | &#x2713; |  &#x2713; |
| TrackException(...) | &#x2713; | --- | --- |  &#x2713; |
| TrackMetric(...) | &#x2713; | --- | --- |  &#x2713; |
| TrackPageView(...) | &#x2713; | --- | --- |  &#x2713; |
| TrackTrace(...) | &#x2713; | --- | --- |  &#x2713; |

Becarefull, some functionnalities does not work with the interface but are available with the platform HockeySDK platform.
You can check platform capabilities to:

| Platform | Available 
| --- | --- |
| WPF 4.5 | &#x2713; | 
| UWP | &#x2713; | 
| Xamarin.Android | &#x2713; |
| Xamarin.iOS | &#x2713; |

## Support
If you have any questions, problems or suggestions, create an issue.