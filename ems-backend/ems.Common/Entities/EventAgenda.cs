using System.ComponentModel.DataAnnotations;

namespace ems.Common.Entities;

public record EventAgenda : Audit
{
    [Key]
    public int EventAgendaId { get; set; }

    [Required]
    public int EventId { get; set; }

    [MaxLength(512)]
    public string? Title { get; set; }

    [MaxLength(512)]
    public string? Track { get; set; }

    [Required]
    public int AgendaTypeId { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    [MaxLength(1024)]
    public string? Summary { get; set; }
    
    [MaxLength(1024)]
    public string? Description { get; set; }
}
