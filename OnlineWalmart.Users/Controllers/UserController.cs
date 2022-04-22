using Microsoft.AspNetCore.Mvc;
using OnlineWalmart.Users.Context;
using OnlineWalmart.Users.DAL.Entities;
using OnlineWalmart.Users.DAL.Interfaces;

namespace ExerciseInDesignPatterns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly UserContext _context;

        public UserController(IUserRepository userStorage, UserContext context)
        {
            _userRepository = userStorage;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<User>>> GetAllUsers()
        {
            return Ok(await _userRepository.GetAllUsersAsync());
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ICollection<User>>> GetUser(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            if (user is null)
                return NotFound($"User with identity {id} could not be found.");

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<ICollection<User>>> AddUser(User user)
        {
            try
            {
                if (await _userRepository.AddNewUserAsync(user))
                {
                    if (!(await _context.SaveChangesAsync() > 0))
                    {
                        return StatusCode(500, "User could not be saved.");
                    }
                }

                return StatusCode(201, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException!.Message);
            }
        }
    }
}