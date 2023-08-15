namespace MobileManiaAPI.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Text.Json.Serialization;
    public class Manufacturers
    {
        //public Manufacturers() {
        //    ManufacturerName = "";

        //}
        [Key]
        public int ManufacturerId { get; set; }
        public string? ManufacturerName { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedDate { get; set; }
        
    }
}
