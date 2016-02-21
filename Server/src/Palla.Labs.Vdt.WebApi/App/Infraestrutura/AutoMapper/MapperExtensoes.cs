using System;
using AutoMapper;
using Palla.Labs.Vdt.App.Dominio.Modelos;
using Palla.Labs.Vdt.App.ServicosAplicacao.Dtos;

namespace Palla.Labs.Vdt.App.Infraestrutura.AutoMapper
{
    public static class MapperExtensoes
    {
        public static T ParaEntidade<T, TY>(this IMapper mapper, Guid id, TY dto) 
            where T : EntidadeBase<Guid> 
            where TY: DtoBase<Guid>
        {
            var entidade = mapper.Map<T>(dto);
            entidade.ConfigurarId(id);
            return entidade;
        }

        public static T ParaEntidade<T, TY>(this IMapper mapper, TY dto) 
            where T : EntidadeBase<Guid>
            where TY : DtoBase<Guid>
        {
            if (dto.Id == Guid.Empty)
                dto.Id = Guid.NewGuid();

            var entidade = mapper.Map<T>(dto);
            return entidade;
        }

        public static TY ParaDto<TY, T>(this IMapper mapper, T entidade)
            where TY : DtoBase<Guid>
            where T : EntidadeBase<Guid>
        {
            var dto = mapper.Map<TY>(entidade);
            return dto;
        }
    }
}