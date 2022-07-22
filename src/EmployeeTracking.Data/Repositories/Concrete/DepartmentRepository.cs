using Dapper;
using EmployeeTracking.Data.Context.Concrete;
using EmployeeTracking.Data.Models;
using EmployeeTracking.Data.Repositories.Abstarct;
using System.Data;
using System.Linq.Expressions;

namespace EmployeeTracking.Data.Repositories.Concrete
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DapperDbContext _dbContext;

        public DepartmentRepository(DapperDbContext dapperDbContext)
        {
            _dbContext = dapperDbContext;
        }
        public Task<IEnumerable<Department>> FindAsync(Expression<Func<Department, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            var sql = $"SELECT \"Id\",\"Name\",\"CreatedAt\" FROM \"Departments\" WHERE \"IsDeleted\"=false";
            using (var connection = _dbContext.CreateConnection())
            {
                var result = await connection.QueryAsync<Department>(sql);
                return result;
            }
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            var query = $"SELECT \"Id\",\"Name\",\"CreatedAt\" FROM \"Departments\" WHERE \"Id\" = @Id and \"IsDeleted\"=false";
            using (var connection = _dbContext.CreateConnection())
            {
                var result = await connection.QueryFirstAsync<Department>(query, new { id });
                return result;
            }
        }

        public async Task InsertAsync(Department entity)
        {
            var query = $"INSERT INTO \"Departments\" (\"Name\",\"CreatedAt\",\"IsDeleted\",\"Available\") VALUES (@name,@created_at,@is_deleted,@available)";

            var parameters = new DynamicParameters();
            parameters.Add("name", entity.Name, DbType.String);
            parameters.Add("created_at", entity.CreatedAt, DbType.DateTime);
            parameters.Add("is_deleted", entity.IsDeleted, DbType.Boolean);
            parameters.Add("available", entity.Available, DbType.Boolean);

            using (var connection = _dbContext.CreateConnection())
            {
                connection.Open();
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void Remove(Department entity)
        {
            #region Hard Delete
            //var query = $"DELETE FROM \"Departments\" WHERE Id = @Id";

            //using (var connection = _dbContext.CreateConnection())
            //{
            //    connection.Open();
            //    await connection.ExecuteAsync(query, new { entity.Id });
            //}
            #endregion

            var query = $"UPDATE \"Departments\" SET \"IsDeleted\"=@is_deleted WHERE \"Id\" =@Id ";
            var parameters = new DynamicParameters();
            parameters.Add("Id", entity.Id);
            parameters.Add("is_deleted", true);
            using (var connection = _dbContext.CreateConnection())
            {
                connection.Open();
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void Update(Department entity)
        {
            var query = $"UPDATE \"Departments\" SET \"Name\" =@name WHERE \"Id\" =@Id ";
            var parameters = new DynamicParameters();
            parameters.Add("Id", entity.Id);
            parameters.Add("name", entity.Name, DbType.String);
            using (var connection = _dbContext.CreateConnection())
            {
                connection.Open();
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
