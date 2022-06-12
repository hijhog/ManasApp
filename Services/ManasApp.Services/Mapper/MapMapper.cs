using AutoMapper;
using ManasApp.Data.Contract.Entities;
using ManasApp.Services.Contract.Models.Map;

namespace ManasApp.Services.Mapper
{
    public class MapMapper : Profile
    {
        public MapMapper()
        {
            this.CreateMap<Map, MapDto>();
            this.CreateMap<MapDto, Map>();
        }
    }
}
