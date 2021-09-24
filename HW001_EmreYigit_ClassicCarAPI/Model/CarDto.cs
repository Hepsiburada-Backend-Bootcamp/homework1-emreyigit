using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HW001_EmreYigit_ClassicCarAPI.Model
{
    public class CarDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This area is required"),MaxLength(20)]
        public string Brand { get; set; }

        [Required(ErrorMessage = "This area is required")]
        public string Model { get; set; }

        [Required(ErrorMessage = "This area is required"), MaxLength(4)]
        public int ModelYear { get; set; }

        [Required]
        [RegularExpression("[1-3]{2}[a-z]{3}[1-3]{2}[A-Z]{3}[9]{2}"),StringLength(12)]
        public string SasiNo { get; set; }

    }

    public class CarSasiNoUpdateRequest
    {
        [Required]
        [RegularExpression("[1-3]{2}[a-z]{3}[1-3]{2}[A-Z]{3}[9]{2}"), StringLength(12)]
        public string SasiNo { get; set; }
    }
}
