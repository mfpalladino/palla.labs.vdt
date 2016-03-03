using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using Newtonsoft.Json;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Excecoes;
using Palla.Labs.Vdt.App.Dominio.Modelos;

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
            var contentData = content.Result;

            var equipamentoBase = JsonConvert.DeserializeObject<EquipamentoDto>(contentData);

            switch (equipamentoBase.Tipo)
            {
                case (int)TipoEquipamento.Extintor:
                    _bindingContext.Model = JsonConvert.DeserializeObject<ExtintorDto>(contentData);
                    break;
                case (int)TipoEquipamento.Mangueira:
                    _bindingContext.Model = JsonConvert.DeserializeObject<MangueiraDto>(contentData);
                    break;
                case (int)TipoEquipamento.CentralAlarme:
                    _bindingContext.Model = JsonConvert.DeserializeObject<CentralAlarmeDto>(contentData);
                    break;
                case (int)TipoEquipamento.SistemaContraIncendioEmCoifa:
                    _bindingContext.Model = JsonConvert.DeserializeObject<SistemaContraIncendioEmCoifaDto>(contentData);
                    break;
                default:
                    throw new FormatoInvalido("O tipo do equipamento não é válido.");
            }
        }
    }
}