namespace ems.Common.Entities
{
    public class ServiceConfiguration
    {
        public int Id { get; set; }
        public string MailId { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Host { get; set; } = null!;
        public string Port { get; set; } = null!;
    }
}
