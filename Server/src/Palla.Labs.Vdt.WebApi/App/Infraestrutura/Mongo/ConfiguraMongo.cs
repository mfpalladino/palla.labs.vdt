using System;
using System.Linq;
using MongoDB.Bson.Serialization;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public static class ConfiguraMongo
    {
        public static void Configurar()
        {
            BsonClassMap.RegisterClassMap<EntidadeBase<Guid>>(cm =>
            {
                cm.MapIdField(c => c.Id);
            });

            BsonClassMap.RegisterClassMap<Fatura>(cm =>
            {
                cm.MapCreator(x => new Fatura(x.SiteId, x.Mes, x.Mes, x.QuantidadeEquipamentos, x.ValorPorEquipamento, x.QuantidadeUsuarios, x.ValorPorUsuario, x.Descontos, x.Total));
                cm.MapField(c => c.SiteId);
                cm.MapField(c => c.Mes);
                cm.MapField(c => c.Ano);
                cm.MapField(c => c.QuantidadeEquipamentos);
                cm.MapField(c => c.ValorPorEquipamento);
                cm.MapField(c => c.QuantidadeUsuarios);
                cm.MapField(c => c.ValorPorUsuario);
                cm.MapField(c => c.Descontos);
                cm.MapField(c => c.Total);
            });

            BsonClassMap.RegisterClassMap<Site>(cm =>
            {
                cm.MapCreator(x => new Site(x.Id, x.Nome));
                cm.MapCreator(x => new Site(x.Id, x.Nome, x.EstaAtivo));
                cm.MapCreator(x => new Site(x.Id, x.Nome, x.EstaAtivo, x.DiaVencimento));
                cm.MapField(c => c.Nome);
                cm.MapField(c => c.EstaAtivo);
                cm.MapField(c => c.DiaVencimento);
            });

            BsonClassMap.RegisterClassMap<Usuario>(cm =>
            {
                cm.MapCreator(x => new Usuario(x.SiteId, x.Id, x.Nome, x.Senha, x.TipoUsuario, x.Grupos));
                cm.MapCreator(x => new Usuario(x.SiteId, x.Id, x.Nome, x.Senha, x.TipoUsuario, x.Grupos, x.EstaAtivo));
                cm.MapCreator(x => new Usuario(x.SiteId, x.Id, x.Nome, x.Senha));
                cm.MapCreator(x => new Usuario(x.SiteId, x.Id, x.Nome, x.Senha, x.EstaAtivo));
                cm.MapField(c => c.SiteId);
                cm.MapField(c => c.Nome);
                cm.MapField(c => c.Senha);
                cm.MapField(c => c.TipoUsuario);
                cm.MapField(c => c.Grupos);
                cm.MapField(c => c.EstaAtivo);
            });

            ConfigurarEquipamentos();
            ConfigurarClientes();
        }

        private static void ConfigurarEquipamentos()
        {
            BsonClassMap.RegisterClassMap<Equipamento>(cm =>
            {
                cm.SetIsRootClass(true);
                cm.MapField(c => c.SiteId);
                cm.MapField(c => c.ClienteId);
                cm.MapField(c => c.Tipo);
                cm.MapField(c => c.Manutencoes);
                cm.MapField(c => c.EstaAtivo);
                cm.UnmapMember(c => c.ParametrosManutencao);
            });

            BsonClassMap.RegisterClassMap<Extintor>(cm =>
            {
                cm.MapCreator(x => new Extintor(x.SiteId, x.Id, x.ClienteId, x.NumeroCilindro, x.Agente, x.Localizacao, x.FabricadoEm, x.Manutencoes.ToList(), x.EstaAtivo));
                cm.MapCreator(x => new Extintor(x.SiteId, x.Id, x.ClienteId, x.NumeroCilindro, x.Agente, x.Localizacao, x.FabricadoEm, x.Manutencoes.ToList()));
                cm.MapField(c => c.Agente);
                cm.MapField(c => c.FabricadoEm);
                cm.MapField(c => c.Localizacao);
                cm.MapField(c => c.NumeroCilindro);
            });

            BsonClassMap.RegisterClassMap<Mangueira>(cm =>
            {
                cm.MapCreator(x => new Mangueira(x.SiteId, x.Id, x.ClienteId, x.TipoMangueira, x.Diametro, x.Comprimento, x.Manutencoes.ToList(), x.EstaAtivo));
                cm.MapCreator(x => new Mangueira(x.SiteId, x.Id, x.ClienteId, x.TipoMangueira, x.Diametro, x.Comprimento, x.Manutencoes.ToList()));
                cm.MapField(c => c.Comprimento);
                cm.MapField(c => c.Diametro);
                cm.MapField(c => c.TipoMangueira);
            });

            BsonClassMap.RegisterClassMap<SistemaContraIncendioEmCoifa>(cm =>
            {
                cm.MapCreator(x => new SistemaContraIncendioEmCoifa(x.SiteId, x.Id, x.ClienteId, x.Central, x.QuantidadeCilindroCo2, x.PesoCilindroCo2, x.QuantidadeCilindroSaponificante, x.Manutencoes.ToList(), x.EstaAtivo));
                cm.MapCreator(x => new SistemaContraIncendioEmCoifa(x.SiteId, x.Id, x.ClienteId, x.Central, x.QuantidadeCilindroCo2, x.PesoCilindroCo2, x.QuantidadeCilindroSaponificante, x.Manutencoes.ToList()));
                cm.MapField(c => c.Central);
                cm.MapField(c => c.QuantidadeCilindroCo2);
                cm.MapField(c => c.PesoCilindroCo2);
                cm.MapField(c => c.QuantidadeCilindroSaponificante);
            });

            BsonClassMap.RegisterClassMap<CentralAlarme>(cm =>
            {
                cm.MapCreator(x => new CentralAlarme(x.SiteId, x.Id, x.ClienteId, x.Fabricante, x.Modelo, x.TipoCentralAlarme, x.QuantidadeDetectores, x.DetectorEnderecavel, x.QuantidadeAcionadores, x.QuantidadeSirenes, x.Manutencoes.ToList(), x.EstaAtivo));
                cm.MapCreator(x => new CentralAlarme(x.SiteId, x.Id, x.ClienteId, x.Fabricante, x.Modelo, x.TipoCentralAlarme, x.QuantidadeDetectores, x.DetectorEnderecavel, x.QuantidadeAcionadores, x.QuantidadeSirenes, x.Manutencoes.ToList()));
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
        }

        private static void ConfigurarClientes()
        {
            BsonClassMap.RegisterClassMap<Grupo>(cm =>
            {
                cm.MapCreator(x => new Grupo(x.SiteId, x.Id, x.Nome));
                cm.MapField(c => c.Nome);
                cm.MapField(c => c.SiteId);
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
                cm.MapCreator(x => new Cliente(x.SiteId, x.Id, x.GrupoId, x.Cnpj, x.Nome, x.Codigo, x.Endereco, x.CorreioEletronicoLoja, x.CorreioEletronicoManutencao, x.CorreioEletronicoAdministracao));
                cm.MapField(c => c.SiteId);
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