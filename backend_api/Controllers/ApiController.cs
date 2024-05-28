using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_api.Dto;
using backend_api.Interfaces;
using backend_api.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace backend_api.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IUserGroupRepository _userGroupRepo;
        private readonly IUserRepository _userRepo;
        private readonly IQuestionRepository _questionRepo;
        private readonly ISelectedChoicesRepository _selectedChoicesRepo;
        private readonly ISaveAnswerRepository _saveAnswerRepo;
        public ApiController(IUserGroupRepository userGroupRepo,IUserRepository userRepo,IQuestionRepository questionRepo,ISelectedChoicesRepository selectedChoicesRepo,ISaveAnswerRepository saveAnswerRepo)
        {
            _userGroupRepo = userGroupRepo;
            _userRepo = userRepo;
            _questionRepo = questionRepo;
            _selectedChoicesRepo = selectedChoicesRepo;
            _saveAnswerRepo = saveAnswerRepo;
        }

        [HttpGet("usergroup")]
        public async Task<IActionResult> GetAllUserGroup()
        {
            var userGroup = await _userGroupRepo.GetAll();  
            var userGroupDto = userGroup.Select( x => x.ToUserGroupDto());
            return Ok(userGroupDto);
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var user = await _userRepo.GetUser(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDto());
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
        {
            var userModel = userDto.ToUserFromCreate();

            var checkDuplicated = await _userRepo.GetUser(userModel.UserName);
            if(checkDuplicated != null)
            {
                return Conflict("This user already created");
            }
            await _userRepo.CreateUser(userModel);
            
            return CreatedAtAction(nameof(GetById),new {id = userModel.Id},userModel.ToUserDto());
        }

        
        [HttpGet("quiz/{userName}")]
        public async Task<IActionResult> GetQuiz([FromRoute] string userName)
        {
            var check = await _userRepo.CheckSubmit(userName);
            if(check.Value)
            {
               return Ok(new {Submit = true});
            }
            var question = await _questionRepo.GetQuestion(userName);
            if(question == null)
            {
                return NotFound();
            }
            var result = question.Select( x => x.ToQuestionDto());
            return Ok(result);
        }

        [HttpGet("load/{userName}")]
        public async Task<IActionResult> GetSelectedAnswer([FromRoute] string userName)
        {
            var result = await _selectedChoicesRepo.GetSelectedChoices(userName);
            var answer = result.Select( x => x.ToSelectedChoicesDto());
            return Ok(answer);
        }

        [HttpPost("save")]
        public async Task<IActionResult> SaveAnswer([FromBody] SaveAnswerDto saveAnswerDto)
        {
            var result = await _saveAnswerRepo.SaveResult(saveAnswerDto);
            if(!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("submit/{userName}")]
        public async Task<IActionResult> SubmitAnswer([FromRoute] string userName)
        {
            var submit = await _saveAnswerRepo.Submit(userName);
            if(submit == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("summary/{userName}")]
        public async Task<IActionResult> GetSummary([FromRoute] string userName)
        {
            var summary = await _saveAnswerRepo.GetSummary(userName);
            if(summary == null)
            {
                return NotFound();
            }
            return Ok(summary);
        }

    }
}