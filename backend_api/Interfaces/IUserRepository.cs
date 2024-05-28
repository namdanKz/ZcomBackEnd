using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_api.Models;

namespace backend_api.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User userModel);
        Task<User?> GetUser(int id);
        Task<User?> GetUser(string userName);
        Task<bool?> CheckSubmit(string userName);
    }
}