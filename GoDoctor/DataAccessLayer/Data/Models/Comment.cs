using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Models
{
    public class Comment : BaseEntity
    {
        [MaxLength(500)]
        public string CommentContent { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    
        public int DoctorId { get; set; }

        public Docktor Doctor { get; set; }

    }
}
