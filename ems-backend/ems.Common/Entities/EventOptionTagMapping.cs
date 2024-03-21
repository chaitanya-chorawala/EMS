using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ems.Common.Entities;

public record EventOptionTagMapping : Audit
{
    [Key]
    public int EventOptionTagMappingId { get; set; }
    
    [Required]
    public int EventOptionMasterId { get; set; }

    [Required]
    public int TagId { get; set; }

    #region Tables Relationship  
    [ForeignKey(nameof(EventOptionMasterId))]
    public EventOptionMaster EventOptionMaster { get; set; }

    [ForeignKey(nameof(TagId))]
    public Tags Tag { get; set; }
    #endregion
}
