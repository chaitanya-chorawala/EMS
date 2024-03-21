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
    [ForeignKey(nameof(InventoryId))]
    public virtual MasterDataMapping Inventory { get; set; }
    [ForeignKey(nameof(TypeId))]
    public virtual MasterDataMapping Type { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public virtual MasterDataMapping Category { get; set; }


    [InverseProperty(nameof(EventMedia.Event))]
    public IList<EventMedia>? EventMediaList { get; set; }

    [InverseProperty(nameof(EventDetail.Event))]
    public IList<EventDetail>? EventDetailList { get; set; }

    [InverseProperty(nameof(EventTagMapping.Event))]
    public IList<EventTagMapping>? EventTagMappingList { get; set; }

    [InverseProperty(nameof(EventAgenda.Event))]
    public IList<EventAgenda>? EventAgendaList { get; set; }

    [InverseProperty(nameof(Ticket.Event))]
    public IList<Ticket>? TicketList { get; set; }
    #endregion
}
