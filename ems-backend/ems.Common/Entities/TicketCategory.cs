using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ems.Common.Entities;

public record TicketCategory : Audit
{
    [Key]
    public int TicketCategoryId { get; set; }

    [Required]
    public int EventOptionTimeSlotId { get; set; }

    [Required]
    public int CurrencyId { get; set; }
    
    [Required]
    public int CancellationPolicyId { get; set; }
    public bool? IsRefundable { get; set; }

    [Required]
    public int PaymentMethodId { get; set; }

    [MaxLength(512)]
    public string? Name { get; set; }

    [Required]
    public int Quantity { get; set; }

    [MaxLength(256)]
    public string? SeatmapDataColor { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? MinQuantity { get; set; }
    public int? MaxQuantity { get; set; }
    public int? VisibilityTypeId { get; set; }
    public int? IsFeatured { get; set; }
    public decimal? IsPercentageOff { get; set; }
    public decimal? IsAmountOff { get; set; }
    public decimal? QuantitySold { get; set; }
    public int? IsPdfTicket { get; set; }

    #region Tables Relationship  
    [ForeignKey(nameof(EventOptionTimeSlotId))]
    public EventOptionTimeSlot EventOptionTimeSlot { get; set; }

    [ForeignKey(nameof(CancellationPolicyId))]
    public CancellationPolicy CancellationPolicy { get; set; }

    [ForeignKey(nameof(PaymentMethodId))]
    public virtual MasterDataMapping PaymentMethod { get; set; }

    [InverseProperty(nameof(TicketCategoryPaxTypeMapping.TicketCategory))]
    public IList<TicketCategoryPaxTypeMapping>? TicketCategoryPaxTypeMappingList { get; set; }

    [InverseProperty(nameof(Section.TicketCategory))]
    public IList<Section>? SectionList { get; set; }

    [InverseProperty(nameof(Ticket.TicketCategory))]
    public IList<Ticket>? TicketList { get; set; }
    #endregion
}
