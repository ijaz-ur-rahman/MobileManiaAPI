using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileManiaAPI.Entities;

public class Comment
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public string? Name { get; set; }

    public string? CommentsDetail { get; set; }

    public int? MobileId { get; set; }

    [ForeignKey("MobileId")]
    public virtual MobileDetail? Mobile { get; set; }
}
