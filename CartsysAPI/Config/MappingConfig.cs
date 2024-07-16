using AutoMapper;
using CartSysAPI.Data.DTO;
using CartSysAPI.Model;

namespace CartSysAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<PersonDTO, PersonModel>();
                config.CreateMap<PersonModel, PersonDTO>();
            });
        }
    }
}
