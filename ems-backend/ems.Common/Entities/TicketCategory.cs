using System.ComponentModel.DataAnnotations;

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
}
