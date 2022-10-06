using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Data.Entities
{
    [Table("storage_location")]
    public class Storage_location
    {
        [Key]
        public string? location_id { get; set; }
        public string? location_name { get; set; }
    }
}
