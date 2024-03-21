using System.ComponentModel.DataAnnotations;

namespace ems.Common.Entities;

public record EventAgentWiseSellMaster : Audit
{
    [Key]
    public int EventAgentWiseSellMasterId { get; set; }
    public int? EventCostMasterId { get; set; }
    public int? AgentId { get; set; }
    public int? MarkupTypeId { get; set; }
    public decimal? MarkupAmount { get; set; }
    public decimal? SellAmount { get; set; }
}
