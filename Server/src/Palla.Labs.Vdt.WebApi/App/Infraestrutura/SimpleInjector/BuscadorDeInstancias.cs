using SimpleInjector;

namespace Palla.Labs.Vdt.App.Infraestrutura.SimpleInjector
{
    public class BuscadorDeInstancias
    {
        private static Container _container;

        public BuscadorDeInstancias(Container container)
        {
            _container = container;
        }

        public T Buscar<T>() where T : class
        {
            return _container.GetInstance<T>();
        }

        public static T BuscarEstatico<T>() where T : class
        {
            return _container.GetInstance<T>();
        }
    }
}