namespace ems.Common.Entities;

public record FilePath : Audit
{
    public int Id { get; set; }
    public string Type { get; set; } = null!;
    public string Path { get; set; } = null!;
}
