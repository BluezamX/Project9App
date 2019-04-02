using App1.CustomViewCells;
using App1.Managers;
using App1.Models.MTG;
using App1.Pages;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class CardList : ContentPage
  {
    public ObservableCollection<Card> items { get; set; }
    private MTGSet set;
    private List<Card> cards { get; set; }

    public CardList(MTGSet set)
    {
      this.set = set;
      InitializeComponent();
      StartUp();
    }

    async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
    {
      if (e.Item == null)
        return;

      CardImage ci = new CardImage((Card)e.Item);
      ci.WidthRequest = Application.Current.MainPage.Width;
      ci.HeightRequest = Application.Current.MainPage.Width * 1.4;
      await Navigation.PushModalAsync(ci);

      //Deselect Item
      ((ListView)sender).SelectedItem = null;
    }

    private void StartUp()
    {
      cards = DatabaseManager.GetCards(set);

      items = new ObservableCollection<Card>();

      MyListView.RowHeight = 60;
      Title = "Pick a Card";
      MyListView.ItemTemplate = new DataTemplate(typeof(CardViewCell));
      foreach (Card card in cards)
      {
        items.Add(card);
      }
      MyListView.ItemsSource = items;
    }

    protected override bool OnBackButtonPressed()
    {
      App.navPage.PopAsync();
      return true;
    }
  }
}

/*
cards.Add(new Card("Annul",
    "U",
    "www.x.nl",
    "Instant",
    "THS",
    "Counter target Artifact or Enchantment Spell.",
    "The one Instant to rule them all.",
    "",
    "",
    "Unknown",
    256));
    */
