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
        private readonly AppDbContext _authcontext;
        public UserController (AppDbContext appContext)
        {
            _authcontext = appContext;
        }

        [HttpPost("authenticate")]

        public async Task<IActionResult> Authenticate([FromBody] User userobj)
        {
            if (userobj == null)
                return BadRequest();
            var user = await _authcontext.User.
                FirstOrDefaultAsync(x => x.UserName == userobj.UserName && x.Password == userobj.Password);
            if (user == null)
                return NotFound(new {Message = "user not found "});
            return Ok(new
            {

                 Message ="Login Success!!!!!!!!!"
            });
           
        }
      [HttpPost ("regristration")]

      public async Task<IActionResult> RegisterUser([FromBody] User userobj)
        {
            if (userobj == null)
                return BadRequest();
           await _authcontext.User.AddAsync(userobj);
            await _authcontext.SaveChangesAsync();
            return Ok(new
            {
                Message = "you are register"
            });

        }
    }
}
