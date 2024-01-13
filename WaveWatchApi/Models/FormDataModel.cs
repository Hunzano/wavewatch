using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WaveWatchApi.Models
{
    public class FormDataModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? FirstRecordTime { get; set; }
        public string? LastRecordTime { get; set; }
        public string? TotalRecords { get; set; }
        public string? LastRecordMac { get; set; }
        public string? LastRecordSsid { get; set; }
        public string? MinRssi { get; set; }
        public string? MaxRssi { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
