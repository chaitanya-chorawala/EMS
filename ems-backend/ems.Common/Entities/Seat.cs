using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Collections.Specialized.BitVector32;

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

    #region Tables Relationship  
    [ForeignKey(nameof(SectionId))]
    public Section Section { get; set; }
    #endregion
}
