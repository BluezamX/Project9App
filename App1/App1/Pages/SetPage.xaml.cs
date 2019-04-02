using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class SetPage : MasterDetailPage
  {
    public SetPage()
    {
      InitializeComponent();
      MasterPage.ListView.ItemSelected += ListView_ItemSelected;
    }

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
      var item = e.SelectedItem as SetPageMenuItem;
      if (item == null)
        return;

      App.setType = item.Title;
      SetPageDetail page = new SetPageDetail(this)
      {
        Title = item.Title
      };

      App.navPage.PushAsync(page);
      Detail = App.navPage;
      IsPresented = false;

      MasterPage.ListView.SelectedItem = null;
    }

    protected override bool OnBackButtonPressed()
    {
      App.navPage.PopAsync();
      return true;
    }
  }
}