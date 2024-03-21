using System.ComponentModel.DataAnnotations;

namespace ems.Common.Entities;

public record CostMasterAuditLog : Audit
{
    [Key]
    public int CostMasterAuditLogId { get; set; }

    [Required]
    public int ReferenceId { get; set; }

    public int? TicketCategoryPaxTypeMappingId { get; set; }

    public decimal? Cost { get; set; }
    public decimal? MinimumSell { get; set; }
    public decimal? RackRate { get; set; }

    [MaxLength(500)]
    public string? IPAddress { get; set; }
}
