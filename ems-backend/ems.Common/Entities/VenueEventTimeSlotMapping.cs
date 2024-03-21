using System.ComponentModel.DataAnnotations;

namespace ems.Common.Entities;

public record VenueEventTimeSlotMapping : Audit
{
    [Key]
    public int VenueEventTimeSlotMappingId { get; set; }
    
    [Required]
    public int EventOptionTimeSlotId { get; set; }
    
    [Required]
    public int VenueId { get; set; }

}
