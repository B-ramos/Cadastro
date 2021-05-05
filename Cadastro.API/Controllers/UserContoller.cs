using Cadastro.Application.InputModels;
using Cadastro.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserContoller : ControllerBase
    {
        private readonly IUserService _userService;

        public UserContoller(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return BadRequest("User not found");

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserInputModel userInputModel)
        {

            await _userService.Add(userInputModel);

            return Created(nameof(GetById), userInputModel);
        }
    }
}
