using EmployeeTracking.Data.Context.Concrete;
using EmployeeTracking.Data.Models;
using EmployeeTracking.Data.Repositories.Abstarct;

namespace EmployeeTracking.Data.Repositories.Concrete
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
