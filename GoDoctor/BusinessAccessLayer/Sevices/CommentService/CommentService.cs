using BusinessAccessLayer.DataViews.CommentView;
using BusinessAccessLayer.Hubs;
using DataAccessLayer.Data.Models;
using DataAccessLayer.UnitOfWorkRepo;
using Microsoft.AspNetCore.SignalR;
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
        private readonly IHubContext<CommentHub> _hubContext;
        public CommentService(IUnitOfWork unitOfWork, IHubContext<CommentHub> _hubContext)
        {
            this.unitOfWork = unitOfWork;
            this._hubContext = _hubContext;
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
                      var commentsView = new DoctorCommentsView
                    {
                        Id = comment.Id,
                        CommentAt = comment.CreatedDate,
                        Comment = comment.CommentContent,
                        UserName = comm.User.FirstName + " " + comm.User.LastName
                    };
                    // Commit the transaction if everything is successful
                    await transaction.CommitAsync();
                    await _hubContext.Clients.All.SendAsync("ReceiveComment",commentsView);
                    return commentsView;
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
