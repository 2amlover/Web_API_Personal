using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using signupapi.Models;

namespace signinapi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : Controller
    {
        private readonly SignupContext _context;

        public SignupController(SignupContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("getUserSignups")]
        public async Task<ActionResult<IEnumerable<Signup>>> GetUserSignups()
        {
            var signups = await _context.Signups.ToListAsync();
            return Ok(signups);
        }

        [HttpPost]
        [Route("addSignup")]
        public async Task<ActionResult<Signup>> AddUser(Signup request)
        {
            _context.Signups.Add(request);
            await _context.SaveChangesAsync();
            return Ok(request);
        }

    }
}
