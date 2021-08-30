using System;
using System.ComponentModel.DataAnnotations;

namespace FileService.DTOs
{
    public class CreateFileDTO
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}