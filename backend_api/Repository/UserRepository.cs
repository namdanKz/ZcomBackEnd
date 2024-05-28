using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_api.Data;
using backend_api.Interfaces;
using backend_api.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool?> CheckSubmit(string userName)
        {
            var user = await _context.Users.FirstOrDefaultAsync( x=> x.UserName == userName);
            if(user == null || user.IsSubmitted == false)
            {
                return false;
            }
            return true;
        }

        public async Task<User> CreateUser(User userModel)
        {
            await _context.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<User?> GetUser(int id)
        {
            return await _context.Users.FirstOrDefaultAsync( x=>x.Id == id);
        }

        public async Task<User?> GetUser(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync( x=>x.UserName == userName);
        }
    }
}