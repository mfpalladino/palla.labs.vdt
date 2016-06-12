using System;
using Palla.Labs.Vdt.App.Dominio.Dtos;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public interface IValidadorEquipamento
    {
        void Validar(Guid siteId, EquipamentoDto equipamentoDto);

        bool ValidadorDeCriacao { get; }
    }
}