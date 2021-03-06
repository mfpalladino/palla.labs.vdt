﻿using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.Web;
using Palla.Labs.Vdt.App.ServicosAplicacao;

namespace Palla.Labs.Vdt.Controllers
{
    [AtributoValidadorDeToken]
    public class ClientesController : ApiController
    {
        private readonly CriadorCliente _criadorCliente;
        private readonly ModificadorCliente _modificadorCliente;
        private readonly LocalizadorCliente _localizadorCliente;

        public ClientesController(CriadorCliente criadorCliente, ModificadorCliente modificadorCliente, LocalizadorCliente localizadorCliente)
        {
            _criadorCliente = criadorCliente;
            _modificadorCliente = modificadorCliente;
            _localizadorCliente = localizadorCliente;
        }

        [HttpPost]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        public HttpResponseMessage Post([FromBody] ClienteDto clienteDto)
        {
            var clienteSalvo = _criadorCliente.Criar(Request.PegarSiteIdDoUsuario(), clienteDto);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = clienteSalvo.Id }));
            return response;
        }

        [HttpPut]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        [Route("clientes/{id}")]
        public HttpResponseMessage Put([FromUri] string id, [FromBody] ClienteDto clienteDto)
        {
            _modificadorCliente.Modificar(Request.PegarSiteIdDoUsuario(), id, clienteDto);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        [HttpGet]
        [AtributoValidadorDePerfil(TipoUsuario.Dono)]
        [Route("clientes/{id}")]
        public HttpResponseMessage Get(string id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorCliente.Localizar(Request.PegarSiteIdDoUsuario(), id));
        }

        [HttpGet]
        [AtributoValidadorDePerfil(TipoUsuario.Manutenedor)]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorCliente.Localizar(Request.PegarSiteIdDoUsuario()));
        }
    }
}