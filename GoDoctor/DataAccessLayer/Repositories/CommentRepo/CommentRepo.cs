using DataAccessLayer.Data.Context;
using DataAccessLayer.Data.Models;
using DataAccessLayer.Repositories.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.CommentRepo
{
    public class CommentRepo : GenericRepo<Comment>, ICommentRepo
    {
        public CommentRepo(GoDoctorContext context) : base(context)
        {
        }

        public async Task<Comment> GetCommentWithUser(int commenId)
        {
            return await context.Comments.AsNoTracking().Include(c => c.User).FirstOrDefaultAsync(c => c.Id == commenId);
        }
    }
}
