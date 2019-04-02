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
  public class SetViewModel : INotifyPropertyChanged
  {
    public ObservableCollection<MTGSet> items { get; set; }
    public ObservableCollection<MTGSet> Items
    {
      get => items;
      set
      {
        if (value == items) return;
        items = value;
        OnPropertyChanged(nameof(Items));
      }
    }

    private List<MTGSet> sets { get; set; }

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

    public SetViewModel()
    {
      updateCommand = new Command(async () =>
      {
        try
        {
          System.Diagnostics.Debug.WriteLine("Patatofiel SVM");
          var list = await ApiManager.GetSets();
          DatabaseManager.AddSets(list);
          FillSets();
        }
        catch (Exception ex)
        {
          System.Diagnostics.Debug.WriteLine("Piemellikker " + ex);
        }
      });

      FillSets();
    }

    private void FillSets()
    {
      System.Diagnostics.Debug.WriteLine("Patatofiel SVM Fill");
      Items = new ObservableCollection<MTGSet>();
      if (DatabaseManager.SetTableFilled())
      {
        sets = DatabaseManager.GetSets(new List<string> { App.setType });

        foreach (MTGSet set in sets)
        {
          items.Add(set);
        }
      }
    }
  }
}
