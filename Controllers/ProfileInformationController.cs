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
    public class ProfileinformationController : Controller
    {
        private readonly ProfileInformationContext _context;

        public ProfileinformationController(ProfileInformationContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("getUserProfileInformations")]
        public async Task<ActionResult<IEnumerable<ProfileInformation>>> GetUserProfileInformations()
        {
            var userprofileinformations = await _context.ProfileInformations.ToListAsync();
            return Ok(userprofileinformations);
        }

        [HttpPost]
        [Route("addProfileInformation")]
        public async Task<ActionResult<ProfileInformation>> AddProfileInformation(ProfileInformation request)
        {
            _context.ProfileInformations.Add(request);
            await _context.SaveChangesAsync();
            return Ok(request);
        }

        [HttpPut]
        [Route("updateUserProfileInformation")]
        public async Task<ActionResult<ProfileInformation>> UpdateUserProfileInformation(ProfileInformation request)
        {
            var userprofileinformations = await _context.ProfileInformations.FindAsync(request.Id);
            if (userprofileinformations == null)
                return BadRequest("No User Profile found!");

            userprofileinformations.FirstName = request.FirstName;
            userprofileinformations.LastName = request.LastName;
            userprofileinformations.Gender = request.Gender;
            userprofileinformations.Email = request.Email;
            userprofileinformations.MobileNumber = request.MobileNumber;

            await _context.SaveChangesAsync();
            return Ok(userprofileinformations);
        }

    }
}
