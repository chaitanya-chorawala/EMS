using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ems.Common.Entities;

public record TicketCategoryPaxTypeMapping : Audit
{
    [Key]
    public int TicketCategoryPaxTypeMappingId { get; set; }

    [Required]
    public int TicketCategoryId { get; set; }

    [Required]
    public int PaxTypeId { get; set; }

    #region Tables Relationship  
    [ForeignKey(nameof(TicketCategoryId))]
    public TicketCategory TicketCategory { get; set; }
    
    [ForeignKey(nameof(PaxTypeId))]
    public virtual MasterDataMapping PaxType { get; set; }

    [InverseProperty(nameof(CostMasterAuditLog.TicketCategoryPaxTypeMapping))]
    public IList<CostMasterAuditLog>? CostMasterAuditLogList { get; set; }
    #endregion
}
