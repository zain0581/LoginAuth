using System.ComponentModel.DataAnnotations;

namespace LoginAuth.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }


    }
}
