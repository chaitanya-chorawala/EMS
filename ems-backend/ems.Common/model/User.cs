namespace ems.Common.model;

public record User
{
    public int Id { get; set; }
    public string? State { get; set; }
    public string? FullName { get; set; }
    public string? OfficeName { get; set; }
  //public string? Password { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? PhoneNo { get; set; }    
    public DateTimeOffset? CreatedAt { get; set; }
    public string? Role { get; set; }
}
