using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.PayPal;
using Palla.Labs.Vdt.App.Infraestrutura.Web;
using Palla.Labs.Vdt.App.ServicosAplicacao;

namespace Palla.Labs.Vdt.Controllers
{
    [AtributoValidadorDeToken]
    public class FaturasController : ApiController
    {
        private readonly CriadorFatura _criadorFatura;
        private readonly LocalizadorFatura _localizadorFatura;
        private readonly CriadorPagamento _criadorPagamento;

        public FaturasController(CriadorFatura criadorFatura, LocalizadorFatura localizadorFatura, CriadorPagamento criadorPagamento)
        {
            _criadorFatura = criadorFatura;
            _localizadorFatura = localizadorFatura;
            _criadorPagamento = criadorPagamento;
        }

        [HttpPost]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        public HttpResponseMessage Post([FromBody] FaturaDto faturaDto)
        {
            _criadorFatura.Validar(Request.PegarSiteIdDoUsuario(), faturaDto);
            var urlPagamentoAprovado = _criadorPagamento.CriarPagamento(faturaDto);
            return Request.CreateResponse(HttpStatusCode.OK, urlPagamentoAprovado);
        }

        [HttpPost]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        [Route("faturas/PagamentoEfetuado")]
        public HttpResponseMessage PagamentoEfetuado([FromBody] FaturaDto faturaDto, [FromUri]string paymentId, [FromUri]string token, [FromUri]string payerId)
        {
            return Request.CreateResponse(HttpStatusCode.OK); //todo
        }

        [HttpPost]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        [Route("faturas/PagamentoCancelado")]
        public HttpResponseMessage PagamentoCancelado()
        {
            return Request.CreateResponse(HttpStatusCode.OK); //todo
        }

        [HttpGet]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        [Route("faturas/{id}")]
        public HttpResponseMessage Get(string id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorFatura.Localizar(Request.PegarSiteIdDoUsuario(), id));
        }

        [HttpGet]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorFatura.Localizar(Request.PegarSiteIdDoUsuario()));
        }

        [HttpGet]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        [Route("faturas/atual")]
        public HttpResponseMessage Atual()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorFatura.LocalizarAtual(Request.PegarSiteIdDoUsuario()));
        }
    }
}