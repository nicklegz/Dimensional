using System;
using System.ComponentModel.DataAnnotations;

namespace UserService.DTOs
{
    public class UpdateUserDTO
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        public string OrganizationName { get; set; }

    }
}
