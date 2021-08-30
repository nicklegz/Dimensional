using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileService.DTOs;
using FileService.Models;

namespace FileService.Interfaces
{
    public interface IFileExtensions
    {
        Task<ReadFileDTO> GetFile(Guid id);
        Task<IEnumerable<ReadFileDTO>> GetFiles();
        Task<IEnumerable<ReadFileDTO>> GetFilesByUser(Guid userId);
        Task<ReadFileDTO> CreateFile(File file);
        // Task<DeleteFileDTO> DeleteFile(int id, Guid userId);
    }
}
