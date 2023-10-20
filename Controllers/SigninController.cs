using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using signinapi.Models;

namespace signinapi.Controllers
{
    

       [Route("api/[controller]")]
       [ApiController]
       public class SigninController : Controller
        {
        private readonly SigninContext _context;

            public SigninController(SigninContext context)
            {
                _context = context;
            }


            [HttpGet]
            [Route("getUserSignins")]
            public async Task<ActionResult<IEnumerable<Signin>>> GetUserSignins()
            {
                var signins = await _context.Signins.ToListAsync();
                return Ok(signins);
            }

            //[HttpGet]
            //[Route("getSignin")]
            //public async Task<ActionResult<Signin>> GetSignin(int id)
            //{
            //    var signin = await _context.Signins.FindAsync(id);
            //    if (signin == null)
            //        return BadRequest("No signins found!");
            //    return Ok(signin);
            //}

            [HttpPost]
            [Route("addSignin")]
            public async Task<ActionResult<Signin>> AddUser(Signin request)
            {
                _context.Signins.Add(request);
                await _context.SaveChangesAsync();
                return Ok(request);
            }

        }
    }
