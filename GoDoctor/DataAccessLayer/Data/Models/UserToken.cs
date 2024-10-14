using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Models
{
    public class UserToken : BaseEntity
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public ApplicationUser User { get; set; }
      

    }
}
