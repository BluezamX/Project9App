using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetPageMaster : ContentPage
    {
        public ListView ListView;

        public SetPageMaster()
        {
            InitializeComponent();

            BindingContext = new SetPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class SetPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<SetPageMenuItem> MenuItems { get; set; }
            
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
                    new SetPageMenuItem { Id = 6, Title = "Silver Border" },
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
            #endregion
        }
    }
}