using System.ComponentModel.DataAnnotations;

namespace MobileManiaAPI.Models.MobileManufacturersViewModels
{
    public class UpdateManufacturer
    {
        [Required]
        public string? Title { get; set; }
    }
}
