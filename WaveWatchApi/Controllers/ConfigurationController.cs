using Microsoft.AspNetCore.Mvc;
using WaveWatchApi.Interfaces;
using WaveWatchApi.Models;

[ApiController]
[Route("[controller]")]
public class ConfigurationController : ControllerBase
{
    private readonly IFormDataService _formDataService;

    public ConfigurationController(IFormDataService formDataService)
    {
        _formDataService = formDataService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] FormDataModel formData)
    {
        if (ModelState.IsValid)
        {
            await _formDataService.UpdateFormData(formData);
            return Ok();
        }
        return BadRequest(ModelState);
    }
}
