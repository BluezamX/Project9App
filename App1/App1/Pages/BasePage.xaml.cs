﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BasePage : ContentPage
  {
    public BasePage()
    {
      InitializeComponent();
      Application.Current.MainPage = new SetList();
    }
  }
}