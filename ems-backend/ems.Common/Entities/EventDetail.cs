using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ems.Common.Entities;

public record EventDetail : Audit
{
    [Key]
    public int EventDetailId { get; set; }

    [Required]
    public int EventId { get; set; }

    [Required]
    public int EventAccessId { get; set; }

    [Required]
    public int VenueId { get; set; }

    [MaxLength(516)]
    public string? DefaultImageUrl { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public int? TimezoneId { get; set; }

    #region Tables Relationship        
    [ForeignKey(nameof(EventId))]
    public Event Event { get; set; }

    [ForeignKey(nameof(VenueId))]
    public Venue Venue { get; set; }

    [ForeignKey(nameof(EventAccessId))]
    public virtual MasterDataMapping EventAccess { get; set; }
    #endregion
}
