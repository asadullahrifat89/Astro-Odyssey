﻿using Microsoft.Extensions.Configuration;
using System;
using System.Windows.Browser;
using Windows.UI.Xaml;

namespace AstroOdyssey
{
    public sealed partial class App : Application
    {
        private static MainPage mainPage;

        private static string baseUrl;

        private IConfiguration configuration;

        public App(IConfiguration configuration)
        {
            InitializeComponent();

            this.configuration = configuration;

            Startup += App_Startup;            

            mainPage = new MainPage();
            Window.Current.Content = mainPage;

            SetBaseUrl();

            mainPage.NavigateToPage("/GameStartPage");
        }

        private void Current_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject.Message);
            e.Handled = true;
        }

        private void SetBaseUrl()
        {
            baseUrl = HtmlPage.Document.DocumentUri.OriginalString.Split('#')[0];
        }

        public static string GetBaseUrl()
        {
            return baseUrl;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {

        }

        public static void NavigateToPage(string targetUri)
        {
            mainPage.NavigateToPage(targetUri);
        }
    }
}
