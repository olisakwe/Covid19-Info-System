using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Covid19_Info_System.Services
{
   public class ConnectivityServices
    {
       public static bool CheckConnection()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.None)
            {
                return false;   
            }
            return true;
        }
        //Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        //void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        //{
        //    bool stillConnected = e.IsConnected;
        //}
    }
}
