using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResourceManager.EntityFrameworkCore.Models
{
    [Table("Users", Schema = "dbo")]
    public class User : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Roles { get; set; }

        public bool IsEmailVerified { get; set; }
        
        public string VerificationEmailToken { get; set; }

        public string ResetPasswordToken { get; set; }

        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
