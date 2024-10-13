using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.DataViews.CommentView
{
    public class DoctorCommentsView
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }
        public DateTime CommentAt { get; set; }
    }
}
