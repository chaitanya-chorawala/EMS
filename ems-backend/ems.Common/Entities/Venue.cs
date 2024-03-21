using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ems.Common.Entities;

public record Venue : Audit
{
    [Key]
    public int VenueId { get; set; }

    [MaxLength(512)]
    public string? Name { get; set; }

    [Required]
    public int Capacity { get; set; }

    [MaxLength(512)]
    public string? Address { get; set; }
    public decimal? Latitude { get; set; }
    public string? Longitude { get; set; }

    [Required]
    public int AgeLimit { get; set; }


    #region Tables Relationship       
    [InverseProperty(nameof(EventDetail.Venue))]
    public IList<EventDetail>? EventDetailList { get; set; }

    [InverseProperty(nameof(VenueEventTimeSlotMapping.Venue))]
    public IList<VenueEventTimeSlotMapping>? VenueEventTimeSlotMappingList { get; set; }
    #endregion
}
