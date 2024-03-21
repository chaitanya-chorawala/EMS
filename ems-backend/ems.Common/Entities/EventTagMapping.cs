using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ems.Common.Entities;

public record EventTagMapping : Audit
{
    [Key]
    public int EventTagMappingId { get; set; }

    [Required]
    public int EventId { get; set; }

    [Required]
    public int TagId { get; set; }

    #region Tables Relationship  
    [ForeignKey(nameof(EventId))]
    public Event Event { get; set; }

    [ForeignKey(nameof(TagId))]
    public Tags Tag { get; set; }
    #endregion
}
