using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using Octo_Social_Media.Data;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Octo_Social_Media.iOS.DatabaseService))]
namespace Octo_Social_Media.iOS
{
    public class DatabaseService : IDBInterface
    {
        public DatabaseService()
        {
        }

        public SQLite.Net.SQLiteConnection CreateConnection()
        {
            var sqliteFilename = "Employee.db";

            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            string path = Path.Combine(libFolder, sqliteFilename);

            // This is where we copy in the pre-created database
            if (!File.Exists(path))
            {
                var existingDb = NSBundle.MainBundle.PathForResource("Employee", "db");
                File.Copy(existingDb, path);
            }
            var iOSPlatform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLite.Net.SQLiteConnection(iOSPlatform, path);

            // Return the database connection 
            return connection;
        }
    } 

    }