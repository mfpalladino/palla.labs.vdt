using System;
using Palla.Labs.Vdt.App.Dominio.Excecoes;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class Cliente : EntidadeBase<Guid>
    {
        private readonly string _nome;
        private readonly Guid _siteId;
        private readonly Cnpj _cnpj;
        private readonly string _codigo;
        private readonly Endereco _endereco;
        private readonly CorreioEletronico _correioEletronicoLoja;
        private readonly CorreioEletronico _correioEletronicoManutencao;
        private readonly CorreioEletronico _correioEletronicoAdministracao;
        private readonly Guid _grupoId;

        protected Cliente() //usado apenas para mapeamento e testes
        {
        }

        public Cliente(
            Guid siteId,
            Guid grupoId,
            Cnpj cnpj,
            string nome, 
            string codigo, 
            Endereco endereco,
            CorreioEletronico correioEletronicoLoja,
            CorreioEletronico correioEletronicoManutencao,
            CorreioEletronico correioEletronicoAdministracao)
            : this(siteId, Guid.NewGuid(), grupoId, cnpj, nome, codigo, endereco, correioEletronicoLoja, correioEletronicoManutencao, correioEletronicoAdministracao)
        {
        }

        public Cliente(
            Guid siteId,
            Guid id,
            Guid grupoId,
            Cnpj cnpj,
            string nome, 
            string codigo, 
            Endereco endereco,
            CorreioEletronico correioEletronicoLoja,
            CorreioEletronico correioEletronicoManutencao,
            CorreioEletronico correioEletronicoAdministracao):base(id)
        {
            _siteId = siteId;
            _grupoId = grupoId;
            _cnpj = cnpj;
            _nome = nome;
            _codigo = codigo;
            _endereco = endereco;
            _correioEletronicoLoja = correioEletronicoLoja;
            _correioEletronicoManutencao = correioEletronicoManutencao;
            _correioEletronicoAdministracao = correioEletronicoAdministracao;

            Validar();
        }

        public Guid SiteId
        {
            get { return _siteId; }
        }

        public string Nome
        {
            get { return _nome; }
        }

        public Cnpj Cnpj
        {
            get { return _cnpj; }
        }

        public string Codigo
        {
            get { return _codigo; }
        }

        public Guid GrupoId
        {
            get { return _grupoId; }
        }

        public Endereco Endereco
        {
            get { return _endereco; }
        }

        public CorreioEletronico CorreioEletronicoLoja
        {
            get { return _correioEletronicoLoja; }
        }

        public CorreioEletronico CorreioEletronicoManutencao
        {
            get { return _correioEletronicoManutencao; }
        }

        public CorreioEletronico CorreioEletronicoAdministracao
        {
            get { return _correioEletronicoAdministracao; }
        }

        private void Validar()
        {
            if (String.IsNullOrWhiteSpace(Nome))
                throw new FormatoInvalido("O nome do cliente deve ser informado.");

            if (Nome.Length > 100)
                throw new FormatoInvalido("O nome do cliente não pode ter mais de 100 caracteres.");

            if (String.IsNullOrWhiteSpace(Codigo))
                throw new FormatoInvalido("O código do cliente deve ser informado.");

            if (Codigo.Length > 20)
                throw new FormatoInvalido("O código do cliente não pode ter mais de 20 caracteres.");

            if (GrupoId == Guid.Empty)
                throw new FormatoInvalido("O código do grupo deve ser informado.");

            Cnpj.Validar();
            Endereco.Validar();
            CorreioEletronicoLoja.Validar("loja");
            CorreioEletronicoAdministracao.Validar("administração");
            CorreioEletronicoManutencao.Validar("manutenção");
        }
    }
}