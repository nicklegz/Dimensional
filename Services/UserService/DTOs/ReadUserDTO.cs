﻿using System;
using System.Text.Json.Serialization;

namespace UserService.DTOs
{
    public class ReadUserDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OrganizationName { get; set; }
    }
}
