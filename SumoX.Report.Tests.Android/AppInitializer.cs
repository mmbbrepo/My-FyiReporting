﻿using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace SumoX.Report.Tests.Android
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}