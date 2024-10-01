using DataAccessLayer.Data.Context;

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



    }
}
