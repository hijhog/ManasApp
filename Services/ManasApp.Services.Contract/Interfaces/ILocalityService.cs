using ManasApp.Common;
using ManasApp.Data.Contract.Models;
using ManasApp.Services.Contract.Models.Locality;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManasApp.Services.Contract.Interfaces
{
    public interface ILocalityService
    {
        Task<OperationResult> AddAsync(LocalityDto dto);
        Task<OperationResult> UpdateAsync(LocalityDto dto);
        Task<OperationResult> DeleteAsync(Guid id);
        Task<OperationResult<LocalityDto>> GetAsync(Guid id);
        OperationResult<IEnumerable<LocalityDto>> GetAll();
        Task<PageViewModel<LocalityDto>> GetPage(int page);
        Task<PageViewModel<LocalityDto>> GetSearchPage(string searchText, int page);
    }
}
