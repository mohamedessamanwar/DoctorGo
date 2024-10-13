using BusinessAccessLayer.DataViews.CommentView;
using DataAccessLayer.Data.Models;
using DataAccessLayer.UnitOfWorkRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Sevices.CommentService
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork unitOfWork;
        public CommentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<DoctorCommentsView> AddComment(string UserId, CommentAddView commentAddView)
        {
            using (var transaction = await unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted)) // Begin a transaction
            {
                try
                {
                    var comment = new Comment()
                    {
                        UserId = UserId,
                        CommentContent = commentAddView.Comment,
                        DoctorId = commentAddView.DocId,
                        CreatedDate = DateTime.Now,
                        IsDeleted = false,
                    };

                    await unitOfWork.CommentRepo.AddAsync(comment);
                    await unitOfWork.CompleteAsync();  // Save the comment

                    var comm = await unitOfWork.CommentRepo.GetCommentWithUser(comment.Id);

                    // Commit the transaction if everything is successful
                    await transaction.CommitAsync();

                    return new DoctorCommentsView
                    {
                        Id = comment.Id,
                        CommentAt = comment.CreatedDate,
                        Comment = comment.CommentContent,
                        UserName = comm.User.FirstName + " " + comm.User.LastName
                    };
                }
                catch (Exception)
                {
                    // Rollback the transaction if something fails
                    return null; 
                }
            }
        }



    }
}
