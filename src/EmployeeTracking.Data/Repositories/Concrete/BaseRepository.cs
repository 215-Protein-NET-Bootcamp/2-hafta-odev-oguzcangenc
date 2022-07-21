using EmployeeTracking.Base.BaseModel;
using EmployeeTracking.Data.Context.Concrete;
using EmployeeTracking.Data.Models;
using EmployeeTracking.Data.Repositories.Abstarct;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace EmployeeTracking.Data.Repositories.Concrete
{
    public class BaseRepository<Entity> : IBaseRepository<Entity> where Entity : BaseEntity
    {
        protected readonly AppDbContext Context;
        private DbSet<Entity> entities;

        public BaseRepository(AppDbContext dbContext)
        {
            this.Context = dbContext;
            this.entities = Context.Set<Entity>();
        }

        public async Task<IEnumerable<Entity>> FindAsync(Expression<Func<Entity, bool>> expression)
        {
            return await entities.Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await entities.AsNoTracking().Where(x=>x.IsDeleted==false).ToListAsync();
        }

        public virtual async Task<Entity> GetByIdAsync(int entityId)
        {
            //return await entities.FindAsync(entityId);
            //return await entities.Where(entity => EF.Property<int>(entity, "Id").Equals(entityId)).SingleOrDefaultAsync();
            return await entities.Where(entity => entity.Id == entityId).SingleOrDefaultAsync();

        }

        public async Task InsertAsync(Entity entity)
        {
            await entities.AddAsync(entity);
        }

        public void Remove(Entity entity)
        {
            //entities.Remove(entity);
            entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
        }

        public void Update(Entity entity)
        {
            entities.Update(entity);
        }
    }
}
