using System;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Infraestrutura.Mvc
{
    public class EquipamentoDtoModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var type = bindingContext.ModelName + "." + "tipo";

            Type typeToInstantiate;

            switch ((TipoEquipamento)bindingContext.ValueProvider.GetValue(type).RawValue)
            {
                case TipoEquipamento.Extintor:
                    {
                        typeToInstantiate = typeof(ExtintorDto);

                        return true;
                    }
                case TipoEquipamento.Mangueira:
                    {
                        typeToInstantiate = typeof(MangueiraDto);
                        return true;
                    }
                case TipoEquipamento.CentralAlarme:
                    {
                        typeToInstantiate = typeof(CentralAlarmeDto);
                        return true;
                    }
                case TipoEquipamento.SistemaContraIncendioEmCoifa:
                    {
                        typeToInstantiate = typeof(SistemaContraIncendioEmCoifaDto);
                        return true;
                    }
                default:
                    {
                        throw new Exception("O equipamento não pode funcionar no model binder conforme seu tipo.");
                    }
            }
        }
    }
}