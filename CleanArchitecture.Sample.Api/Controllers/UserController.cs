using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Sample.Api.Models;
using CleanArchitecture.Sample.Core.Entities;
using CleanArchitecture.Sample.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Sample.Api.Controllers
{
    [Route("/api/users")]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        
        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserModel>(user));
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUsersAsync();
            if (!users.Any())
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<UserModel>>(users));
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] UserModel userModel,
            CancellationToken token)
        {
            var userEntity = _mapper.Map<User>(userModel);
            
            await _userService.CreateUserAsync(userEntity, token);
            
            return Ok();
        }
        
        [HttpPut]
        public IActionResult Update(
            [FromBody] UserModel userModel,
            CancellationToken token)
        {
            var userEntity = _mapper.Map<User>(userModel);
            
            _userService.UpdateUserAsync(userEntity, token);
            
            return Ok();
        }
        
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id, CancellationToken token)
        {
            _userService.DeleteUserAsync(id, token);
            return Ok();
        }
    }
}