﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ems.Common.Entities;

public record EventDescriptionSection : Audit
{
    [Key]
    public int EventDescriptionSectionId { get; set; }
    public int EventId { get; set; }

    [Required, MaxLength(526)]
    public string Name { get; set; } = null!;

    [Required, MaxLength(4000)]
    public string Description { get; set; } = null!;

    [Required]
    public int SortOrder { get; set; }

    #region Tables Relationship        
    [ForeignKey(nameof(EventId))]
    public Event Event { get; set; }
    #endregion
}
