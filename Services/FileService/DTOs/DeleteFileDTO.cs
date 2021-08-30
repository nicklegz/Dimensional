using System;
using System.ComponentModel.DataAnnotations;

namespace FileService.DTOs
{
    public class DeleteFileDTO
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}