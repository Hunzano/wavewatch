using System.Collections.Generic;
using WaveWatchApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WaveWatchApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ESP32Data> Esp32Data { get; set; }
        public DbSet<FormDataModel> FormDataModels { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
