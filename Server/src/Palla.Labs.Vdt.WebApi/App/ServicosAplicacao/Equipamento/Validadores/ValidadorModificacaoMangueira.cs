using Palla.Labs.Vdt.App.Infraestrutura.Mongo;

// ReSharper disable once CheckNamespace
namespace Palla.Labs.Vdt.App.ServicosAplicacao
{
    public class ValidadorModificacaoMangueira : ValidadorCriacaoMangueira
    {
        public ValidadorModificacaoMangueira(RepositorioClientes repositorioClientes, RepositorioEquipamentos repositorioEquipamentos)
            : base(repositorioClientes, repositorioEquipamentos)
        {
        }

        public override bool ValidadorDeCriacao
        {
            get { return false; }
        }
    }
}