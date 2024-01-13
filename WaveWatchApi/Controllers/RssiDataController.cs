using Microsoft.AspNetCore.Mvc;
using WaveWatchApi.Interfaces;
using WaveWatchApi.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace WaveWatchApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RssiDataController : ControllerBase
    {
        private readonly IEsp32DataService _service;
        private const int DelayInSeconds = 20;
        private const int MaxRecordCount = 20;

        public RssiDataController(IEsp32DataService service)
        {
            _service = service;
        }

        [HttpGet("GetRssiExtremes")]
        public async Task<IActionResult> GetRssiExtremes()
        {
            var latestData = await _service.GetLatestDataAsync();
            if (latestData == null)
            {
                return NotFound("No data founds.");
            }

            var initialId = latestData.Id;

            // Esperar 120 segundos
            await Task.Delay(TimeSpan.FromSeconds(DelayInSeconds));

            var data = await _service.GetDataFromIdAsync(initialId, MaxRecordCount);
            if (data == null || data.Count == 0)
            {
                return NotFound("no data found in setted period of time.");
            }

            var minRssi = data.Min(x => x.Rssi);
            var maxRssi = data.Max(x => x.Rssi);
            var firstRecordTime = data.FirstOrDefault()?.Timestamp;
            var lastRecord = data.LastOrDefault();
            var lastRecordTime = lastRecord?.Timestamp;
            var totalRecords = data.Count;
            var lastRecordMac = lastRecord?.Esp32MacAddress;
            var lastRecordSsid = lastRecord?.WifiSsid;

            return Ok(new
            {
                MinRssi = minRssi,
                MaxRssi = maxRssi,
                FirstRecordTime = firstRecordTime,
                LastRecordTime = lastRecordTime,
                TotalRecords = totalRecords,
                LastRecordMac = lastRecordMac,
                LastRecordSsid = lastRecordSsid
            });
        }
    }
}
