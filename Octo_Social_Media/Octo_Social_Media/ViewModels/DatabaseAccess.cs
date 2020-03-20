using System;
using SQLite.Net;
using System.Collections.Generic;
using Xamarin.Forms;
using Octo_Social_Media.Data;
using Octo_Social_Media.Models;

namespace Octo_Social_Media.ViewModels
{
    public class DatabaseManager
    {
        SQLiteConnection dbConnection;
        public DatabaseManager()
        {
            dbConnection = DependencyService.Get<IDBInterface>().CreateConnection();
        }

        public List<SocialMediaItem> GetAllEmployees()
        {
            return dbConnection.Query<SocialMediaItem>("Select * From [Users]");
        }

        public int SaveEmployee(SocialMediaItem user)

        {
            return dbConnection.Insert(user);
        }
    }
}
