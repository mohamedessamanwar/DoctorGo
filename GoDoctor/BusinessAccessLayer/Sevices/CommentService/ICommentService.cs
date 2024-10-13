using BusinessAccessLayer.DataViews.CommentView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Sevices.CommentService
{
    public interface ICommentService
    {
        Task<DoctorCommentsView> AddComment(string UserId, CommentAddView commentAddView); 

    }
}
