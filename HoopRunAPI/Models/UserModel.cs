using System.ComponentModel.DataAnnotations;

namespace HoopRunAPI.Models
{
    public class UserModel
    {
        public virtual int Id { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name is a required field")]
        [StringLength(40)]
        public virtual string Username { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public virtual string Email { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Invalid First Name")]
        public virtual string Firstname { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Invalid Last Name")]
        public virtual string Lastname { get; set; }

        [Display(Name = "Profile Picture")]
        [DataType(DataType.ImageUrl)]
        public virtual string ProfilePicture { get; set; }

        [Required]
        public virtual bool Status { get; set; }

        public virtual Address address { get; set; }
    }
}
