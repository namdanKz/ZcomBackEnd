using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_api.Dto;
using backend_api.Models;

namespace backend_api.Interfaces
{
    public interface ISaveAnswerRepository
    {
        Task<bool> SaveResult(SaveAnswerDto saveAnswerModel);
        Task<User> Submit(string userName);
        Task<SummaryDto> GetSummary(string userName);
    }
}