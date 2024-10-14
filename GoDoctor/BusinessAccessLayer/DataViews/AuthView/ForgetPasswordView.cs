using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.DataViews.AuthView
{
    public class ForgetPasswordView
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
