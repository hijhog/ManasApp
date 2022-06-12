using AutoMapper;
using ManasApp.Data.Contract.Entities;
using ManasApp.Services.Contract.Models.Locality;

namespace ManasApp.Services.Mapper
{
    public class LocalityMapper : Profile
    {
        public LocalityMapper()
        {
            this.CreateMap<Locality, LocalityDto>()
                .ForMember(dest=>dest.StorageData, opt=>opt.Ignore());
            this.CreateMap<LocalityDto, Locality>()
                .ForMember(dest => dest.StorageData, opt => opt.Ignore());
        }
    }
}
