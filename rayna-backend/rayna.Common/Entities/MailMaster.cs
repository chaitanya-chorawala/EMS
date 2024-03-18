using System.ComponentModel.DataAnnotations.Schema;

namespace rayna.Common.Entities
{
    public class MailMaster
    {
        public int Id { get; set; }
        public int? EventId { get; set; }
        public string FromMail { get; set; } = null!;
        public string ToMail { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string MessageBody { get; set; } = null!;
        public string? CC { get; set; }
        public bool Status { get; set; } = false;

        #region Table Relationship
        [ForeignKey(nameof(EventId))]
        public Event? Rayna { get; set; }

        [InverseProperty(nameof(MailAttachment.MailMaster))]
        public IList<MailAttachment>? Attachments { get; set; } 
        #endregion
    }
}