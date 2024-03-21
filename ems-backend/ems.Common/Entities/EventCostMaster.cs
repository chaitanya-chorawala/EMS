using System.ComponentModel.DataAnnotations;

namespace ems.Common.Entities;

public record EventCostMaster
{
    [Key]
    public int EventCostMasterId { get; set; }

    public int? TicketCategoryPaxTypeMappingId { get; set; }

    public decimal Cost { get; set; } = 0;
    public decimal MinimumSell { get; set; } = 0;
    public decimal RackRate { get; set; } = 0;
}
