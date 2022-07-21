using EmployeeTracking.Base.BaseModel;
using EmployeeTracking.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracking.Data.Repositories.Abstarct
{
    public interface IBaseRepository<Entity> where Entity : BaseEntity
    {
        Task<Entity> GetByIdAsync(int entityId);
        Task InsertAsync(Entity entity);
        void Remove(Entity entity);
        void Update(Entity entity);
        Task<IEnumerable<Entity>> GetAllAsync();
        Task<IEnumerable<Entity>> FindAsync(Expression<Func<Entity, bool>> expression);
    }
}
