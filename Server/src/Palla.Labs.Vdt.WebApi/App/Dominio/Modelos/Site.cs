using System;
using Palla.Labs.Vdt.App.Dominio.Excecoes;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class Site : EntidadeBase<Guid>
    {
        private readonly string _nome;
        private readonly string _email;
        private readonly bool _estaAtivo;
        private readonly int _diaVencimento;
        private readonly decimal _valorPorEquipamento;
        private readonly decimal _valorPorUsuario;

        public Site(Guid id, string nome, string email, bool estaAtivo, int diaVencimento, decimal valorPorEquipamento, decimal valorPorUsuario)
            : base(id)
        {
            _nome = nome;
            _email = email;
            _estaAtivo = estaAtivo;
            _diaVencimento = diaVencimento;
            _valorPorEquipamento = valorPorEquipamento;
            _valorPorUsuario = valorPorUsuario;

            Validar();
        }

        public string Nome
        {
            get { return _nome; }
        }

        public string Email
        {
            get { return _email; }
        }

        public bool EstaAtivo
        {
            get { return _estaAtivo; }
        }

        public int DiaVencimento
        {
            get { return _diaVencimento; }
        }

        public decimal ValorPorEquipamento
        {
            get { return _valorPorEquipamento; }
        }

        public decimal ValorPorUsuario
        {
            get { return _valorPorUsuario; }
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new FormatoInvalido("O nome do site deve ser informado.");

            if (Nome.Length > 50)
                throw new FormatoInvalido("O nome do site não pode ter mais de 50 caracteres.");

            if (DiaVencimento < 1 || DiaVencimento > 30)
                throw new FormatoInvalido("O dia do vencimento não é válido.");
        }
    }
}