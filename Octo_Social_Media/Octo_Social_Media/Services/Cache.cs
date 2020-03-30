using Akavache;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Octo_Social_Media.Services
{
    //new stoof that makes it work
    public interface ICache
    {
        Task<T> GetObject<T>(string key);
        Task InsertObject<T>(string key, T value);
        Task Delete(string key);
        Task DeleteAll();
        Task DeleteObject<T>(string key);
    }

    public class Cache : ICache
    {
        public Cache()
        {
        }

        #region Get
        public async Task<T> GetObject<T>(string key)
        {
            try
            {
                return await BlobCache.UserAccount.GetObject<T>(key);
            }
            catch (KeyNotFoundException)
            {
                Debug.WriteLine($"Key '{key}' not found in akavache");
                return default(T);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception caught in OutboxService GetReports: {ex.Message}");
                return default(T);
            }
        }
        #endregion

        #region Insert 
        public async Task InsertObject<T>(string key, T value)
        {
            try
            {
                await BlobCache.UserAccount.InsertObject(key, value);
            }
            catch (KeyNotFoundException)
            {
                Debug.WriteLine($"Key '{key}' not found in akavache");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception caught in OutboxService GetReports: {ex.Message}");
            }
        }
        #endregion

        #region Delete
        public async Task Delete(string key)
        {
            try
            {
                await BlobCache.UserAccount.Invalidate(key);
            }
            catch (KeyNotFoundException)
            {
                Debug.WriteLine($"Key '{key}' not found in akavache");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception caught in Cache Delete: {ex.Message}");
            }
        }

        public async Task DeleteObject<T>(string key)
        {
            try
            {
                await BlobCache.UserAccount.InvalidateObject<T>(key);
            }
            catch (KeyNotFoundException)
            {
                Debug.WriteLine($"Key '{key}' not found in akavache");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception caught in Cache DeleteObject: {ex.Message}");
            }
        }

        public async Task DeleteAll()
        {
            try
            {
                await BlobCache.UserAccount.InvalidateAll();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception caught in Cache DeleteAll: {ex.Message}");
            }

        }
    }
    }
#endregion 
