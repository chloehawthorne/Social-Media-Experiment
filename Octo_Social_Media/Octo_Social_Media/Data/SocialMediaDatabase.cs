using Octo_Social_Media.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Octo_Social_Media.Data
{
    public class SocialMediaDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public SocialMediaDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if(!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(SocialMediaItem).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(SocialMediaItem)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }
        public Task<List<SocialMediaItem>> GetInfoAsync(SocialMediaItem socialMediaItem)
        {
            return Database.Table<SocialMediaItem>().ToListAsync();
        }

    
        public Task<SocialMediaItem> GetUserAsync (string user)
        {
            return Database.Table<SocialMediaItem>().Where(i => i.Username == user).FirstOrDefaultAsync();
        }

        /*public Task<int> SaveItemAsync(TodoItem item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }*/

        /*public Task<int> DeleteItemAsync(TodoItem item)
        {
            return Database.DeleteAsync(item);
        }
        */
    }
}
