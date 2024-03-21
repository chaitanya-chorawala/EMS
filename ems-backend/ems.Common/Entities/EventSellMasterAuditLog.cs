using System.ComponentModel.DataAnnotations;

namespace ems.Common.Entities;

public record EventSellMasterAuditLog : Audit
{
    [Key]
    public int EventSellMasterAuditLogId { get; set; }
    public int? ReferenceId { get; set; }
    public int? EventCostMasterId { get; set; }
    public int? MarkupTypeId { get; set; }
    public decimal? MarkupAmount { get; set; }
    public decimal? SellAmount { get; set; }
}
