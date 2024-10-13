using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        //[Required]
        //[EmailAddress]
        public override string Email { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? Code { get; set; }
       public ICollection<Comment> Comments { get; set; }
       

    }
}
