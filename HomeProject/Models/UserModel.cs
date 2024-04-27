using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeProject.Models
{
    [Table("User")]
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "User's name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "User's lastname is required")]
        public string UserLastName { get; set; }

        [Required(ErrorMessage = "User's email is required")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "User's password is required")]
        public string UserPassword { get; set; }

        public UserModel()
        {
            
        }

        public UserModel(int userId, string userName, string userLastName, string userEmail, string userPassword)
        {
            UserId = userId;
            UserName = userName;
            UserLastName = userLastName;
            UserEmail = userEmail;
            UserPassword = userPassword;
        }
    }
}
