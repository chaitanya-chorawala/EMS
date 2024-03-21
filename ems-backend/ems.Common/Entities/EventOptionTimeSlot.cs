using System.ComponentModel.DataAnnotations;

namespace ems.Common.Entities;

public record EventOptionTimeSlot : Audit
{
    [Key]
    public int EventOptionTimeSlotId { get; set; }
    [Required]
    public int EventOptionMasterId { get; set; }
    [MaxLength(1024)]
    public string? Name { get; set; }
    [MaxLength(1024)]
    public string? Description { get; set; }
    [Required]
    public DateTime FromDateTime { get; set; }
    [Required]
    public DateTime ToDateTime { get; set; }
    public int? Duration { get; set; }
    public int? SortOrder { get; set; }
}
