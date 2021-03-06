using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Sample.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Sample.Api.Controllers
{
    [Route("/api/users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllAsync();
            if (!users.Any())
            {
                return NotFound();
            }
            return Ok(users);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Models.UserModel userModel, CancellationToken token)
        {
            var userEntity = new Core.User()
            {
                Email = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName
            };
            
            await _userService.CreateAsync(userEntity, token);
            
            return Ok();
        }
        
        [HttpPut]
        public IActionResult Update([FromBody] Models.UserModel userModel, CancellationToken token)
        {
            var userEntity = new Core.User()
            {
                Id = userModel.Id,
                Email = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName
            };
            
            _userService.UpdateAsync(userEntity, token);
            
            return Ok();
        }
        
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id, CancellationToken token)
        {
            _userService.DeleteAsync(id, token);
            return Ok();
        }
    }
}