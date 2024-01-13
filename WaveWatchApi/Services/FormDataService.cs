using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WaveWatchApi.Data;
using WaveWatchApi.Models;

public interface IFormDataService
{
    Task UpdateFormData(FormDataModel formData);
}

public class FormDataService : IFormDataService
{
    private readonly AppDbContext _context;

    public FormDataService(AppDbContext context)
    {
        _context = context;
    }

    public async Task UpdateFormData(FormDataModel formData)
    {
        // Suponemos que siempre hay un registro y su ID es conocido. 
        // Aquí estoy usando '1' como el ID del registro existente.
        var existingData = await _context.FormDataModels.FindAsync(1);

        if (existingData != null)
        {
            // Actualizar las propiedades del registro existente con los datos proporcionados
            existingData.FirstRecordTime = formData.FirstRecordTime;
            existingData.LastRecordTime = formData.LastRecordTime;
            existingData.TotalRecords = formData.TotalRecords;
            existingData.LastRecordMac = formData.LastRecordMac;
            existingData.LastRecordSsid = formData.LastRecordSsid;
            existingData.MinRssi = formData.MinRssi;
            existingData.MaxRssi = formData.MaxRssi;
            existingData.Email = formData.Email;
            existingData.Phone = formData.Phone;

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

        }
        else
        {
            // Manejar el caso en que no existen datos previos
            // Puede ser lanzando una excepción o cualquier otra lógica necesaria
            throw new InvalidOperationException("No se encontró el registro para actualizar.");
        }
    }
}
