using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_api.Data;
using backend_api.Dto;
using backend_api.Interfaces;
using backend_api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace backend_api.Repository
{
    public class SaveAnswerRepository : ISaveAnswerRepository
    {
        private readonly ApplicationDBContext _context;
        public SaveAnswerRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveResult(SaveAnswerDto saveAnswerModel)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == saveAnswerModel.userName);
            if(user == null)
            {
                return false;
            }
            // Delete existing entries for the user
            var existingChoices = _context.SelectedChoices.Where(sc => sc.UserId == user.Id);
            _context.SelectedChoices.RemoveRange(existingChoices);

            foreach( var answerId in saveAnswerModel.answerId)
            {
                var selectedChoice = new SelectedChoices
                {
                    UserId = user.Id,
                    AnswerId = answerId
                };
                await _context.SelectedChoices.AddAsync(selectedChoice);
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> Submit(string userName)
        {
            var user = await _context.Users.FirstOrDefaultAsync( x=> x.UserName == userName);
            if(user == null)
            {
                return null;
            }
            user.IsSubmitted = true;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<SummaryDto> GetSummary(string userName)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == userName);
            if(user == null)
            {
                return null;
            }
            var userGroupId = user.UserGroupId;

            // Calculate the user's score
            var userAnswers = await _context.SelectedChoices
            .Where(sc => sc.UserId == user.Id)
            .Join(_context.Answers, sc => sc.AnswerId, a => a.Id, (sc, a) => a.Score)
            .ToListAsync();

            var userScore = userAnswers.Sum();

            // Get all users in the same group and calculate their scores
            var groupUsers = await _context.Users
            .Where(u => u.UserGroupId == userGroupId)
            .ToListAsync();

            var userScores = new List<(int UserId, int Score)>();

            foreach (var groupUser in groupUsers)
            {
                var groupUserAnswers = await _context.SelectedChoices
                    .Where(sc => sc.UserId == groupUser.Id)
                    .Join(_context.Answers, sc => sc.AnswerId, a => a.Id, (sc, a) => a.Score)
                    .ToListAsync();

                var groupUserScore = groupUserAnswers.Sum();
                userScores.Add((groupUser.Id, groupUserScore));
            }

            // Determine ranking
            var ranking = userScores.OrderByDescending(us => us.Score)
            .Select((us, index) => new { us.UserId, Rank = index + 1 })
            .FirstOrDefault(ur => ur.UserId == user.Id)?.Rank ?? -1;

            return new SummaryDto{ UserName = userName,Score = userScore,Rank = ranking};
        }
    }
}