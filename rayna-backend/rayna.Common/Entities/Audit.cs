namespace rayna.Common.Entities;

public class Audit
{
    public string? CreatedBy { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public string? DeletedBy { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public bool IsActive { get; set; }

    #region CONSTRUCTORS AND METHODS   
    public Audit(string createdBy = null)
    {
        CreatedBy = createdBy;
        CreatedAt = DateTimeOffset.UtcNow;
        IsActive = true;
    }    
    #endregion
}
