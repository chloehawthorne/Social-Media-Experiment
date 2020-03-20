using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net;
using SQLiteConnection = SQLite.Net.SQLiteConnection;

namespace Octo_Social_Media.Data
{
    public interface IDBInterface
    {
        SQLiteConnection CreateConnection();
    }
}
