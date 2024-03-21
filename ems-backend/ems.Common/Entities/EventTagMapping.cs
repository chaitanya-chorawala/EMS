using System.ComponentModel.DataAnnotations;

namespace ems.Common.Entities;

public record EventTagMapping : Audit
{
    [Key]
    public int EventTagMappingId { get; set; }

    [Required]
    public int EventId { get; set; }

    [Required]
    public int TagId { get; set; }
}
