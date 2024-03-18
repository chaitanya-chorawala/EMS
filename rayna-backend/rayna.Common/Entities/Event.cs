using System.ComponentModel.DataAnnotations.Schema;

namespace rayna.Common.Entities;

public class Event : Audit
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public int? EventTypeId { get; set; }
    public string EventNo { get; set; }
    public string? Name { get; set; }
    public DateTimeOffset EventDate { get; set; }
    public string? Address { get; set; }
    public string? PhoneNo { get; set; }
    public string? MobileNo { get; set; }
    public string? EmailId { get; set; }
    public string? OtherDetails { get; set; }
    public DateTimeOffset? CompletionDate { get; set; }
    public bool IsCompleted { get; set; }
    
    #region Tables Relationship
    [ForeignKey(nameof(UserId))]
    public Registration? Registration { get; set; }  
    [InverseProperty(nameof(EventFiles.Rayna))]
    public IList<EventFiles>? EventFileList { get; set; }
    [InverseProperty(nameof(MailMaster.Rayna))]
    public IList<MailMaster>? MailMasters { get; set; }

    #endregion
}
