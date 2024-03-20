namespace ems.Common.Entities;

public class Audit
{
    public int? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }    

    #region CONSTRUCTORS AND METHODS   
    public Audit(int createdBy = 0)
    {
        CreatedBy = createdBy;
        CreatedDate = DateTime.Now;        
    }    
    #endregion
}
