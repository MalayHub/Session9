using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required, RegularExpression("^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4})*$", ErrorMessage = "Enter Valid Email")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be atleast 8 characters long.")]
        [Required, RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,12}$"
            , ErrorMessage = "Enter Strong Password which contains at least one special character, number, small and capital alphabet.")]
        public string Password { get; set; }
        [NotMapped, DataType(DataType.Password), Compare("Password")]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
