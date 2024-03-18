namespace rayna.Common.Entities
{
    public class FormatConfiguration
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public bool IsActive { get; set; }
    }
}
