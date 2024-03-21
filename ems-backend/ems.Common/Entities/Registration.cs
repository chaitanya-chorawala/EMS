using System.ComponentModel.DataAnnotations.Schema;

namespace ems.Common.Entities
{
    public record Registration : Audit
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Village { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public DateOnly? DOB { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }

        #region Table Relationships
        
        [InverseProperty(nameof(JwtRefreshToken.User))]
        public JwtRefreshToken? RefreshToken { get; set; }
        #endregion
    }
}
