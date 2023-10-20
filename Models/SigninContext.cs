using Microsoft.EntityFrameworkCore;
using signinapi.Models;

namespace signinapi.Models
{

    public class SigninContext : DbContext
    {
        public SigninContext(DbContextOptions<SigninContext> options) : base(options)
        {
        }

        public DbSet<Signin> Signins { get; set; }

    }
}
