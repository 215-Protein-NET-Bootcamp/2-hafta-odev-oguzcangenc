using Dapper;
using EmployeeTracking.Data.Context.Concrete;
using EmployeeTracking.Data.Models;
using EmployeeTracking.Data.Repositories.Abstarct;
using System.Data;
using System.Linq.Expressions;

namespace EmployeeTracking.Data.Repositories.Concrete
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DapperDbContext _dbContext;

        public CountryRepository(DapperDbContext dbContext) : base()
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<Country>> FindAsync(Expression<Func<Country, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            var sql = $"SELECT \"Id\",\"Name\",\"Continent\",\"Currency\",\"CreatedAt\" FROM \"Countries\" WHERE \"IsDeleted\"=false";
            using (var connection = _dbContext.CreateConnection())
            {
                var result = await connection.QueryAsync<Country>(sql);
                return result;
            }
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            var query = $"SELECT \"Id\",\"Name\",\"Continent\",\"Currency\",\"CreatedAt\" FROM \"Countries\" WHERE \"Id\" = @Id and \"IsDeleted\"=false";
            using (var connection = _dbContext.CreateConnection())
            {
                var result = await connection.QueryFirstAsync<Country>(query, new { id });
                return result;
            }
        }

        public async Task InsertAsync(Country entity)
        {
            var query = $"INSERT INTO \"Countries\" (\"Name\",\"Continent\",\"Currency\",\"CreatedAt\",\"IsDeleted\") VALUES (@name,@continent,@currency,@created_at,@is_deleted)";

            var parameters = new DynamicParameters();
            parameters.Add("name", entity.Name, DbType.String);
            parameters.Add("continent", entity.Continent, DbType.String);
            parameters.Add("currency", entity.Currency, DbType.String);
            parameters.Add("created_at", entity.CreatedAt, DbType.DateTime);
            parameters.Add("is_deleted", entity.IsDeleted, DbType.Boolean);

            using (var connection = _dbContext.CreateConnection())
            {
                connection.Open();
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void Remove(Country entity)
        {
            #region Hard Delete
            //var query = $"DELETE FROM \"Countries\" WHERE Id = @Id";

            //using (var connection = _dbContext.CreateConnection())
            //{
            //    connection.Open();
            //    await connection.ExecuteAsync(query, new { entity.Id });
            //}
            #endregion

            var query = $"UPDATE \"Countries\" SET \"IsDeleted\"=@is_deleted WHERE \"Id\" =@Id ";
            var parameters = new DynamicParameters();
            parameters.Add("Id", entity.Id);
            parameters.Add("is_deleted", true);
            using (var connection = _dbContext.CreateConnection())
            {
                connection.Open();
                await connection.ExecuteAsync(query, parameters);
            }


        }

        public async void Update(Country entity)
        {
            var query = $"UPDATE \"Countries\" SET \"Name\" =@name, \"Continent\"=@continent,\"Currency\"=@currency  WHERE \"Id\" =@Id ";
            var parameters = new DynamicParameters();
            parameters.Add("name", entity.Name, DbType.String);
            parameters.Add("continent", entity.Continent, DbType.String);
            parameters.Add("currency", entity.Currency, DbType.String);
            parameters.Add("Id", entity.Id);
            using (var connection = _dbContext.CreateConnection())
            {
                connection.Open();
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
