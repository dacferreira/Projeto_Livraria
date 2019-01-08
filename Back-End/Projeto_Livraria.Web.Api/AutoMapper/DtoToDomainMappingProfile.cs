using AutoMapper;
using Projeto_Livraria.Dominio.Entities.Livros;
using Projeto_Livraria.Web.Api.Dto;

namespace Projeto_Livraria.Web.Api.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToDtoMappings";
            }
        }
        protected override void Configure()
        {
            CreateMap<Livro, LivroDto>();
        }
    }
}