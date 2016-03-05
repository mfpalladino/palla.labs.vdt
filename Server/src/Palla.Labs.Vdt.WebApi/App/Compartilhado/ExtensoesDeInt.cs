using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Compartilhado
{
    public static class ExtensoesDeInt
    {
        public static bool TipoDeEquipamentoValido(this int valor)
        {
            return valor == (int)TipoEquipamento.CentralAlarme || valor == (int)TipoEquipamento.Extintor || valor == (int)TipoEquipamento.Mangueira || valor == (int)TipoEquipamento.SistemaContraIncendioEmCoifa;
        }

        public static bool ComprimentoMangueiraValido(this int comprimento)
        {
            return comprimento == (int)ComprimentoMangueira.QuinzeMetros || comprimento == (int)ComprimentoMangueira.TrintaMetros || comprimento == (int)ComprimentoMangueira.VinteMetros;
        }

        public static bool DiametroMangueiraValido(this int diametro)
        {
            return diametro == (int)DiametroMangueira.DoisMetrosEMeio || diametro == (int)DiametroMangueira.UmMetroEMeio;
        }

        public static bool TipoMangueiraValido(this int tipoMangueira)
        {
            return tipoMangueira == (int)TipoMangueira.Tipo1 || tipoMangueira == (int)TipoMangueira.Tipo2;
        }

        public static bool TipoCentralAlarmeValido(this int tipoCentralAlarme)
        {
            return tipoCentralAlarme == (int)TipoCentralAlarme.Analogico || tipoCentralAlarme == (int)TipoCentralAlarme.Digital;
        }
    }
}