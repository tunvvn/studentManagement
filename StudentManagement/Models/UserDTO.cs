using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "wrong", MinimumLength = 2)]
        public string Password { get; set; }
    }
    public class UserDTO: LoginUserDTO
    {
        public string FirstName  { get; set; }= string.Empty;
        public string LastName { get; set; } = string.Empty;
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = string.Empty;

        public ICollection<string> Roles  { get; set;}
        //[Required]
        //[DataType(DataType.EmailAddress)]
        //public string Email { get; set; } 
        //[Required]
        //[StringLength(15, ErrorMessage ="wrong", MinimumLength =2)]
        //public string PassWord { get; set; }
    }
}
