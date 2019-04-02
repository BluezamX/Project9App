using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class SetPageMaster : ContentPage
  {
    public ListView ListView;
    private string[] names;

    public SetPageMaster()
    {
      InitializeComponent();
      names = new string[] { HomeBtn.Text, FirstBtn.Text, SecondBtn.Text, ThirdBtn.Text, FourthBtn.Text, FifthBtn.Text, SixthBtn.Text, SeventhBtn.Text };
      BindingContext = new SetPageMasterViewModel(names);
      //ListView = MenuItemsListView;
    }

    class SetPageMasterViewModel : INotifyPropertyChanged
    {
      private readonly string[] names;
      public ICommand GoHomeCommand { get; set; }
      public ICommand GoSecondCommand { get; set; }
      public ICommand GoThirdCommand { get; set; }
      public ObservableCollection<SetPageMenuItem> MenuItems { get; set; }

      public SetPageMasterViewModel(string[] names)
      {
        this.names = names;
        GoHomeCommand = new Command(GoHome);
        GoSecondCommand = new Command(GoSecond);
        GoThirdCommand = new Command(GoThird);
      }

      void GoHome(object obj)
      {
        App.setType = names[0];
        App.navPage.Navigation.PopToRootAsync();
        //App.MenuIsPresented = false;
      }

      void GoFirst(object obj)
      {
        App.setType = names[1];
        App.navPage.Navigation.PushAsync(new SetList()); //the content page you wanna load on this click event 
        //App.MenuIsPresented = false;
      }

      void GoSecond(object obj)
      {
        App.setType = names[2];
        App.navPage.Navigation.PushAsync(new SetList()); //the content page you wanna load on this click event 
        //App.MenuIsPresented = false;
      }

      void GoThird(object obj)
      {
        App.setType = names[3];
        App.navPage.Navigation.PushAsync(new SetList());
        //App.MenuIsPresented = false;
      }

      void GoFourth(object obj)
      {
        App.setType = names[3];
        App.navPage.Navigation.PushAsync(new SetList());
        //App.MenuIsPresented = false;
      }

      void GoFifth(object obj)
      {
        App.setType = names[3];
        App.navPage.Navigation.PushAsync(new SetList());
        //App.MenuIsPresented = false;
      }

      void GoSixth(object obj)
      {
        App.setType = names[3];
        App.navPage.Navigation.PushAsync(new SetList());
        //App.MenuIsPresented = false;
      }

      void GoSeventh(object obj)
      {
        App.setType = names[3];
        App.navPage.Navigation.PushAsync(new SetList());
        //App.MenuIsPresented = false;
      }

      #region INotifyPropertyChanged Implementation
      public event PropertyChangedEventHandler PropertyChanged;
      void OnPropertyChanged([CallerMemberName] string propertyName = "")
      {
        if (PropertyChanged == null)
          return;

        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
      #endregion
    }
    /*
    public SetPageMasterViewModel()
    {
      MenuItems = new ObservableCollection<SetPageMenuItem>(new[]
      {
          new SetPageMenuItem { Id = 0, Title = "Expansion" },
          new SetPageMenuItem { Id = 1, Title = "Core" },
          new SetPageMenuItem { Id = 2, Title = "Draft" },
          new SetPageMenuItem { Id = 3, Title = "Commander" },
          new SetPageMenuItem { Id = 4, Title = "Deck" },
          new SetPageMenuItem { Id = 5, Title = "Promo" },
          new SetPageMenuItem { Id = 6, Title = "Silver Border" }
      });
    }

    #region INotifyPropertyChanged Implementation
    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
      if (PropertyChanged == null)
        return;

      PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion*/
  }
}