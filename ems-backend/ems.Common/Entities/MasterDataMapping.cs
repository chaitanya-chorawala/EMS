using System.ComponentModel.DataAnnotations;

namespace ems.Common.Entities;

public record MasterDataMapping
{
    [Key]
    public int MasterDataMappingId { get; set; }

    [MaxLength(100)]
    public string GroupName { get; set; } = null!;
    
    [MaxLength(100)]
    public string GroupValue { get; set; } = null!;
    public int ParentId { get; set; }
    
    [MaxLength(500)]
    public string? Description { get; set; }
    
    [MaxLength(50)]
    public string? UpdatedBy { get; set; }
    public DateTime UpdatedTime { get; set; }
    public int StatusFlag { get; set; } = 1;

    [MaxLength(256)]
    public string? DisplayName { get; set; }

}
