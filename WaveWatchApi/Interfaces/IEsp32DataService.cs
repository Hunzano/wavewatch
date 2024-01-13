using WaveWatchApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WaveWatchApi.Interfaces
{
    public interface IEsp32DataService
    {
        Task<List<ESP32Data>> GetAllDataAsync();
        Task AddDataAsync(ESP32Data data);
        Task<ESP32Data> GetLatestDataAsync();
        Task<List<ESP32Data>> GetDataFromIdAsync(int startId, int count);
    }
}
