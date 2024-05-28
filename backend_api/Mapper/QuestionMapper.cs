using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_api.Dto;
using backend_api.Models;

namespace backend_api.Mapper
{
    public static class QuestionMapper
    {
        public static QuestionDto ToQuestionDto(this Question questionModel)
        {
            return new QuestionDto{
                // Id = questionModel.Id,
                // UserGroupId = questionModel.UserGroupId,
                // QuestionIndex = questionModel.QuestionIndex,
                QuestionText = questionModel.QuestionText,
                Answers = questionModel.Answers.Select( a => a.ToAnswerDto()).ToList()
            };
        }
    }
}