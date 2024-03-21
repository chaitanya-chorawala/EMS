using System.ComponentModel.DataAnnotations;

namespace ems.Common.Entities;

public record EventOptionMaster : Audit
{
    [Key]
    public int EventOptionMasterId { get; set; }

    [Required]
    public int EventId { get; set; }

    [Required, MaxLength(1024)]
    public string OptionName { get; set; } = null!;
    
    [MaxLength(1024)]
    public string? Description { get; set; }

    [MaxLength(256)]
    public string? Track { get; set; }
    public int? Duration { get; set; }    
    
    [Required]
    public DateTime FromDateTime { get; set; }
    
    [Required]
    public DateTime ToDateTime { get; set; }
    
    [Required]
    public int SortOrder { get; set; }
    public int? CutOff { get; set; }
    public bool? FreeSell { get; set; }

    [MaxLength(100)]
    public string? MinPax { get; set; }
    
    [MaxLength(100)]
    public string? MaxPax { get; set; }

    public bool? DisableChild { get; set; }
    public bool? DisableInfant { get; set; }
    public bool? InstantConfirmation { get; set; }
    public bool? Requiredhrs { get; set; }
    public bool? IsOnlineCheckIn { get; set; }
    public bool? IsWaiverFrom { get; set; }
    public int? Minquantity { get; set; }
    public int? MultiPax { get; set; }    
    public string? Inclusion { get; set; }
    public string? Exclusion { get; set; }
}
