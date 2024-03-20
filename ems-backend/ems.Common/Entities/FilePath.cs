namespace ems.Common.Entities
{
    public class FilePath : Audit
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public string Path { get; set; } = null!;
    }
}
