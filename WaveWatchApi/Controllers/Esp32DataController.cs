using Microsoft.AspNetCore.Mvc;
using WaveWatchApi.Interfaces;
using WaveWatchApi.Models;

namespace WaveWatchApi.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class Esp32DataController : ControllerBase
        {
            private readonly IEsp32DataService _service;

            public Esp32DataController(IEsp32DataService service)
            {
                _service = service;
            }

            [HttpGet]
            public async Task<IActionResult> GetAllData()
            {
                var data = await _service.GetAllDataAsync();
                return Ok(data);
            }

            [HttpPost]
            public async Task<IActionResult> AddData([FromBody] ESP32Data newData)
            {
                await _service.AddDataAsync(newData);
                return CreatedAtAction(nameof(GetAllData), new { id = newData.Id }, newData);
            }
        }
}
