using WaveWatchApi.Data;
using WaveWatchApi.Interfaces;
using WaveWatchApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaveWatchApi.Services
{
    public class Esp32DataService : IEsp32DataService
    {
        private readonly AppDbContext _context;

        public Esp32DataService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ESP32Data>> GetAllDataAsync()
        {
            return await _context.Esp32Data.ToListAsync();
        }

        public async Task AddDataAsync(ESP32Data data)
        {
            var formData = await _context.FormDataModels.FindAsync(1);

            if (formData != null && int.TryParse(formData.MinRssi, out int minRssi))
            {
                data.DeviceStatus = data.Rssi < minRssi ? "Activo" : "Inactivo";
            }
            else
            {

                data.DeviceStatus = "Estado desconocido";
            }
            _context.Esp32Data.Add(data);
            await _context.SaveChangesAsync();
        }

        public async Task<ESP32Data> GetLatestDataAsync()
        {
            return await _context.Esp32Data.OrderByDescending(d => d.Id).FirstOrDefaultAsync();
        }

        public async Task<List<ESP32Data>> GetDataFromIdAsync(int startId, int count)
        {
            return await _context.Esp32Data
                                 .Where(d => d.Id > startId)
                                 .OrderBy(d => d.Id)
                                 .Take(count)
                                 .ToListAsync();
        }
    }
}
