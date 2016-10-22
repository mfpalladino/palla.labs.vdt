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
        private readonly PagadorFatura _pagadorFatura;
        private readonly LocalizadorFatura _localizadorFatura;
        private readonly IntegradorPayPal _integradorPayPal;

        public FaturasController(CriadorFatura criadorFatura, PagadorFatura pagadorFatura, LocalizadorFatura localizadorFatura, IntegradorPayPal integradorPayPal)
        {
            _criadorFatura = criadorFatura;
            _pagadorFatura = pagadorFatura;
            _localizadorFatura = localizadorFatura;
            _integradorPayPal = integradorPayPal;
        }

        [HttpPost]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        public HttpResponseMessage Post([FromBody] FaturaDto faturaDto)
        {
            _criadorFatura.Validar(Request.PegarSiteIdDoUsuario(), faturaDto);
            var resultado = _integradorPayPal.CriarPagamento(Request.PegarSiteIdDoUsuario(), faturaDto);
            return Request.CreateResponse(HttpStatusCode.OK, new { Url = resultado.UrlParaPagamento });
        }

        [HttpPost]
        [Route("faturas/PagamentoConfirmado")]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        public HttpResponseMessage PagamentoConfirmado(PagamentoConfirmadoDto pagamentoConfirmadoDto)
        {
            _pagadorFatura.Pagar(Request.PegarSiteIdDoUsuario(), pagamentoConfirmadoDto);
            return Request.CreateResponse(HttpStatusCode.OK); 
        }

        [HttpPost]
        [Route("faturas/PagamentoCancelado")]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        public HttpResponseMessage PagamentoCancelado(PagamentoCanceladoDto pagamentoCanceladoDto)
        {
            _integradorPayPal.CancelarPagamento(Request.PegarSiteIdDoUsuario(), pagamentoCanceladoDto.Token);
            return Request.CreateResponse(HttpStatusCode.OK); 
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