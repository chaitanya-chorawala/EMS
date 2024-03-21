using System.ComponentModel.DataAnnotations;

namespace ems.Common.Entities;

public record Section : Audit
{
    [Key]
    public int SectionId { get; set; }

    [Required]
    public int TicketCategoryId { get; set; }

    [MaxLength(256)]
    public string? Floor { get; set; }

    [Required]
    public int Capacity { get; set; }

    [MaxLength(512)]
    public string? Address { get; set; }

    [Required]
    public int SeatingTypeId { get; set; }

    [MaxLength]
    public string? SeatMapData { get; set; }
}
