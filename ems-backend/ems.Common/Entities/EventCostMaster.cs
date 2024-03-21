using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ems.Common.Entities;

public record EventCostMaster
{
    [Key]
    public int EventCostMasterId { get; set; }

    public int? TicketCategoryPaxTypeMappingId { get; set; }

    public decimal Cost { get; set; } = 0;
    public decimal MinimumSell { get; set; } = 0;
    public decimal RackRate { get; set; } = 0;

    #region Tables Relationship  
    [ForeignKey(nameof(TicketCategoryPaxTypeMappingId))]
    public TicketCategoryPaxTypeMapping? TicketCategoryPaxTypeMapping { get; set; }

    [InverseProperty(nameof(EventTarrifWiseSellMaster.EventCostMaster))]
    public IList<EventTarrifWiseSellMaster>? EventTarrifWiseSellMasterList { get; set; }

    [InverseProperty(nameof(EventAgentWiseSellMaster.EventCostMaster))]
    public IList<EventAgentWiseSellMaster>? EventAgentWiseSellMasterList { get; set; }
    #endregion
}
