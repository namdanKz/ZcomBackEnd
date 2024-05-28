using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using backend_api.Data;
using backend_api.Interfaces;
using backend_api.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_api.Repository
{
    public class UserGroupRepository : IUserGroupRepository
    {
        private readonly ApplicationDBContext _context;
        public UserGroupRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<UserGroup>> GetAll()
        {
            return await _context.UserGroups.ToListAsync();
        }

    }
}