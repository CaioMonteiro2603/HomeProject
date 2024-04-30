using System.ComponentModel.DataAnnotations;

namespace HomeProject.Models
{
    public class UserModelWithoutPassword
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Login {  get; set; }
    }
}
