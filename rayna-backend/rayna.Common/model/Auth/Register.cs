namespace rayna.Common.model.Auth;

public record Register : RegisterDto
{
    public string? Password { get; set; }
}
