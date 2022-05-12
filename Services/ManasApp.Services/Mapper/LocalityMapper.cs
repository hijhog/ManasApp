using AutoMapper;
using ManasApp.Data.Contract.Entities;
using ManasApp.Services.Contract.Models.Locality;

namespace ManasApp.Services.Mapper
{
    public class LocalityMapper : Profile
    {
        public LocalityMapper()
        {
            this.CreateMap<Locality, LocalityDto>();
            this.CreateMap<LocalityDto, Locality>();
        }
    }
}
