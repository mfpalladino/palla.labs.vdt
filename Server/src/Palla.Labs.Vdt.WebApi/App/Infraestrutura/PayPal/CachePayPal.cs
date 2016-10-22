using System;
using System.Web;
using System.Web.Caching;
using Palla.Labs.Vdt.App.Dominio.Dtos;

namespace Palla.Labs.Vdt.App.Infraestrutura.PayPal
{
    public class CachePayPal //todo rever em caso de cluster
    {
        public void Adicionar(Guid siteId, string token, FaturaDto faturaDto)
        {
            HttpRuntime.Cache.Add(PegaNomeChaveCache(siteId, token), faturaDto, null, 
                DateTime.Now.AddMinutes(40),
                Cache.NoSlidingExpiration,
                CacheItemPriority.High,
                null);
        }

        public void Remover(Guid siteId, string token)
        {
            HttpRuntime.Cache.Remove(PegaNomeChaveCache(siteId, token));
        }

        public FaturaDto Recuperar(Guid siteId, string token)
        {
            return HttpRuntime.Cache[PegaNomeChaveCache(siteId, token)] as FaturaDto;
        }

        private static string PegaNomeChaveCache(Guid siteId, string token)
        {
            return string.Format("{0}_{1}", siteId, token);
        }
    }
}