using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ems.Common.Entities;

public record Event : Audit
{
    [Key]
    public int EventId { get; set; }        
    [MaxLength(1024)]
    public string? Name { get; set; }

    [MaxLength(1024)]
    public string? SubTitle { get; set; }

    [Required]
    public int SupplierId { get; set; }
    
    [Required]
    public int CountryId { get; set; }
    
    [Required]
    public int StateId { get; set; }
    
    [Required]
    public int CityId { get; set; }
    
    [Required]
    public int InventoryId { get; set; }
    
    [Required]
    public int TypeId { get; set; }
    
    [Required]
    public int CategoryId { get; set; }
    
    [Required]
    public int CurrencyId { get; set; }
    
    [Required]
    public DateTime FromDateTime { get; set; }
    
    [Required]
    public DateTime ToDateTime { get; set; }
    
    [MaxLength(1024)]
    public string? Description { get; set; }        

    #region Tables Relationship    
    [InverseProperty(nameof(EventMedia.Event))]
    public IList<EventMedia>? EventFileList { get; set; }

    #endregion
}
