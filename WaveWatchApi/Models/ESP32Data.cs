using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WaveWatchApi.Models
{
    public class ESP32Data

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // RSSI - Intensidad de la señal WiFi
        public int Rssi { get; set; }

        // Dirección MAC del dispositivo ESP32
        public string? Esp32MacAddress { get; set; }

        // Marca de tiempo de la lectura
        public DateTime Timestamp { get; set; } = DateTime.Now;

        // SSID de la red WiFi
        public string? WifiSsid { get; set; }

        // Estado del dispositivo (opcional, puede ser "activo", "error", etc.)
        public string? DeviceStatus { get; set; }

    }
}
