using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileService.Models;

namespace FileService.Repositories
{
    public class DbInit
    {
        public static void Init(FileContext context)
        {
            context.Database.EnsureCreated();

            if(context.Files.Any())
            {
                return;
            }

            var users = new File[]
            {
                new File{ Id = 1 ,UserId = Guid.Parse("844d024c-a958-11eb-bcbc-0242ac130002"), Name="TestFile.jpg", Path="", Extension=".jpg"}
            };

            foreach(File u in users)
            {
                context.Files.Add(u);
            }

            context.SaveChanges();
        }
    }
}