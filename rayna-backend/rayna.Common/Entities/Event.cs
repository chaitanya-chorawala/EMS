﻿using System.ComponentModel.DataAnnotations.Schema;

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
    public int Status { get; set; } = 0;


    #region Tables Relationship    
    [InverseProperty(nameof(EventFiles.Event))]
    public IList<EventFiles>? EventFileList { get; set; }    

    #endregion
}
