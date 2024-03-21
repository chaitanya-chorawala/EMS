using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ems.Common.Entities;

public record EventAgentWiseSellMaster : Audit
{
    [Key]
    public int EventAgentWiseSellMasterId { get; set; }
    public int? EventCostMasterId { get; set; }
    public int? AgentId { get; set; }
    public int? MarkupTypeId { get; set; }
    public decimal? MarkupAmount { get; set; }
    public decimal SellAmount { get; set; } = 0;

    #region Tables Relationship  
    [ForeignKey(nameof(EventCostMasterId))]
    public EventCostMaster? EventCostMaster { get; set; }
    #endregion
}
