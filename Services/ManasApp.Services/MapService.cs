using AutoMapper;
using ManasApp.Common;
using ManasApp.Data;
using ManasApp.Data.Contract.Repositories;
using ManasApp.Services.Contract.Interfaces;
using ManasApp.Services.Contract.Models.Map;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManasApp.Services
{
    public class MapService : IMapService
    {
        private readonly IMapRepository _mapRepository;
        private readonly IMapper _mapper;
        public MapService(IMapRepository mapRepository
            ,IMapper mapper)
        {
            _mapRepository = mapRepository;
            _mapper = mapper;
        }
        public async Task<OperationResult<MapDto>> GetAsync(Guid id)
        {
            var operationResult = new OperationResult<MapDto>();
            try
            {
                var entity = await _mapRepository.GetAsync(id);
                operationResult.Result = _mapper.Map<MapDto>(entity);
                operationResult.Success = true;
            }
            catch(Exception ex)
            {
                operationResult.ErrorMessage = ex.Message;
            }

            return operationResult;
        }
    }
}
