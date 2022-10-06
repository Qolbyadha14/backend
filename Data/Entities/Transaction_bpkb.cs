using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Data.Entities
{
    [Table("tr_bpkb")]

    public class Transaction_bpkb
    {

            [Key]
            public string? agreement_number { get; set; }

            [Required(ErrorMessage = "bpkb_no is required")]
            public string? bpkb_no { get; set; }

            [Required(ErrorMessage = "branch_id Number is required")]
            public string? branch_id { get; set; }

            [Required(ErrorMessage = "bpkb_date is required")]
            public DateTime bpkb_date { get; set; }
            
            [Required(ErrorMessage = "faktur_no is required")]
            public string? faktur_no { get; set; }
            
            [Required(ErrorMessage = "faktur_date is required")]
            public DateTime faktur_date { get; set; }
            
            [Required(ErrorMessage = "location_id is required")]

            public string? location_id{ get; set; } 

            [Required(ErrorMessage = "police_no is required")]
            public string? police_no { get; set; } 

            [Required(ErrorMessage = "location_id is required")]
            public DateTime bpkb_date_in { get; set; }

        
    }
}
