using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.DTOs;
using UserService.Models;

namespace UserService.Repositories
{
    public interface IUserExtensions
    {
        Task<ReadUserDTO> GetUser(Guid id);

        Task<IEnumerable<ReadUserDTO>> GetUsers();

        Task<ReadUserDTO> CreateUser(User user);

        void UpdateUser(User user);
    }
}
