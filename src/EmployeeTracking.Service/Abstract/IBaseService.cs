using EmployeeTracking.Base.BaseModel;
using EmployeeTracking.Base.Response;

namespace EmployeeTracking.Service.Abstract
{
    public interface IBaseService<Dto, Entity> where Entity:BaseEntity
    {
        Task<BaseResponse<Dto>> GetByIdAsync(int id);
        Task<BaseResponse<IEnumerable<Dto>>> GetAllAsync();
        Task<BaseResponse<Dto>> InsertAsync(Dto insertResource);
        Task<BaseResponse<Dto>> UpdateAsync(int id, Dto updateResource);
        Task<BaseResponse<Dto>> RemoveAsync(int id);
       
    }
}
