using System;

namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class Fatura : EntidadeBase<Guid>
    {
        private readonly Guid _siteId;
        private readonly int _mes;
        private readonly int _ano;
        private readonly int _quantidadeEquipamentos;
        private readonly decimal _valorPorEquipamento;
        private readonly int _quantidadeUsuarios;
        private readonly decimal _valorPorUsuario;
        private readonly decimal _descontos;
        private readonly decimal _total;

        public Fatura(Guid siteId, int mes, int ano, int quantidadeEquipamentos, decimal valorPorEquipamento, int quantidadeUsuarios, decimal valorPorUsuario,
            decimal descontos, decimal total)
            : this(Guid.NewGuid(), siteId, mes, ano, quantidadeEquipamentos, valorPorEquipamento, quantidadeUsuarios, valorPorUsuario, descontos, total)
        {
        }

        public Fatura(Guid id, Guid siteId, int mes, int ano, int quantidadeEquipamentos, decimal valorPorEquipamento,
            int quantidadeUsuarios, decimal valorPorUsuario,
            decimal descontos, decimal total)
            : base(id)
        {
            _siteId = siteId;
            _mes = mes;
            _ano = ano;
            _quantidadeEquipamentos = quantidadeEquipamentos;
            _valorPorEquipamento = valorPorEquipamento;
            _quantidadeUsuarios = quantidadeUsuarios;
            _valorPorUsuario = valorPorUsuario;
            _descontos = descontos;
            _total = total;
        }

        public Guid SiteId
        {
            get { return _siteId; }
        }

        public int Mes
        {
            get { return _mes; }
        }

        public int Ano
        {
            get { return _ano; }
        }

        public int QuantidadeEquipamentos
        {
            get { return _quantidadeEquipamentos; }
        }

        public decimal ValorPorEquipamento
        {
            get { return _valorPorEquipamento; }
        }

        public int QuantidadeUsuarios
        {
            get { return _quantidadeUsuarios; }
        }

        public decimal ValorPorUsuario
        {
            get { return _valorPorUsuario; }
        }

        public decimal Descontos
        {
            get { return _descontos; }
        }

        public decimal Total
        {
            get { return _total; }
        }

        public decimal TotalPorEquipamento
        {
            get { return QuantidadeEquipamentos * ValorPorEquipamento; }
        }

        public decimal TotalPorUsuario
        {
            get { return QuantidadeUsuarios * ValorPorUsuario; }
        }
        
    }
}