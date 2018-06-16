using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Myapp.Data.Dto
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(200)]
        public string FullName { get; set; }

        [Required]
        public int Role { get; set; }

        public int? SecurityQuestionId { get; set; }

        [MaxLength(200)]
        public string SecurityAnswer { get; set; }
    }
}
