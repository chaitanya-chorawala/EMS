using System.ComponentModel.DataAnnotations.Schema;

namespace rayna.Common.Entities;

public class Event : Audit
{
    public int Id { get; set; }        
    public string? Name { get; set; }
    public string? SubTitle { get; set; }
    public int SupplierId { get; set; }
    public int CountryId { get; set; }
    public int StateId { get; set; }
    public int CityId { get; set; }
    public int InventoryId { get; set; }
    public int TypeId { get; set; }
    public int CategoryId { get; set; }
    public int CurrencyId { get; set; }
    public DateTime FromDateTime { get; set; }
    public DateTime ToDateTime { get; set; }
    public string? Description { get; set; }
    public int Status { get; set; }
    
    
    #region Tables Relationship
    //[ForeignKey(nameof(UserId))]
    //public Registration? Registration { get; set; }  
    //[InverseProperty(nameof(EventFiles.Rayna))]
    //public IList<EventFiles>? EventFileList { get; set; }
    //[InverseProperty(nameof(MailMaster.Rayna))]
    //public IList<MailMaster>? MailMasters { get; set; }

    #endregion
}
