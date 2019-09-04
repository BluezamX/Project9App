using Plugin.Connectivity;

namespace App1.Managers
{
  public class ConnectionManager
  {
    static void HandleRequest()
    {
    }

    public static bool CheckConnection()
    {
      return CrossConnectivity.Current.IsConnected;
    }
  }
}
