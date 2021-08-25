using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FileService.Models
{
    public class FileContext : DbContext
    {
        public FileContext(DbContextOptions<FileContext> options) : base(options)
        {
        }

        public DbSet<File> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>().ToTable("File");
        }
        
    }
}