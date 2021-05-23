using Foundation;
using S7ImplemCamara.iOS;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(SqlCliente))]

namespace S7ImplemCamara.iOS
{
    class SqlCliente : DataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentPath, "uisraeldb");
            return new SQLiteAsyncConnection(path);
        }

        private object SQLiteAsyncConnection(string path)
        {
            throw new NotImplementedException();
        }
    }
}