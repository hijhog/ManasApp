using AutoMapper;
using AutoMapper.QueryableExtensions;
using ManasApp.Common;
using ManasApp.Data.Contract.Entities;
using ManasApp.Data.Contract.Models;
using ManasApp.Data.Contract.Repositories;
using ManasApp.Services.Contract.Interfaces;
using ManasApp.Services.Contract.Models.Locality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManasApp.Services
{
    public class LocalityService : BaseService, ILocalityService
    {
        private readonly ILocalityRepository _localityRepository;
        public LocalityService(
            ILocalityRepository localityRepository,
            IMapper mapper)
            :base(mapper)
        {
            _localityRepository = localityRepository;
        }

        public async Task<OperationResult> AddAsync(LocalityDto dto)
        {
            var result = new OperationResult();
            try
            {
                var entity = await _localityRepository.GetAsync(x => x.NormalizedName == dto.Name.ToUpper());
                if(entity != null)
                {
                    result.ErrorMessage = $"Locality with \"{dto.Name}\" is extists";
                    return result;
                }

                entity = _mapper.Map<Locality>(dto);
                await _localityRepository.AddAsync(entity);
                await _localityRepository.SaveChangesAsync();
                result.Success = true;
            }
            catch(Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public async Task<OperationResult> UpdateAsync(LocalityDto dto)
        {
            var result = new OperationResult();
            try
            {
                var entity = await _localityRepository.GetAsync(dto.Id);
                if(entity is null)
                {
                    result.ErrorMessage = $"Locality with \"{dto.Id}\" is not exists";
                    return result;
                }

                _mapper.Map(dto, entity);

                _localityRepository.Update(entity);
                await _localityRepository.SaveChangesAsync();
                result.Success = true;
            }
            catch(Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public async Task<OperationResult> DeleteAsync(Guid id)
        {
            var result = new OperationResult();
            try
            {
                var entity = await _localityRepository.GetAsync(id);
                if(entity is null)
                {
                    result.ErrorMessage = $"Locality with \"{id}\" is not exists";
                    return result;
                }

                _localityRepository.Delete(entity);
                await _localityRepository.SaveChangesAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public async Task<OperationResult<LocalityDto>> GetAsync(Guid id)
        {
            var result = new OperationResult<LocalityDto>();
            try
            {
                var entity = await _localityRepository.GetAsync(id);
                result.Result = _mapper.Map<LocalityDto>(entity);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public OperationResult<IEnumerable<LocalityDto>> GetAll()
        {
            var result = new OperationResult<IEnumerable<LocalityDto>>();
            try
            {
                var entities = _localityRepository.GetAll()
                    .ProjectTo<LocalityDto>(_mapper.ConfigurationProvider)
                    .ToList();
                result.Result = entities;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public async Task<PageViewModel<LocalityDto>> GetPage(int page)
        {
            var vm = new PageViewModel<LocalityDto>();
            var entitiesTask = Task.Run(() =>
            {
                return _localityRepository.GetAll()
                        .OrderBy(x=>x.Name)
                        .Skip((page - 1) * vm.PageSize)
                        .Take(vm.PageSize);
            });
            var task2 = Task.Run(() => {
                vm.Count = _localityRepository.GetAll().Count();
            });

            Task.WaitAll(entitiesTask, task2);
            var entities = await entitiesTask;
            vm.Page = page;
            vm.Data = entities.Select(x => _mapper.Map<LocalityDto>(x));

            return vm;

        }

        public async Task<PageViewModel<LocalityDto>> GetSearchPage(string searchText, int page)
        {
            var vm = new PageViewModel<LocalityDto>();
            var entitiesTask = Task.Run(() =>
            {
                var query = _localityRepository.GetAll();
                if(!string.IsNullOrEmpty(searchText))
                    query = query.Where(x=>x.Name.Contains(searchText));
                return query.OrderBy(x => x.Name)
                        .Skip((page - 1) * vm.PageSize)
                        .Take(vm.PageSize);
            });
            var task2 = Task.Run(() => {
                vm.Count = _localityRepository.GetAll().Count();
            });

            Task.WaitAll(entitiesTask, task2);
            var entities = await entitiesTask;
            vm.Page = page;
            vm.Data = entities.Select(x => _mapper.Map<LocalityDto>(x));

            return vm;

        }
    }
}
