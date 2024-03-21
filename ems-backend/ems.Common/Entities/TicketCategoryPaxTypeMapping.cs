using System.ComponentModel.DataAnnotations;

namespace ems.Common.Entities;

public record TicketCategoryPaxTypeMapping : Audit
{
    [Key]
    public int TicketCategoryPaxTypeMappingId { get; set; }

    [Required]
    public int TicketCategoryId { get; set; }

    [Required]
    public int PaxTypeId { get; set; }
}
