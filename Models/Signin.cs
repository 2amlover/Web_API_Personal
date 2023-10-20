using System.ComponentModel.DataAnnotations;

namespace signinapi.Models
{
    public class Signin
    {
        [Key]
        //public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
