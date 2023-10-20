using Microsoft.EntityFrameworkCore;
using signupapi.Models;

namespace signupapi.Models
{

    public class SignupContext : DbContext
    {
        public SignupContext(DbContextOptions<SignupContext> options) : base(options)
        {
        }

        public DbSet<Signup> Signups { get; set; }

    }
}
