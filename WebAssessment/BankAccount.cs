using System.ComponentModel.DataAnnotations;

namespace WebAssessment
{

    public class BankAccount
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; } // Use UserId to link to the Users table

        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Bank Name can only contain letters, numbers, and spaces.")]
        public string BankName { get; set; }

        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Account Number can only contain numbers.")]
        public string AccountNumber { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\.\d{2})?$", ErrorMessage = "Current Balance must be a number with up to 2 decimal places.")]
        public decimal CurrentBalance { get; set; }
    }


}
