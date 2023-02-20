using LoginAuth.Context;
using LoginAuth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userService;
        public UserController(IUser userservice)
        {
            _userService = userservice;
             
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]

        public IActionResult GetUsers()
        {
            var coin = _userService.GetUsers();
            if (!ModelState.IsValid)

                return BadRequest(ModelState);
            return Ok(coin);
        }
        [HttpPost]
        
        public IActionResult AddUser([FromBody] User user)
        {
            try
            {
                _userService.Adduser(user);
                return Ok("User added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }




        //private readonly AppDbContext _authcontext;

        //public UserController(IUser userService)
        //{
        //    _userService = userService;
        //}
        ////public UserController (AppDbContext appContext)
        ////{
        ////    _authcontext = appContext;
        ////}
        //private List<User> users;
        //private readonly IUser _userService;

        //[HttpGet("authenticate")]




        //  [HttpPost("authenticate")]

        //  public async Task<IActionResult> Authenticate([FromBody] User userobj)
        //  {
        //      if (userobj == null)
        //          return BadRequest();
        //      var user = await _authcontext.User.
        //          FirstOrDefaultAsync(x => x.UserName == userobj.UserName && x.Password == userobj.Password);
        //      if (user == null)
        //          return NotFound(new {Message = "user not found "});
        //      return Ok(new
        //      {

        //           Message ="Login Success!!!!!!!!!"
        //      });

        //  }
        //[HttpPost ("regristration")]

        //public async Task<IActionResult> RegisterUser([FromBody] User userobj)
        //  {
        //      if (userobj == null)
        //          return BadRequest();
        //     await _authcontext.User.AddAsync(userobj);
        //      await _authcontext.SaveChangesAsync();
        //      return Ok(new
        //      {
        //          Message = "you are register"
        //      });

        //  }
    }
}
