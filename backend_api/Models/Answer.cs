using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_api.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public int? QuestionId { get; set; }
        public Question? Question { get; set; }
        public int AnswerIndex { get; set; }
        public string AnswerText {get;set;} = string.Empty;
        public int Score { get; set; }
    }
}