using System;
using System.ComponentModel.DataAnnotations;

namespace FileService.DTOs
{
    public class ReadFileDTO
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}