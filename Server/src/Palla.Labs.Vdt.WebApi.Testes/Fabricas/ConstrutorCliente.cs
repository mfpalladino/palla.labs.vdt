using System;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.WebApi.Testes.Fabricas
{
    public class ConstrutorCliente
    {
        public Cliente Construir()
        {
            return new Cliente(Guid.NewGuid(),
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