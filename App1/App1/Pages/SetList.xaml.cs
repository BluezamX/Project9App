using App1.CustomViewCells;
using App1.Managers;
using App1.Models.MTG;
using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetList : ContentPage
    {
        public SetList()
        {
            InitializeComponent();
            SetViewModel viewModel = new SetViewModel();
            BindingContext = viewModel;
            MyListView.RowHeight = 60;
            MyListView.ItemTemplate = new DataTemplate(typeof(SetViewCell));
            //MyListView.ItemsSource = items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            try
            {
                if (!DatabaseManager.CardTableFilled((MTGSet)e.Item) && !ConnectionManager.CheckConnection())
                {
                    await DisplayAlert("No Internet", "You do not have downloaded this cardlist, and no available internet connection.", "OK");
                }
                else
                {
                    MTGSet set = (MTGSet)e.Item;
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

                    CardList cl = new CardList((MTGSet)e.Item);
                    Application.Current.MainPage = cl;
                    //await Navigation.PushAsync(cl);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
