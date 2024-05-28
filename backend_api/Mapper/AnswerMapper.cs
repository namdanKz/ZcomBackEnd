using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_api.Dto;
using backend_api.Models;

namespace backend_api.Mapper
{
    public static class AnswerMapper
    {
        public static AnswerDto ToAnswerDto(this Answer answerModel)
        {
            return new AnswerDto{
                answerId = answerModel.Id,
                // QuestionId = answerModel.QuestionId,
                // AnswerIndex = answerModel.AnswerIndex,
                AnswerText = answerModel.AnswerText,
                // Score = answerModel.Score
            };
        }
    }
}