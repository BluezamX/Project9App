using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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
