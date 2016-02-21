
namespace Palla.Labs.Vdt.App.Dominio.Modelos
{
    public abstract class EntidadeBase<T>
    {
        private T _id;

        protected EntidadeBase() //apenas para testes
        {
            
        }

        protected EntidadeBase(T id)
        {
            _id = id;
        }

        public T Id
        {
            get { return _id; }
        }

        public void ConfigurarId(T id)
        {
            _id = id;
        }

        public override bool Equals(object outroObjeto)
        {
            var entidade = outroObjeto as EntidadeBase<T>;
            return entidade != null ? Equals(entidade) : base.Equals(outroObjeto);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool Equals(EntidadeBase<T> outro)
        {
            return outro != null && Id.Equals(outro.Id);
        }
    }
}