﻿using App1.Managers;
using App1.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App1
{
  public partial class App : Application
  {
    public static SetPage defaultPage = new SetPage();
    public static NavigationPage navPage = new NavigationPage();
   
    public static string setType = "";

    public App()
    {
      InitializeComponent();
      DatabaseManager.Create();

      var seconds = TimeSpan.FromSeconds(60);
      Device.StartTimer(seconds,
          () =>
          {
            return ConnectionManager.CheckConnection();
          });

      MainPage = defaultPage;
    }

    protected override void OnStart()
    {
      // Handle when your app starts
    }

    protected override void OnSleep()
    {
      // Handle when your app sleeps
    }

    protected override void OnResume()
    {
      // Handle when your app resumes
    }
  }
}
