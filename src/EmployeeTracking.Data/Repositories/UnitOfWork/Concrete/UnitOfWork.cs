using EmployeeTracking.Data.Context.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracking.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        public bool disposed;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CompleteAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        protected virtual void Clean(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Clean(true);
            GC.SuppressFinalize(this);
        }
    }
}
