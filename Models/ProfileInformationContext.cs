using Microsoft.EntityFrameworkCore;
using signinapi.Models;


namespace signupapi.Models
{


    public class ProfileInformationContext : DbContext
    {
        public ProfileInformationContext(DbContextOptions<ProfileInformationContext> options) : base(options)
        {
        }

        public DbSet<ProfileInformation> ProfileInformations { get; set; }

    }
}
