using EmployeeTracking.Data.Context.Concrete;
using EmployeeTracking.Data.Models;
using EmployeeTracking.Data.Repositories.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracking.Data.Repositories.Concrete
{
    public class FolderRepository : BaseRepository<Folder>, IFolderRepository
    {
        public FolderRepository(AppDbContext context) : base(context)
        {
        }
    }

}
