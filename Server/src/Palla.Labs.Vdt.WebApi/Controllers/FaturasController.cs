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
        private readonly IntegradorPayPal _integradorPayPal;

        public FaturasController(CriadorFatura criadorFatura, LocalizadorFatura localizadorFatura, IntegradorPayPal integradorPayPal)
        {
            _criadorFatura = criadorFatura;
            _localizadorFatura = localizadorFatura;
            _integradorPayPal = integradorPayPal;
        }

        [HttpPost]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        public HttpResponseMessage Post([FromBody] FaturaDto faturaDto)
        {
            _criadorFatura.Validar(Request.PegarSiteIdDoUsuario(), faturaDto);
            var resultado = _integradorPayPal.CriarPagamento(GetBaseUrl(), faturaDto);
            return Request.CreateResponse(HttpStatusCode.OK, new { Url = resultado.UrlParaPagamento });
        }

        [Route("faturas/PagamentoEfetuado")]
        public HttpResponseMessage PagamentoEfetuado(string paymentId, string token, string PayerID)
        {
            return Request.CreateResponse(HttpStatusCode.OK); //todo
        }

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

        private string GetBaseUrl()
        {
            return Request.RequestUri.Scheme + "://" + Request.RequestUri.Host;
        }
    }
}