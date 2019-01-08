using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto_Livraria.Web.Api.Controllers
{
    public abstract class BaseHttpApiController : ApiController
    {
        protected HttpResponseMessage ObterJsonResponseSucesso(object dadosDeRetorno)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(dadosDeRetorno),
                    System.Text.Encoding.UTF8,
                    "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        protected HttpResponseMessage ObterResponseErro(HttpStatusCode status, string mensagemDeErro)
        {
            return Request.CreateErrorResponse(status, mensagemDeErro);
        }
    }
}