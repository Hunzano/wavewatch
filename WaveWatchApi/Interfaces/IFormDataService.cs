using WaveWatchApi.Models;
namespace WaveWatchApi.Interfaces

{
    public interface IFormDataService
    {
        Task UpdateFormData(FormDataModel formData);
    }

}
