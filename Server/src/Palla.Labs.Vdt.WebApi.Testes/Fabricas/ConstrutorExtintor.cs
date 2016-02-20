using System;
using System.Collections.Generic;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.WebApi.Testes.Fabricas
{
    public class ConstrutorExtintor
    {
        private readonly List<Manutencao> _manutencoes = new List<Manutencao>();

        public ConstrutorExtintor ComManutencao(DateTime data)
        {
            _manutencoes.Add(new Manutencao(data, ParteEquipamento.EXTINTOR));
            return this;
        }

        public Extintor Construir()
        {
            return new Extintor(Guid.NewGuid(), "111", "agente", "localização", DateTime.Now, _manutencoes); 
        }
    }
}
