using System.ComponentModel.DataAnnotations;

namespace MobileManiaAPI.Models.MobileManufacturersViewModels
{
    public class AddManufacturer
    {
        [Required]
        public int ManufacturerId { get; set; }
        public string? ManufacturerName { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedDate { get; set; }
    }
}
