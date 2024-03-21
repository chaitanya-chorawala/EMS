using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ems.Common.Entities;

public record CostMasterAuditLog : Audit
{
    [Key]
    public int CostMasterAuditLogId { get; set; }

    [Required]
    public int ReferenceId { get; set; }

    public int? TicketCategoryPaxTypeMappingId { get; set; }

    public decimal? Cost { get; set; } = 0;
    public decimal? MinimumSell { get; set; } = 0;
    public decimal? RackRate { get; set; } = 0;

    [MaxLength(500)]
    public string? IPAddress { get; set; }

    #region Tables Relationship  
    [ForeignKey(nameof(TicketCategoryPaxTypeMappingId))]
    public TicketCategoryPaxTypeMapping? TicketCategoryPaxTypeMapping { get; set; }
    #endregion
}
