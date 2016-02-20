using System;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public class Cliente
    {
        private readonly Guid _id;
        private readonly string _nome;
        private readonly Cnpj _cnpj;
        private readonly string _codigo;
        private readonly Endereco _endereco;
        private readonly CorreioEletronico _correioEletronicoLoja;
        private readonly CorreioEletronico _correioEletronicoManutencao;
        private readonly CorreioEletronico _correioEletronicoAdministracao;
        private readonly Guid _grupoId;

        public Cliente(
            Guid grupoId,
            Cnpj cnpj,
            string nome, 
            string codigo, 
            Endereco endereco,
            CorreioEletronico correioEletronicoLoja,
            CorreioEletronico correioEletronicoManutencao,
            CorreioEletronico correioEletronicoAdministracao)
            : this(Guid.NewGuid(), grupoId, cnpj, nome, codigo, endereco, correioEletronicoLoja, correioEletronicoManutencao, correioEletronicoAdministracao)
        {
        }

        public Cliente(Guid id,
            Guid grupoId,
            Cnpj cnpj,
            string nome, 
            string codigo, 
            Endereco endereco,
            CorreioEletronico correioEletronicoLoja,
            CorreioEletronico correioEletronicoManutencao,
            CorreioEletronico correioEletronicoAdministracao)
        {
            _id = id;
            _grupoId = grupoId;
            _cnpj = cnpj;
            _nome = nome;
            _codigo = codigo;
            _endereco = endereco;
            _correioEletronicoLoja = correioEletronicoLoja;
            _correioEletronicoManutencao = correioEletronicoManutencao;
            _correioEletronicoAdministracao = correioEletronicoAdministracao;
        }

        public Guid Id
        {
            get { return _id; }
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
    }
}