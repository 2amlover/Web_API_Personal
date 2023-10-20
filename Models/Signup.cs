using System.ComponentModel.DataAnnotations;

namespace signupapi.Models
{
    public class Signup
    {
        [Key]
        //public int Id { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
