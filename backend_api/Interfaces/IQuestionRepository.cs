using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_api.Dto;
using backend_api.Models;

namespace backend_api.Interfaces
{
    public interface IQuestionRepository
    {
        Task<List<Question>?> GetQuestion(int id);
        Task<List<Question>?> GetQuestion(string userName);
        Task<List<SaveAnswerDto>?> SaveAnswer(int id);
    }
}