using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserService.DTOs;
using UserService.Models;
using UserService.Interfaces;

namespace UserService.Extensions
{
    public class UserExtensions : IUserExtensions
    {
        private readonly UserContext _context;

        public UserExtensions(UserContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReadUserDTO>> GetUsers()
        {
            var users =  await _context.Users.ToListAsync();
            return ConvertListUsersDTO(users);
        }
        public async Task<ReadUserDTO> GetUser(Guid id)
        {
            var user =  await _context.Users.Where(user => user.Id == id).SingleOrDefaultAsync();
            return ConvertUserDTO(user);
        }

        public async Task<ReadUserDTO> CreateUser(User user)
        {
            user.Id = Guid.NewGuid();
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return ConvertUserDTO(user);
        }

        public async void UpdateUser(User user)
        {
            var existingUser = await _context.Users.Where(userIndex => userIndex.Id == user.Id).SingleOrDefaultAsync();
            existingUser = user;
            await _context.SaveChangesAsync();
        }

        private ReadUserDTO ConvertUserDTO(User user)
        {
            return new ReadUserDTO
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                OrganizationName = user.OrganizationName
            };
        }

        private IEnumerable<ReadUserDTO> ConvertListUsersDTO(IEnumerable<User> user)
        {
            List<ReadUserDTO> users = new();

            foreach(User u in user)
            {
                users.Add(new ReadUserDTO
                {
                    Id = u.Id,
                    Username = u.Username,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    OrganizationName = u.OrganizationName
                });
            }

            return users;
        }
    }
}
