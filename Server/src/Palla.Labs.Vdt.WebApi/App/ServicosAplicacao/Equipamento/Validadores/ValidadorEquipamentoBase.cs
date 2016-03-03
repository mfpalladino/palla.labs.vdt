using System;
using Palla.Labs.Vdt.App.Compartilhado;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public abstract class ValidadorEquipamentoBase : IValidadorEquipamento
    {
        private readonly RepositorioClientes _repositorioClientes;

        protected ValidadorEquipamentoBase(RepositorioClientes repositorioClientes)
        {
            _repositorioClientes = repositorioClientes;
        }

        public virtual void Validar(EquipamentoDto equipamentoDto)
        {
            if (EValidadorDeCriacao)
            {
                if (equipamentoDto.Id != Guid.Empty)
                    throw new FormatoInvalido("O identificador do equipamento não pode ser informado neste contexto.");
            }
            else
            {
                if (equipamentoDto.Id == Guid.Empty)
                    throw new FormatoInvalido("O identificador do equipamento deve ser informado.");
            }

            if (equipamentoDto.Tipo != (int)TipoEquipamento.CentralAlarme &&
                equipamentoDto.Tipo != (int)TipoEquipamento.Extintor &&
                equipamentoDto.Tipo != (int)TipoEquipamento.Mangueira &&
                equipamentoDto.Tipo != (int)TipoEquipamento.SistemaContraIncendioEmCoifa)
                throw new FormatoInvalido("O tipo do equipamento não é válido.");

            if (String.IsNullOrWhiteSpace(equipamentoDto.ClienteId))
                throw new FormatoInvalido("O cliente do equipamento deve ser informado.");

            if (!equipamentoDto.ClienteId.GuidValido())
                throw new FormatoInvalido("O identificador do cliente do equipamento não é válido.");

            if (_repositorioClientes.BuscarPorId(equipamentoDto.ClienteId.ParaGuid()) == null)
                throw new FormatoInvalido("O cliente do equipamento não foi encontrado.");
        }

        public abstract bool EValidadorDeCriacao { get; }

        protected void ValidarAtributosMangueira(int comprimento, int diametro, int tipoMangueira)
        {
            if (comprimento != (int)ComprimentoMangueira.QuinzeMetros &&
                comprimento != (int)ComprimentoMangueira.TrintaMetros &&
                comprimento != (int)ComprimentoMangueira.VinteMetros)
                throw new FormatoInvalido("O comprimento da mangueira não é válido.");

            if (diametro != (int)DiametroMangueira.DoisMetrosEMeio &&
                diametro != (int)DiametroMangueira.UmMetroEMeio)
                throw new FormatoInvalido("O diâmetro da mangueira não é válido.");

            if (tipoMangueira != (int)TipoMangueira.Tipo1 &&
                tipoMangueira != (int)TipoMangueira.Tipo2)
                throw new FormatoInvalido("O tipo da mangueira não é válido.");
        }

        protected void ValidarAtributosCentralAlarme(int tipo)
        {
            if (tipo != (int)TipoCentralAlarme.Analogico &&
                tipo != (int)TipoCentralAlarme.Digital)
                throw new FormatoInvalido("O tipo da central de alarme não é válido.");
        } 

    }
}