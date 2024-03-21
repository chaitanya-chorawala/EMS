using System.ComponentModel.DataAnnotations;

namespace ems.Common.Entities;

public record EventOptionTagMapping : Audit
{
    [Key]
    public int EventOptionTagMappingId { get; set; }
    
    [Required]
    public int EventOptionMasterId { get; set; }

    [Required]
    public int TagId { get; set; }
}
