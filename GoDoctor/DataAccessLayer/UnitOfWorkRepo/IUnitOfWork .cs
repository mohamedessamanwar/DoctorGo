using DataAccessLayer.Data.Context;
using DataAccessLayer.Repositories.AppointmentRepo;
using DataAccessLayer.Repositories.BookingRepo;
using DataAccessLayer.Repositories.CommentRepo;
using DataAccessLayer.Repositories.DoctorRepo;
using DataAccessLayer.Repositories.SpecialtyRepo;
using DataAccessLayer.Repositories.TimeSlotRepo;
using DataAccessLayer.Repositories.UserTokenRepo;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace DataAccessLayer.UnitOfWorkRepo
{
    public interface IUnitOfWork
    {
      
        // Task BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.Serializable);
        Task<IDbContextTransaction> BeginTransactionAsync(System.Data.IsolationLevel isolationLevel);
        void Commit();
        void Rollback();
        int Complete();
        Task<int> CompleteAsync();
        public IAppointmentRepo AppointmentRepo { get; }
        public ISpecialtyRepository SpecialtyRepository { get; }
         public IDoctorRepository doctorRepository { get; }
        public ITimeSlotRepo timeSlotRepo { get; }
        public IBookingRepo BookingRepo { get; }
        public ICommentRepo CommentRepo { get; }
        public IUserTokenRepo userTokenRepo { get; }

    }
}
