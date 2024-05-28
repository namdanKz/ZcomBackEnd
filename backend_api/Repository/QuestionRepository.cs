using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using backend_api.Data;
using backend_api.Dto;
using backend_api.Interfaces;
using backend_api.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_api.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDBContext _context;
        public QuestionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// ดึงคำถามและคำตอบ
        /// </summary>
        /// <param name="id"> id = userGroupId</param>
        /// <returns></returns>
        public async Task<List<Question>?> GetQuestion(int id)
        {
            var all = await _context.Questions.Include( q => q.Answers).ToListAsync();
            return all.Where(x => x.UserGroupId == id).ToList();
        }

        public async Task<List<Question>?> GetQuestion(string userName)
        {
            var user = await _context.Users.FirstOrDefaultAsync( x => x.UserName == userName);
            int groupId = (int)user.UserGroupId;
            var all = await _context.Questions.Include( q => q.Answers).ToListAsync();
            return all.Where(x => x.UserGroupId == groupId).ToList();
        }

        public Task<List<SaveAnswerDto>?> SaveAnswer(int id)
        {
            throw new NotImplementedException();
        }
    }
}