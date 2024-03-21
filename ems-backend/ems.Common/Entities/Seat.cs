using System.ComponentModel.DataAnnotations;

namespace ems.Common.Entities;

public record Seat : Audit
{
    [Key]
    public int SeatId { get; set; }

    [Required]
    public int SectionId { get; set; }

    [MaxLength(512)]
    public string? Title { get; set; }

    [MaxLength(1024)]
    public string? SeatMapData { get; set; }

    [Required]
    public int AvailabilityId { get; set; }
}
