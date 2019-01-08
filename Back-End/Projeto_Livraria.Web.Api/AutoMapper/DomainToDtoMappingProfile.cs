using AutoMapper;
using Projeto_Livraria.Dominio.Entities.Livros;
using Projeto_Livraria.Web.Api.Dto;

namespace Projeto_Livraria.Web.Api.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DtoToDomainMappings"; }
        }

        protected override void Configure()
        {
            CreateMap<LivroDto, Livro>();
        }
    }
}