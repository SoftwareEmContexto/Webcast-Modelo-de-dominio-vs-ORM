using Webcast.ModeloDeDominioComORM.Negocio.DominioNH.GerenciamentoDeAnuncio;
using FluentNHibernate.Mapping;
using System;

namespace Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioNH.Map
{
    public class VeiculoMap : ClassMap<Veiculo>
    {
        public VeiculoMap()
        {
            Id(s => s.Id).GeneratedBy.Assigned().UnsavedValue(Guid.Empty).Column("VeiculoId");

            Component(veiculo => veiculo.DetalheDeFabricacao, detalheFabri =>
            {
                detalheFabri.Map(df => df.AnoFabricacao);
                detalheFabri.Map(df => df.AnoModelo);
                detalheFabri.Map(df => df.Marca);
                detalheFabri.Map(df => df.Modelo);
            });

            Component(veiculo => veiculo.Opcionais, opcionais =>
            {
                opcionais.Map(o => o.Itens).Column("Opcionais");
            });

            Component(veiculo => veiculo.Detalhe, detalhe =>
            {
                detalhe.Component(d => d.Cambio, tipoCambio =>
                {
                    tipoCambio.Map(tc => tc.DisplayName).Column("Cambio");
                });

                detalhe.Component(d => d.Carroceria, tipoCarroceria =>
                {
                    tipoCarroceria.Map(tc => tc.DisplayName).Column("Carroceria");
                });

                detalhe.Component(d => d.Combustivel, tipoCombustivel =>
                {
                    tipoCombustivel.Map(tc => tc.DisplayName).Column("Combustivel");
                });

                detalhe.Component(d => d.Cor, tipoCor =>
                {
                    tipoCor.Map(tc => tc.DisplayName).Column("Cor");
                });

                detalhe.Map(d => d.Kilometragem);
                detalhe.Map(d => d.Placa);
                detalhe.Map(d => d.Portas);
                detalhe.Map(d => d.Preco);
            });

            Component(veiculo => veiculo.StatusDePublicacao, status =>
            {
                status.Map(s => s.Value).Column("StatusDePublicacao");
            });


        }
    }
}
