using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http.Filters;
using log4net;
using Palla.Labs.Vdt.App.Domain.Exceptions;
using Palla.Labs.Vdt.App.Domain.Exceptions.HttpStatusCodeMapper;
using Palla.Labs.Vdt.App.Domain.Model;

namespace Palla.Labs.Vdt.ExceptionsPolicy
{
    public class DomainExceptionToHttpStatusCodeFilter : ExceptionFilterAttribute
    {        
        private readonly IDictionary<Type, HttpStatusCode> _fromTo;

        public DomainExceptionToHttpStatusCodeFilter()
        {
            _fromTo = DomainExceptionHttpStatusCodeMapper.DomainExceptionToHttpStatusCodeDictionary();
        }

        public override void OnException(HttpActionExecutedContext context)
        {
            var logger = LogManager.GetLogger(context.ActionContext.ControllerContext.Controller.GetType());

            if (!_fromTo.ContainsKey(context.Exception.GetType()))
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                logger.Error(logger, context.Exception);
                return; //ATENÇÃO: Quebra de fluxo
            }

            var httpResponseMessage = new HttpResponseMessage(_fromTo[context.Exception.GetType()]);
            var baseException = context.Exception as BaseException;
            if (baseException != null)
            {
                if (baseException.ContainsMessageForApiClient)
                    httpResponseMessage.Content = new ObjectContent(typeof(ErrorResult), 
                        new ErrorResult(baseException.MessageForApiClient), 
                        new JsonMediaTypeFormatter()); //só vamos mandar mensagens que controlamos (e temos certeza do que se trata)
                else
                    httpResponseMessage.Content = new ObjectContent(typeof(ErrorResult),
                        ErrorResult.CreateNotUnmappedError(),
                        new JsonMediaTypeFormatter());
                            
                logger.Error(logger, context.Exception);
            }
            else
            {
                httpResponseMessage.Content = new ObjectContent(typeof(ErrorResult), 
                    ErrorResult.CreateNotUnmappedError(), 
                    new JsonMediaTypeFormatter());
                
                logger.Error(context.Exception.Message, context.Exception);
            }

            context.Response = httpResponseMessage;
        }
    }
}