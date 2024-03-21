using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ems.Common.Entities;

public record JwtRefreshToken: Audit
{
    [Key]
    public int UserId { get; set; }
    public string Token { get; set; }

    #region Tables Relationship    
    [ForeignKey(nameof(UserId))]
    public Registration User { get; set; }
    #endregion
}
