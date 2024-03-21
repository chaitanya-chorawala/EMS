using System.ComponentModel.DataAnnotations;

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
}
