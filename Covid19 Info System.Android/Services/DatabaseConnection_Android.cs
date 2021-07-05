using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Covid19_Info_System.Droid.Services;
using Covid19_Info_System.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]
namespace Covid19_Info_System.Droid.Services
{
    class DatabaseConnection_Android: IDatabaseConnection
    {
        public SQLiteAsyncConnection DbConnection()
        {
            var dbName = "CovidSignIS.db3";
            var path = Path.Combine(System.Environment.
              GetFolderPath(System.Environment.
              SpecialFolder.Personal), dbName);
            return new SQLiteAsyncConnection(path);
        }
    }
}