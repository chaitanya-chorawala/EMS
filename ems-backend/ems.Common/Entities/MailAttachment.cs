using System.ComponentModel.DataAnnotations.Schema;

namespace ems.Common.Entities
{
    public class MailAttachment
    {
        public int Id { get; set; }
        public int MailId { get; set; }
        public string AttachmentPath { get; set; } = null!;

        #region Table Relationship
        [ForeignKey(nameof(MailId))]
        public MailMaster? MailMaster { get; set; }
        #endregion
    }
}
