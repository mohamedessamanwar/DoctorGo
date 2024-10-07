using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.DataViews.AuthView
{
    public class AuthResult
    {
        public bool IsAuth {  get; set; } = true;
        public string Errors { get; set; } = string.Empty;
        public string UserId { get; set; }
        public string Role { get; set; }
    }
}
