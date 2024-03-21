using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ems.Common.Entities;

public record Tags : Audit
{
    [Key]
    public int TagId { get; set; }

    [MaxLength(512)]
    public string? TagName { get; set; }

    [Required]
    public int TagTypeId { get; set; }

    [MaxLength(512)]
    public string? TagKeyword { get; set; }

    #region Tables Relationship  

    [InverseProperty(nameof(EventTagMapping.Tag))]
    public IList<EventTagMapping>? EventTagMappingList { get; set; }

    [InverseProperty(nameof(EventOptionTagMapping.Tag))]
    public IList<EventOptionTagMapping>? EventOptionTagMappingList { get; set; }
    #endregion
}
