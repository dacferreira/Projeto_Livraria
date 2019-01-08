using AutoMapper;
using Projeto_Livraria.Aplicacao.Interfaces.Livros;
using Projeto_Livraria.Dominio.Entities.Livros;
using Projeto_Livraria.Dominio.Excecoes;
using Projeto_Livraria.Web.Api.Dto;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Projeto_Livraria.Web.Api.Controllers
{
    [AllowAnonymous]
    public class LivroController : BaseHttpApiController
    {
        private readonly ILivroAppService _livroAppService;
        public LivroController(ILivroAppService livroAppService)
        {
            _livroAppService = livroAppService ?? throw new ArgumentNullException(nameof(livroAppService));
        }

        [Route("obter")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IEnumerable<LivroDto>))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Type = typeof(string))]
        public HttpResponseMessage Get()
        {
            try
            {

                var listaDto = Mapper.Map<IEnumerable<Livro>, IEnumerable<LivroDto>>(_livroAppService.GetAll());

                return ObterJsonResponseSucesso(listaDto);
            }
            catch (InvalidOperationException e)
            {
                return ObterResponseErro(HttpStatusCode.PreconditionFailed, $"Erro ao obter Livro no repositório: {e.Message}");
            }
            catch (Exception ex)
            {
                return ObterResponseErro(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("obterPorId/{id}")]
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(LivroDto))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Type = typeof(string))]
        public HttpResponseMessage Get(Guid id)
        {
            try
            {
                var dto = Mapper.Map<Livro, LivroDto>(_livroAppService.GetById(id));

                return ObterJsonResponseSucesso(dto);
            }
            catch (InvalidOperationException e)
            {
                return ObterResponseErro(HttpStatusCode.PreconditionFailed, $"Erro ao obter Livro no repositório: {e.Message}");
            }
            catch (Exception ex)
            {
                return ObterResponseErro(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("create")]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(LivroDto))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Type = typeof(string))]
        public async Task<HttpResponseMessage> Create(LivroDto livroDto)
        {
            try
            {
                if(livroDto == null)
                {
                    throw new ArgumentNullException(nameof(livroDto));
                }
                //File.WriteAllBytes("c:\\temp\\diogo\\texte.jpg", novoObjeto.ImagemCapa);
                livroDto.Id = Guid.NewGuid();

                var entidade = Mapper.Map<LivroDto, Livro>(livroDto);

                _livroAppService.ADD(entidade);

                return ObterJsonResponseSucesso(livroDto);
            }
            catch (ValidacaoException exception)
            {
                var erros = exception.ObterErros();
                var mensagem = string.Empty;

                foreach (var erro in erros)
                {
                    ModelState.AddModelError(erro.Campo, erro.Mensagem);
                    mensagem = mensagem + erro.Mensagem + System.Environment.NewLine;
                }
                return ObterResponseErro(HttpStatusCode.PreconditionFailed, mensagem);
            }
            catch (InvalidOperationException e)
            {
                return ObterResponseErro(HttpStatusCode.PreconditionFailed, $"Erro ao adicionar Livro no repositório: {e.Message}");
            }
            catch (Exception ex)
            {
                return ObterResponseErro(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("alterar/id/{id:guid}/preco/{preco}")]
        [HttpPut]
        public async Task<HttpResponseMessage> Change(Guid id, decimal preco)
        {
            try
            {
                var entidade = _livroAppService.GetById(id);
                entidade.Preco = preco;

                _livroAppService.Update(entidade);

                return ObterJsonResponseSucesso(entidade);
            }
            catch (ValidacaoException exception)
            {
                var erros = exception.ObterErros();
                var mensagem = string.Empty;

                foreach (var erro in erros)
                {
                    ModelState.AddModelError(erro.Campo, erro.Mensagem);
                    mensagem = mensagem  + erro.Mensagem + System.Environment.NewLine;
                }
                return ObterResponseErro(HttpStatusCode.PreconditionFailed, mensagem);
            }
            catch (InvalidOperationException e)
            {
                return ObterResponseErro(HttpStatusCode.PreconditionFailed, $"Erro ao adicionar Livro no repositório: {e.Message}");
            }
            catch (Exception ex)
            {
                return ObterResponseErro(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                var entidade = _livroAppService.GetById(id);
                _livroAppService.Remove(entidade);

                var msg = "Livro do respositório excluido com sucesso";

                return ObterJsonResponseSucesso(msg);
            }
            catch (InvalidOperationException e)
            {
                return ObterResponseErro(HttpStatusCode.PreconditionFailed, $"Erro ao excluir Livro no repositório: {e.Message}");
            }
            catch (Exception ex)
            {
                return ObterResponseErro(HttpStatusCode.PreconditionFailed, $"Erro desconhecido: {ex.Message}");
            }
        }
    }
}