using ManasApp.Common;
using ManasApp.Services.Contract.Models.Map;
using System;
using System.Threading.Tasks;

namespace ManasApp.Services.Contract.Interfaces
{
    public interface IMapService
    {
        Task<OperationResult<MapDto>> GetAsync(Guid id);
    }
}
