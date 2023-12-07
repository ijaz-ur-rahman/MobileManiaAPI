using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileManiaAPI.Entities
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        public string? Name { get; set; }

        [Column("Rating")]
        public int? _Rating { get; set; }
        public int? MobileId { get; set; }

        [ForeignKey("MobileId")]
        public virtual MobileDetail? Mobile { get; set; }
    }
}
