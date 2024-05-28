using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_api.Dto
{
    public class AnswerDto
    {
        public int answerId { get; set; }
        // public int? QuestionId { get; set; }
        // public int AnswerIndex { get; set; }
        public string AnswerText {get;set;} = string.Empty;
        // public int Score { get; set; }
    }
}