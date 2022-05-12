using ManasApp.Common;
using ManasApp.Services.Contract.Models.Locality;

namespace ManasApp.Services.Contract.Interfaces
{
    public interface ILocalityService
    {
        Task<OperationResult> AddAsync(LocalityDto dto);
        Task<OperationResult> UpdateAsync(LocalityDto dto);
        Task<OperationResult> DeleteAsync(Guid id);
        Task<OperationResult<LocalityDto>> GetAsync(Guid id);
        OperationResult<IEnumerable<LocalityDto>> GetAll();
    }
}
