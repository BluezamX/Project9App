using App1.Managers;
using App1.Models.MTG;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
  public class CardViewModel : INotifyPropertyChanged
  {
    public MTGSet set;

    public ObservableCollection<Card> items { get; set; }
    public ObservableCollection<Card> Items
    {
      get => items;
      set
      {
        if (value == items) return;
        items = value;
        OnPropertyChanged(nameof(Items));
      }
    }

    private List<Card> cards { get; set; }

    public ListView myListView;
    public ListView MyListView
    {
      get => myListView;
      set
      {
        if (value == myListView) return;
        myListView = value;
        OnPropertyChanged(nameof(MyListView));
      }
    }

    public ICommand updateCommand { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public CardViewModel(MTGSet set)
    {
      updateCommand = new Command(async () =>
      {
        try
        {
          System.Diagnostics.Debug.WriteLine("Patatofiel SVM");
          var list = await ApiManager.GetCards(set.code);
          DatabaseManager.AddCards(list);
          FillCards();
        }
        catch (Exception ex)
        {
          System.Diagnostics.Debug.WriteLine("Piemellikker " + ex);
        }
      });

      this.set = set;
      FillCards();
    }

    private void FillCards()
    {
      Items = new ObservableCollection<Card>(cards);
    }
  }
}
