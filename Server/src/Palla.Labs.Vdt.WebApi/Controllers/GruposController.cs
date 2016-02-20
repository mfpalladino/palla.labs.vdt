﻿using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Palla.Labs.Vdt.App.ServicosAplicacao;
using Palla.Labs.Vdt.App.ServicosAplicacao.Dtos;

namespace Palla.Labs.Vdt.Controllers
{
    public class GruposController : ApiController
    {
        private readonly CriadorGrupo _criadorGrupo;
        private readonly ModificadorGrupo _modificadorGrupo;
        private readonly LocalizadorGrupo _localizadorGrupo;

        public GruposController(CriadorGrupo criadorGrupo, ModificadorGrupo modificadorGrupo, LocalizadorGrupo localizadorGrupo)
        {
            _criadorGrupo = criadorGrupo;
            _modificadorGrupo = modificadorGrupo;
            _localizadorGrupo = localizadorGrupo;
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] Grupo grupo)
        {
            var grupoSalvo = _criadorGrupo.Criar(grupo);
            var response = Request.CreateResponse(HttpStatusCode.Created);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = grupoSalvo.Id }));
            return response;
        }

        [HttpPut]
        [Route("grupos/{id}")]
        public HttpResponseMessage Put([FromUri] string id, [FromBody] Grupo grupo)
        {
            _modificadorGrupo.Modificar(id, grupo);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        [HttpGet]
        [Route("grupos/{id}")]
        public HttpResponseMessage Get(string id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorGrupo.Localizar(id));
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _localizadorGrupo.Localizar());
        }
    }
}