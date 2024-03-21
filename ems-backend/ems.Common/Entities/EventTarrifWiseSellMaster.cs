using System.ComponentModel.DataAnnotations;

namespace ems.Common.Entities;

public record EventTarrifWiseSellMaster : Audit
{
    [Key]
    public int EventTarrifWiseSellMasterId { get; set; }
    public int? EventCostMasterId { get; set; }
    public int? TarrifId { get; set; }
    public int? MarkupTypeId { get; set; }
    public decimal? MarkupAmount { get; set; }
    public decimal? SellAmount { get; set; } = 0;
}
