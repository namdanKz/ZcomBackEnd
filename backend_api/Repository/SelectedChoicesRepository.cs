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
    public class SelectedChoicesRepository : ISelectedChoicesRepository
    {
        private readonly ApplicationDBContext _context;
        public SelectedChoicesRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<SelectedChoices>?> GetSelectedChoices(int id)
        {
            var result = await _context.SelectedChoices.Include( c => c.Answer).ToListAsync();
            return result.Where( x => x.UserId == id).ToList();
        }

        public async Task<List<SelectedChoices>?> GetSelectedChoices(string userName)
        {
            var user = await _context.Users.FirstOrDefaultAsync( x => x.UserName == userName);
            int id = (int)user.Id;
            var result = await _context.SelectedChoices.Include( c => c.Answer).ToListAsync();
            return result.Where( x => x.UserId == id).ToList();
        }

    }
}