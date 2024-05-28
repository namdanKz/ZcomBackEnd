using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_api.Models;

namespace backend_api.Dto
{
    public class QuestionDto
    {
        // public int Id { get; set; }
        // public int? UserGroupId { get; set; } 
        // public int QuestionIndex { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public List<AnswerDto> Answers { get; set; } = new List<AnswerDto>();
    }
}