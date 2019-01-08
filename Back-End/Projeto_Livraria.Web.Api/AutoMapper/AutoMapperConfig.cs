using AutoMapper;

namespace Projeto_Livraria.Web.Api.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(p =>
            {
                p.AddProfile<DomainToDtoMappingProfile>();
                p.AddProfile<DtoToDomainMappingProfile>();
            });
        }
    }
}