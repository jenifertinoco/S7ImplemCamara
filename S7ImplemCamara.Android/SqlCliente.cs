using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.IO;
using S7ImplemCamara.Droid;
//using SQLite.Droid;

[assembly: Xamarin.Forms.Dependency(typeof (SqlCliente))]
namespace S7ImplemCamara.Droid
{
    class SqlCliente : DataBase
    {
        //donde voy a guardar el archivo /crear archivo
        public SQLiteAsyncConnection GetConnection()
        {
            var documenrtPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documenrtPath, "uisarel.db");
            return new SQLiteAsyncConnection(path);
        }
    }
}