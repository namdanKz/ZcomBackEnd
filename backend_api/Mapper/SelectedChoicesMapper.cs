using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_api.Dto;
using backend_api.Models;

namespace backend_api.Mapper
{
    public static class SelectedChoicesMapper
    {
        public static SelectedChoicesDto ToSelectedChoicesDto(this SelectedChoices selectedChoicesModel)
        {
            return new SelectedChoicesDto{
                AnswerId = selectedChoicesModel.AnswerId,
                // Answer = selectedChoicesModel.Answer.ToAnswerDto(),
                AnswerIndex = selectedChoicesModel.Answer.AnswerIndex
            };
        }
    }
}