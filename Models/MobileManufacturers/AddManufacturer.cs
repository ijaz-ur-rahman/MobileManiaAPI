namespace MobileManiaAPI.Models.MobileManufacturers
{
    using System.ComponentModel.DataAnnotations;
    public class AddManufacturer
    {
        [Required]
        public int ManufacturerId { get; set; }
        public string? ManufacturerName { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedDate { get; set; }
    }
}
