using System;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.WebApi.Testes.Fabricas
{
    public class ConstrutorCliente
    {
        private Guid _siteId;

        public ConstrutorCliente NoSite(Guid siteId)
        {
            _siteId = siteId;
            return this;
        }

        public Cliente Construir()
        {
            return new Cliente(_siteId,
                Guid.NewGuid(), 
                new ConstrutorCnpj().Construir(),
                "cliente",
                "codigo",
                new ConstrutorEndereco().Construir(),
                new ConstrutorCorreioEletronico().ComEnderecoEspecifico("loja@testecom.br").Construir(),
                new ConstrutorCorreioEletronico().ComEnderecoEspecifico("manutencao@testecom.br").Construir(),
                new ConstrutorCorreioEletronico().ComEnderecoEspecifico("administracao@testecom.br").Construir());
        }
    }
}