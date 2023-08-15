using System.ComponentModel.DataAnnotations;

namespace MobileManiaAPI.Models.MobileManufacturers
{
    public class UpdateManufacturer
    {
        [Required]
        public string? Title { get; set; }
    }
}
