using App1.Pages;
using Xamarin.Forms;

namespace App1.Managers
{
  public static class TypeManager
  {
    public static SetPageMenuItem SelectedItemToSetPageMenuItem(SelectedItemChangedEventArgs e)
    {
      SetPageMenuItem newItem = new SetPageMenuItem();
      //newItem = e.SelectedItem.;
      return newItem;
    }
  }
}
