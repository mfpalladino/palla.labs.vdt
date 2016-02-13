﻿using System.Linq;
using MongoDB.Bson.Serialization;
using Palla.Labs.Vdt.App.Dominio.Modelos;

namespace Palla.Labs.Vdt.App.Infraestrutura.Mongo
{
    public static class Registrador
    {
        public static void EfetuarRegistros()
        {
            BsonClassMap.RegisterClassMap<Equipamento>(cm =>
            {
                cm.SetIsRootClass(true);
                cm.MapIdField(c => c.Id);
                cm.MapField(c => c.Tipo);
                cm.MapField(c => c.Manutencoes);
                cm.UnmapMember(c => c.ParametrosManutencao);
            });

            BsonClassMap.RegisterClassMap<Extintor>(cm =>
            {
                cm.MapCreator(x => new Extintor(x.Id, x.NumeroCilindro, x.Agente, x.Localizacao, x.FabricadoEm, x.Manutencoes.ToList()));
                cm.MapField(c => c.Agente);
                cm.MapField(c => c.FabricadoEm);
                cm.MapField(c => c.Localizacao);
                cm.MapField(c => c.NumeroCilindro);
            });

            BsonClassMap.RegisterClassMap<Mangueira>(cm =>
            {
                cm.MapCreator(x => new Mangueira(x.Id, x.TipoMangueira, x.Diametro, x.Comprimento, x.Manutencoes.ToList()));
                cm.MapField(c => c.Comprimento);
                cm.MapField(c => c.Diametro);
                cm.MapField(c => c.TipoMangueira);
            });

            BsonClassMap.RegisterClassMap<SistemaContraIncendioEmCoifa>(cm =>
            {
                cm.MapCreator(x => new SistemaContraIncendioEmCoifa(x.Id, x.Central, x.QuantidadeCilindroCo2, x.PesoCilindroCo2, x.QuantidadeCilindroSaponificante, x.Manutencoes.ToList()));
                cm.MapField(c => c.Central);
                cm.MapField(c => c.QuantidadeCilindroCo2);
                cm.MapField(c => c.PesoCilindroCo2);
                cm.MapField(c => c.QuantidadeCilindroSaponificante);
            });

            BsonClassMap.RegisterClassMap<CentralAlarme>(cm =>
            {
                cm.MapCreator(x => new CentralAlarme(x.Id, x.Fabricante, x.Modelo, x.TipoCentralAlarme, x.QuantidadeDetectores, x.DetectorEnderecavel, x.QuantidadeAcionadores, x.QuantidadeSirenes, x.Manutencoes.ToList()));
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
    }
}