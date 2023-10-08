using System.ComponentModel.DataAnnotations;

namespace WebAssessment

{
    public class UserDetails
    {
 
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9-_]+$", ErrorMessage = "Username can only contain letters, numbers, and underscores.")]
        public string Username { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Mail { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Phone number can only contain numbers.")]
        public string PhoneNumber { get; set; }
        public string Skillsets { get; set; }
        public string Hobby { get; set; }
    }
}
