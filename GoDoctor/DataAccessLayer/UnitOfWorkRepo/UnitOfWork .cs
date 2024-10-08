using DataAccessLayer.Data.Context;
using DataAccessLayer.Repositories.AppointmentRepo;
using DataAccessLayer.Repositories.DoctorRepo;
using DataAccessLayer.Repositories.SpecialtyRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace DataAccessLayer.UnitOfWorkRepo
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly GoDoctorContext _context;
       


        public UnitOfWork(GoDoctorContext context)
        {
            this._context = context;
            doctorRepository = new DoctorRepository(context);
            SpecialtyRepository = new SpecialtyRepository(context);
            AppointmentRepo = new AppointmentRepo(context);
            AppointmentRepo = new AppointmentRepo(context);
           
          
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _transaction?.Dispose();
            GC.SuppressFinalize(this);
        }

        private IDbContextTransaction _transaction; // Add this field to your class

        public IDoctorRepository doctorRepository {  get; private set; }
        public ISpecialtyRepository SpecialtyRepository {  get; private set; }
        public IAppointmentRepo AppointmentRepo { get; private set; }
        public async Task<IDbContextTransaction> BeginTransactionAsync(System.Data.IsolationLevel isolationLevel)
        {
            _transaction = await _context.Database.BeginTransactionAsync(isolationLevel);
            return _transaction;
        }

        public void Commit()
        {
            try
            {
                _transaction?.Commit();
            }
            catch
            {
                _transaction?.Rollback();
                throw;
            }
            finally
            {
                _transaction?.Dispose();
                _transaction = null; // Reset the transaction field after disposal
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction?.Rollback();
            }
            finally
            {
                _transaction?.Dispose();
            }
        }

        public Task<int> CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
