using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ems.Common.Entities;

public record VenueEventTimeSlotMapping : Audit
{
    [Key]
    public int VenueEventTimeSlotMappingId { get; set; }
    
    [Required]
    public int EventOptionTimeSlotId { get; set; }
    
    [Required]
    public int VenueId { get; set; }

    #region Tables Relationship  
    [ForeignKey(nameof(EventOptionTimeSlotId))]
    public EventOptionTimeSlot EventOptionTimeSlot { get; set; }

    [ForeignKey(nameof(VenueId))]
    public Venue Venue { get; set; }
    #endregion
}
