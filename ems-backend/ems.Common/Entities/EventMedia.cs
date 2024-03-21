using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ems.Common.Entities;

public record EventMedia : Audit
{
    [Key]
    public int EventMediaId { get; set; }
    [Required]
    public int EventId { get; set; }

    [Required, MaxLength(526)]
    public string Name { get; set; } = null!;

    [Required]
    public int MediaTypeId { get; set; }

    [MaxLength(516)]
    public string? Url { get; set; }

    [MaxLength(2000)]
    public string? Description { get; set; }
    public int? DisplaySortOrder { get; set; }    

    #region Tables Relationship  
    [ForeignKey(nameof(EventId))]
    public Event Event { get; set; }
    #endregion

}
