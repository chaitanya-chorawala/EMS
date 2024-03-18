using System.Linq.Expressions;

namespace rayna.Common.model.Rayna
{
    public class EventResponse
    {
        public int Id { get; set; }
        public DropdownResponse? Registration { get; set; }
        public string EventNo { get; set; } = string.Empty;
        public string? Name { get; set; }
        public DateTimeOffset EventDate { get; set; }
        public string? Address { get; set; }
        public string? PhoneNo { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailId { get; set; }
        public string? OtherDetails { get; set; }
        public DateTimeOffset? CompletionDate { get; set; }
        public bool IsCompleted { get; set; }

        public static Expression<Func<rayna.Common.Entities.Event, EventResponse>> ToDTO()
        {
            Expression<Func<rayna.Common.Entities.Event, EventResponse>> exp =
                x => new EventResponse
                {
                    Id = x.Id,
                    
                    Address = x.Address,
                    CompletionDate = x.CompletionDate,
                    
                    EventNo = x.EventNo,
                    EmailId = x.EmailId,
                    MobileNo = x.MobileNo,
                    Name = x.Name,
                    EventDate = x.EventDate,
                    IsCompleted = x.IsCompleted,
                    OtherDetails = x.OtherDetails,
                    PhoneNo = x.PhoneNo,
                    Registration = (x.Registration == null) ? null : new DropdownResponse
                    {
                        Id = x.Registration.Id,
                        Value = string.Concat(x.Registration.FirstName, " ", x.Registration.MiddleName, " ", x.Registration.LastName),
                    },
                   
                };
            return exp;
        }
    }
}
