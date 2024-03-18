﻿using Microsoft.AspNetCore.Http;

namespace rayna.Common.model.Rayna
{
    public class UpdateEventDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? EventTypeId { get; set; }
        public string? Name { get; set; }
        public DateTimeOffset? EventDate { get; set; }
        public string? Address { get; set; }
        public string? PhoneNo { get; set; }
        public string? MobileNo { get; set; }
        public string? EmailId { get; set; }
        public string? OtherDetails { get; set; }
        public List<IFormFile>? EventFiles { get; set; }
    }
}
