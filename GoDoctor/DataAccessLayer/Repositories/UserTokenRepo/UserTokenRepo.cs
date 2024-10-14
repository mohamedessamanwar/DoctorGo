using DataAccessLayer.Data.Context;
using DataAccessLayer.Data.Models;
using DataAccessLayer.Repositories.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccessLayer.Repositories.UserTokenRepo
{
    public class UserTokenRepo : GenericRepo<UserToken>, IUserTokenRepo
    {
        public UserTokenRepo(GoDoctorContext context) : base(context)
        {
        }

        public async Task<UserToken?> GetUserToken (string token)
        {

             
            var Token = await context.UserTokens
                .FirstOrDefaultAsync(t => t.Token == token &&
                                          t.CreatedDate >= DateTime.UtcNow.AddMinutes(-30) &&
                                          t.IsDeleted == false);
            return Token;



        }
    }
}
