using System.Collections.Generic;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.WebApi.Testes.Fabricas
{
    public class ConstrutorMangueira
    {
        public Mangueira Construir()
        {
            return new Mangueira(TipoMangueira.Tipo1, DiametroMangueira.DoisMetrosEMeio, ComprimentoMangueira.TrintaMetros, new List<Manutencao>());
        }
    }
}