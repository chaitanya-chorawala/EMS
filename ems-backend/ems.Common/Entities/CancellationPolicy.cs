﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ems.Common.Entities;

public record CancellationPolicy : Audit
{
    [Key]
    public int CancellationPolicyId { get; set; }

    [MaxLength(1024)]
    public string? CancellationName { get; set; }

    [MaxLength(1024)]
    public string? Description { get; set; }

    public bool IsRefundable { get; set; }
    
    [MaxLength(4000)]
    public string? RefundPolicy { get; set; }

    public int? FromHour { get; set; }
    public int? ToHour { get; set; }

    [Required]
    public decimal CancellationValue { get; set; }
    
    [Required]        
    public int CancellationValueTypeId { get; set; }

    public int? DisplaySortOrder { get; set; }

    #region Tables Relationship            

    [ForeignKey(nameof(CancellationValueTypeId))]
    public virtual MasterDataMapping CancellationValueType { get; set; }

    [InverseProperty(nameof(TicketCategory.CancellationPolicy))]
    public IList<TicketCategory>? TicketCategoryList { get; set; }
    #endregion
}
