using System.Linq;
using MongoDB.Bson.Serialization;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public static class ConfiguraMongo
    {
        public static void Configurar()
        {
            BsonClassMap.RegisterClassMap<Equipamento>(cm =>
            {
                cm.SetIsRootClass(true);
                cm.MapIdField(c => c.Id);
                cm.MapField(c => c.ClienteId);
                cm.MapField(c => c.Tipo);
                cm.MapField(c => c.Manutencoes);
                cm.UnmapMember(c => c.ParametrosManutencao);
            });

            BsonClassMap.RegisterClassMap<Extintor>(cm =>
            {
                cm.MapCreator(x => new Extintor(x.Id, x.ClienteId, x.NumeroCilindro, x.Agente, x.Localizacao, x.FabricadoEm, x.Manutencoes.ToList()));
                cm.MapField(c => c.Agente);
                cm.MapField(c => c.FabricadoEm);
                cm.MapField(c => c.Localizacao);
                cm.MapField(c => c.NumeroCilindro);
            });

            BsonClassMap.RegisterClassMap<Mangueira>(cm =>
            {
                cm.MapCreator(x => new Mangueira(x.Id, x.ClienteId, x.TipoMangueira, x.Diametro, x.Comprimento, x.Manutencoes.ToList()));
                cm.MapField(c => c.Comprimento);
                cm.MapField(c => c.Diametro);
                cm.MapField(c => c.TipoMangueira);
            });

            BsonClassMap.RegisterClassMap<SistemaContraIncendioEmCoifa>(cm =>
            {
                cm.MapCreator(x => new SistemaContraIncendioEmCoifa(x.Id, x.ClienteId, x.Central, x.QuantidadeCilindroCo2, x.PesoCilindroCo2, x.QuantidadeCilindroSaponificante, x.Manutencoes.ToList()));
                cm.MapField(c => c.Central);
                cm.MapField(c => c.QuantidadeCilindroCo2);
                cm.MapField(c => c.PesoCilindroCo2);
                cm.MapField(c => c.QuantidadeCilindroSaponificante);
            });

            BsonClassMap.RegisterClassMap<CentralAlarme>(cm =>
            {
                cm.MapCreator(x => new CentralAlarme(x.Id, x.ClienteId, x.Fabricante, x.Modelo, x.TipoCentralAlarme, x.QuantidadeDetectores, x.DetectorEnderecavel, x.QuantidadeAcionadores, x.QuantidadeSirenes, x.Manutencoes.ToList()));
                cm.MapField(c => c.DetectorEnderecavel);
                cm.MapField(c => c.Fabricante);
                cm.MapField(c => c.Modelo);
                cm.MapField(c => c.QuantidadeAcionadores);
                cm.MapField(c => c.QuantidadeDetectores);
                cm.MapField(c => c.QuantidadeSirenes);
                cm.MapField(c => c.TipoCentralAlarme);
            });

            BsonClassMap.RegisterClassMap<Manutencao>(cm =>
            {
                cm.MapCreator(x => new Manutencao(x.Data, x.Parte));
                cm.MapField(c => c.Data);
                cm.MapField(c => c.Parte);
            });

            BsonClassMap.RegisterClassMap<Grupo>(cm =>
            {
                cm.MapCreator(x => new Grupo(x.Id, x.Nome));
                cm.MapIdField(c => c.Id);
                cm.MapField(c => c.Nome);
            });

            BsonClassMap.RegisterClassMap<Endereco>(cm =>
            {
                cm.MapCreator(x => new Endereco(x.Logradouro, x.Numero, x.Complemento, x.Bairro, x.Cidade, x.Estado, x.Cep));
                cm.MapField(c => c.Logradouro);
                cm.MapField(c => c.Numero);
                cm.MapField(c => c.Complemento);
                cm.MapField(c => c.Bairro);
                cm.MapField(c => c.Cidade);
                cm.MapField(c => c.Estado);
                cm.MapField(c => c.Cep);
            });

            BsonClassMap.RegisterClassMap<CorreioEletronico>(cm =>
            {
                cm.MapCreator(x => new CorreioEletronico(x.Endereco));
                cm.MapField(c => c.Endereco);
            });

            BsonClassMap.RegisterClassMap<Cnpj>(cm =>
            {
                cm.MapCreator(x => new Cnpj(x.Numero));
                cm.MapField(c => c.Numero);
            });

            BsonClassMap.RegisterClassMap<Cliente>(cm =>
            {
                cm.MapCreator(x => new Cliente(x.Id, x.GrupoId, x.Cnpj, x.Nome, x.Codigo, x.Endereco, x.CorreioEletronicoLoja, x.CorreioEletronicoManutencao, x.CorreioEletronicoAdministracao));
                cm.MapIdField(c => c.Id);
                cm.MapField(c => c.GrupoId);
                cm.MapField(c => c.Cnpj);
                cm.MapField(c => c.Nome);
                cm.MapField(c => c.Codigo);
                cm.MapField(c => c.Endereco);
                cm.MapField(c => c.CorreioEletronicoLoja);
                cm.MapField(c => c.CorreioEletronicoManutencao);
                cm.MapField(c => c.CorreioEletronicoAdministracao);
            });
        }
    }
}