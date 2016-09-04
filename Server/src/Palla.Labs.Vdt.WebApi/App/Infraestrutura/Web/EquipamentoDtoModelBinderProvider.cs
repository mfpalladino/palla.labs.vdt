using System;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Palla.Labs.Vdt.App.Infraestrutura.Web
{
    public class EquipamentoDtoModelBinderProvider : ModelBinderProvider
    {
        public override IModelBinder GetBinder(HttpConfiguration configuration, Type modelType)
        {
            return new EquipamentoDtoModelBinder();
        }
    }
}