using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FileService.Models;
using FileService.DTOs;
using FileService.Interfaces;

namespace FileService.Extensions
{
    public class FileExtensions : IFileExtensions
    {
        private readonly FileContext _context;

        public FileExtensions(FileContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReadFileDTO>> GetFiles()
        {
            var files =  await _context.Files.ToListAsync();
            return ConvertListFilesDTO(files);
        }
        
        public async Task<IEnumerable<ReadFileDTO>> GetFilesByUser(Guid userId)
        {
            var files =  await _context.Files.Where(user => user.UserId == userId).ToListAsync();
            return ConvertListFilesDTO(files);
        }
        public async Task<ReadFileDTO> GetFile(Guid fileId)
        {
            var file = await _context.Files.Where(userFile => userFile.Id == fileId).SingleOrDefaultAsync();
            return ConvertFileDTO(file);
        }

        public async Task<ReadFileDTO> CreateFile(File file)
        {
            //need to post file to mongodb database

            file.Id = Guid.NewGuid();
            await _context.Files.AddAsync(file);
            await _context.SaveChangesAsync();
            return ConvertFileDTO(file);
        }

        private ReadFileDTO ConvertFileDTO(File file)
        {
            return new ReadFileDTO
            {
                Id = file.Id,
                UserId = file.UserId
            };
        }

        private IEnumerable<ReadFileDTO> ConvertListFilesDTO(IEnumerable<File> file)
        {
            List<ReadFileDTO> files = new();

            foreach(File f in file)
            {
                files.Add(new ReadFileDTO
                {
                    Id = f.Id,
                    UserId = f.UserId,
                });
            }

            return files;
        }
    }
}
