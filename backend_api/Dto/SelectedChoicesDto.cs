using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_api.Models;

namespace backend_api.Dto
{
    public class SelectedChoicesDto
    {
        public int? AnswerId { get; set; }
        // public AnswerDto? Answer { get; set; }
        public int? AnswerIndex {get;set;}
    }
}