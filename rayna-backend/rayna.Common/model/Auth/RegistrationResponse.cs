using System.Linq.Expressions;

namespace rayna.Common.model.Auth
{
    public class RegistrationResponse
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Village { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public DateTime? DOB { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }

        public static Expression<Func<Entities.Registration, RegistrationResponse>> ToDTO()
        {
            Expression<Func<Entities.Registration, RegistrationResponse>> exp =
                x => new RegistrationResponse
                {
                    Id = x.Id,
                    
                    Village = x.Village,
                    City = x.City,
                    State = x.State,
                    DOB = x.DOB,
                    UserName = x.UserName,
                    Password = x.Password,
                    Address = x.Address,
                    Email = x.Email,
                    PhoneNo = x.PhoneNo,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName
                };
            return exp;
        }
    }
}
