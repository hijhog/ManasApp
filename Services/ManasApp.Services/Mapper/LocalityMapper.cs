using AutoMapper;
using ManasApp.Data.Contract.Entities;
using ManasApp.Services.Contract.Models.Locality;
using System.Linq;

namespace ManasApp.Services.Mapper
{
    public class LocalityMapper : Profile
    {
        public LocalityMapper()
        {
            this.CreateMap<Locality, LocalityDto>()
                .ForMember(dest=>dest.StorageData, opt=>opt.Ignore());
            this.CreateMap<Locality, LocalityDetails>()
                .ForMember(dest => dest.StorageData, opt => opt.MapFrom(src => src.StorageData.Select(x => new StorageDataItem { Id = x.Id, Url = x.UrlAddress })));

            this.CreateMap<LocalityDto, Locality>()
                .ForMember(dest => dest.StorageData, opt => opt.Ignore());
        }
    }
}
