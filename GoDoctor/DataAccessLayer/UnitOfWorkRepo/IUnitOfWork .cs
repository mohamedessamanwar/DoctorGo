using DataAccessLayer.Data.Context;
using DataAccessLayer.Repositories.AppointmentRepo;
using DataAccessLayer.Repositories.DoctorRepo;
using DataAccessLayer.Repositories.SpecialtyRepo;
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

    }
}
