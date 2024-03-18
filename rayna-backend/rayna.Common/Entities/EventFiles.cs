namespace rayna.Common.Entities;

public class EventFiles : Audit
{
    public int Id { get; set; }
    public int? EventId { get; set; }
    public string? FileType { get; set; }
    public string? FilePath { get; set; }
    public string? FileName { get; set; }

    public virtual Event? Rayna { get; set; }
}
    