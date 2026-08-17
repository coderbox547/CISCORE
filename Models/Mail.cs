using System.ComponentModel.DataAnnotations;

namespace CisCore.Models
{
    public class Mail
    {
        public string? Name { get; set; }
        public string? Email { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number")]
        public string? Phone_No { get; set; }

        public string? Message { get; set; }
        public string? Role { get; set; }
        public string? Service { get; set; }
        public string? Position { get; set; }
        public string? Subscribe { get; set; }
        public string? Country { get; set; }
        public string? Company_Name { get; set; }

        // ASP.NET Core uses IFormFile instead of HttpPostedFileBase
        public IFormFile? file { get; set; }
    }
}
