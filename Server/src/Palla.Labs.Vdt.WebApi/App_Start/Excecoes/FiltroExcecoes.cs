using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http.Filters;
using log4net;
using Palla.Labs.Vdt.App.Dominio.Dtos;
using Palla.Labs.Vdt.App.Dominio.Excecoes;

namespace Palla.Labs.Vdt.Excecoes
{
    public class FiltroExcecoes : ExceptionFilterAttribute
    {        
        private readonly IDictionary<Type, HttpStatusCode> _mapeador;

        public FiltroExcecoes()
        {
            _mapeador = ExcecaoParaHttpStatusCode.Dicionario();
        }

        public override void OnException(HttpActionExecutedContext context)
        {
            var logger = LogManager.GetLogger(context.ActionContext.ControllerContext.Controller.GetType());

            var excecao = context.Exception.InnerException ?? context.Exception;

            if (!_mapeador.ContainsKey(excecao.GetType()))
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                logger.Error(logger, context.Exception);
                return; //ATENÇÃO: Quebra de fluxo
            }

            var httpResponseMessage = new HttpResponseMessage(_mapeador[excecao.GetType()]);
            var baseException = excecao as ExcecaoBase;
            if (baseException != null)
            {
                if (baseException.ContainsMessageForApiClient)
                    httpResponseMessage.Content = new ObjectContent(typeof(ResultadoErroDto), 
                        new ResultadoErroDto(baseException.MessageForApiClient), 
                        new JsonMediaTypeFormatter()); //só vamos mandar mensagens que controlamos (e temos certeza do que se trata)
                else
                    httpResponseMessage.Content = new ObjectContent(typeof(ResultadoErroDto),
                        ResultadoErroDto.CriarErroNaoEsperado(),
                        new JsonMediaTypeFormatter());
                            
                logger.Error(logger, context.Exception);
            }
            else
            {
                httpResponseMessage.Content = new ObjectContent(typeof(ResultadoErroDto), 
                    ResultadoErroDto.CriarErroNaoEsperado(), 
                    new JsonMediaTypeFormatter());
                
                logger.Error(context.Exception.Message, context.Exception);
            }

            context.Response = httpResponseMessage;
        }
    }
}