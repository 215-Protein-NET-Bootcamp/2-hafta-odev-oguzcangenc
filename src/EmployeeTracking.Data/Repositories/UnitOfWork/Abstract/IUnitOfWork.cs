using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracking.Data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task CompleteAsync();
    }
}
