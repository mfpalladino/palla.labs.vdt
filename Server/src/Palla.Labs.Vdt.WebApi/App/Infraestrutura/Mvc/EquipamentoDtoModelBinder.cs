using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using Newtonsoft.Json;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Fabricas;
using Palla.Labs.Vdt.App.Infraestrutura.Json;
using Palla.Labs.Vdt.App.Infraestrutura.SimpleInjector;

namespace Palla.Labs.Vdt.App.Infraestrutura.Mvc
{
    public class EquipamentoDtoModelBinder : IModelBinder
    {
        private ModelBindingContext _bindingContext;

        public bool BindModel(HttpActionContext actionContext, ModelBindingContext
            bindingContext)
        {
            _bindingContext = bindingContext;
            actionContext.Request.Content.ReadAsStringAsync().ContinueWith(Deserializar).Wait();
            return true;
        }

        private void Deserializar(Task<string> content)
        {
            var json = content.Result;

            var equipamentoBase = JsonConvert.DeserializeObject<EquipamentoDto>(json);
            _bindingContext.Model = new FabricaEquipamentoDto(BuscadorDeInstancias.BuscarEstatico<ConversorDeJson>()).Criar(equipamentoBase.Tipo, json);
        }
    }
}