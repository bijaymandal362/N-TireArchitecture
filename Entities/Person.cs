using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    [Index(nameof(Email),IsUnique=true)]
    public class Person:BaseEntity
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }

}