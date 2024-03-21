using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ems.Common.Entities;

public record Ticket : Audit
{
    [Key] 
    public int TicketId { get; set; }
    public int EventId { get; set; }
    public int TicketCategoryId { get; set; }
    public int TicketAdditionalTypeId { get; set; }

    [MaxLength(100)]
    public string RegistrationTimeLimit { get; set; }
    public int? TicketIssueTypeId { get; set; }
    public int? ShowTicketAvailability { get; set; }
    public int? AllowDuplicateAttendees { get; set; }

    #region Tables Relationship  
    [ForeignKey(nameof(EventId))]
    public Event Event { get; set; }

    [ForeignKey(nameof(TicketCategoryId))]
    public TicketCategory TicketCategory { get; set; }
    #endregion
}
