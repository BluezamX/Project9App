using App1.CustomViewCells;
using App1.Managers;
using App1.Models.MTG;
using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class SetPageDetail : ContentPage
  {
    MasterDetailPage Master = new MasterDetailPage();

    public SetPageDetail()
    {
      InitializeComponent();
      SetViewModel viewModel = new SetViewModel();
      BindingContext = viewModel;
      MyListView.RowHeight = 60;
      MyListView.ItemTemplate = new DataTemplate(typeof(SetViewCell));
      MyListView.ItemSelected += ListView_ItemSelected;
    }

    public SetPageDetail(MasterDetailPage master)
    {
      Master = master;
      InitializeComponent();
      SetViewModel viewModel = new SetViewModel();
      BindingContext = viewModel;
      MyListView.RowHeight = 60;
      MyListView.ItemTemplate = new DataTemplate(typeof(SetViewCell));
      MyListView.ItemSelected += ListView_ItemSelected;
    }

    private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
      MTGSet item = (MTGSet)e.SelectedItem;
      if (item == null)
      {
        return;
      }
      
      await FillList(item);

      App.setType = item.name;
      var page = (Page)Activator.CreateInstance(this.GetType());
      page.Title = item.name;

      await App.navPage.PushAsync(page);
      Master.Detail = App.navPage;
      Master.IsPresented = false;
    }

    async Task FillList(MTGSet set)
    {
      try
      {
        if (!DatabaseManager.CardTableFilled(set) && !ConnectionManager.CheckConnection())
        {
          await DisplayAlert("No Internet", "You do not have downloaded this cardlist, and no available internet connection.", "OK");
        }
        else
        {
          List<Card> cards = new List<Card>();
          if (DatabaseManager.CardTableFilled(set))
          {
            cards = DatabaseManager.GetCards(set);
          }
          else
          {
            var list = await ApiManager.GetCards(set.code);
            DatabaseManager.AddCards(list);
          }
          
          CardList cl = new CardList(set);
          Application.Current.MainPage = cl;
          //await Navigation.PushAsync(cl);
        }
      }
      catch (Exception ex)
      {
        await DisplayAlert("Error", ex.Message, "OK");
      }
    }
  }
}