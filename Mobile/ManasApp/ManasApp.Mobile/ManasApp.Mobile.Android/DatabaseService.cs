using ManasApp.Mobile.Common.Interfaces;
using ManasApp.Mobile.Droid;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]
namespace ManasApp.Mobile.Droid
{
    public class DatabaseService : IDBInterface
    {
        public DatabaseService()
        {
        }

        public SQLiteAsyncConnection CreateConnection()
        {
            var sqliteFilename = "manasapp.db";
            string documentsDirectoryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsDirectoryPath, sqliteFilename);

            // This is where we copy in our pre-created database
            if (!File.Exists(path))
            {
                using (var stream = Android.App.Application.Context.Assets.Open(sqliteFilename))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);

                        File.WriteAllBytes(path, memoryStream.ToArray());
                    }
                }
            }

            return new SQLiteAsyncConnection(path);
        }
    }
}