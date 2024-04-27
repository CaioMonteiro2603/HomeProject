using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeProject.Models
{
    [Table("Login")]
    public class LoginModel
    {
        [Required(ErrorMessage = "User's login is required")]
        public string Login { get; set; }

        [Required(ErrorMessage = "User's password is required")]
        public string Password { get; set; }

        public LoginModel()
        {
            
        }

        public LoginModel(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
