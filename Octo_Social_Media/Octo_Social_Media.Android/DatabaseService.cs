using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Octo_Social_Media.Data;
using Octo_Social_Media.Droid;
using SQLitePCL.lib;
using Xamarin.Forms;
using SQLite;
using SQLite.Net.Platform.XamarinAndroid;

[assembly: Dependency(typeof(DatabaseService))]
namespace Octo_Social_Media.Droid
{
    public class DatabaseService : IDBInterface
    {
        public DatabaseService()
        {
        }

        public SQLite.Net.SQLiteConnection CreateConnection()
        {
            var sqliteFilename = "Octo.db";
            string documentsDirectoryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsDirectoryPath, sqliteFilename);

            // This is where we copy in our pre-created database
            if (!File.Exists(path))
            {
                using (var binaryReader = new BinaryReader(Android.App.Application.Context.Assets.Open(sqliteFilename)))
                {
                    using (var binaryWriter = new BinaryWriter(new FileStream(path, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;
                        while ((length = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            binaryWriter.Write(buffer, 0, length);
                        }
                    }
                }
            }
            var plat = new SQLitePlatformAndroid();
            var conn = new SQLite.Net.SQLiteConnection(plat, path);

            return conn;
        }

        void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);
            while (bytesRead >= 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        }
    }
}