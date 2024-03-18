namespace rayna.Common.ExceptionHandler;

public class NotFoundException : Exception
{
    public NotFoundException(string? message) : base(message)
    {}
}
