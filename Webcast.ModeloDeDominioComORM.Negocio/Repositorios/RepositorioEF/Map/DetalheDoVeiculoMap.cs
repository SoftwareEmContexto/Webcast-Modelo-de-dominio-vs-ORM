
using Webcast.ModeloDeDominioComORM.Negocio.DominioEF;
using Webcast.ModeloDeDominioComORM.Negocio.NucleoCompartilhado.Enums;
using System.Data.Entity.ModelConfiguration;

namespace Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioEF.Map
{
    public class DetalheDoVeiculoMap:ComplexTypeConfiguration<DetalheDoVeiculo>
    {
        public DetalheDoVeiculoMap()
        {
            Property(detalheVei => detalheVei.Kilometragem)
                .HasColumnName("Kilometragem");

            Property(detalheVei => detalheVei.Portas)
                .HasColumnName("Portas");

            Property(detalheVei => detalheVei.Preco)
                .HasColumnName("Preco"); 

            Property(detalheVei => detalheVei.Placa)
                .HasColumnName("Placa")
                .HasColumnType("varchar")
                .HasMaxLength(8);

        }
    }

    public class CambioMap : ComplexTypeConfiguration<TipoDoCambio>
    {
        public CambioMap()
        {
            Ignore(cambio => cambio.Value);
            Property(cambio => cambio.DisplayName)
                .HasColumnName("Cambio")
                .HasColumnType("varchar")
                .HasMaxLength(50);
        }
    }

    public class CarroceriaMap : ComplexTypeConfiguration<TipoDaCarroceria>
    {
        public CarroceriaMap()
        {
            Ignore(carroceria => carroceria.Value);
            Property(carroceria => carroceria.DisplayName)
                .HasColumnName("Carroceria")
                .HasColumnType("varchar")
                .HasMaxLength(50);
        }
    }

    public class CombustivelMap : ComplexTypeConfiguration<TipoDeCombustivel>
    {
        public CombustivelMap()
        {
            Ignore(combustivel=> combustivel.Value);
            Property(combustivel => combustivel.DisplayName)
                .HasColumnName("Combustivel")
                .HasColumnType("varchar")
                .HasMaxLength(50);
        }
    }

    public class CorMap : ComplexTypeConfiguration<Cor>
    {
        public CorMap()
        {
            Ignore(cor => cor.Value);
            Property(cor => cor.DisplayName)
                .HasColumnName("Cor")
                .HasColumnType("varchar")
                .HasMaxLength(50);
        }
    }

    public class StatusPublicacaoMap : ComplexTypeConfiguration<StatusPublicacao>
    {
        public StatusPublicacaoMap()
        {
            Ignore(status => status.Value);
            Property(status => status.DisplayName)
                .HasColumnName("StatusDePublicacao")
                .HasColumnType("varchar")
                .HasMaxLength(50);
        }
    }
}
