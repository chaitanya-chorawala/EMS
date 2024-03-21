using System.ComponentModel.DataAnnotations;

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
}
