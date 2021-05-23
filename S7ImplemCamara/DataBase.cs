using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace S7ImplemCamara
{
    public interface  DataBase
    {
        //meétodo de conexión
        SQLiteAsyncConnection GetConnection();

    }
}
