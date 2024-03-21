using System.ComponentModel.DataAnnotations;

namespace ems.Common.Entities;

public record Audit
{
    public int? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }

    [Required]
    public int Status { get; set; } = 0;
    #region CONSTRUCTORS AND METHODS   
    public Audit(int createdBy = 0)
    {
        CreatedBy = createdBy;
        CreatedDate = DateTime.Now;        
    }    
    #endregion
}
