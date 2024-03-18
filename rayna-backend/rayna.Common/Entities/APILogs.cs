using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rayna.Common.Entities;

[Table("APILogs", Schema = "Logging")]
public class APILogs
{
    [Key]
    public long Id { get; set; }
    public string Method { get; set; }    
    public string Host { get; set; }
    public string Path { get; set; }
    public int StatusCode { get; set; }
    public DateTimeOffset RequestAt { get; set; }    
    public DateTimeOffset ResponseAt { get; set; }
    public string? QueryString { get; set; }
    public string? RequestBody { get; set; }    
    public string? ResponseBody { get; set; }    
    public string? Exception { get; set; }
}
