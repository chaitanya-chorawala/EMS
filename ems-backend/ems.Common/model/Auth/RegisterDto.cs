﻿namespace ems.Common.model.Auth
{
    public record RegisterDto
    {
        public string? DisplayName { get; set; }
        public string? Village { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public DateOnly? DOB { get; set; }
        public string? UserName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNo { get; set; }
    }
}
