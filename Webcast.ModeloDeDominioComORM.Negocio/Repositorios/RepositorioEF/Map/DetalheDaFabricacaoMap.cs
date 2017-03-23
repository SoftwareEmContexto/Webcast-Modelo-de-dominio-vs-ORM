using Webcast.ModeloDeDominioComORM.Negocio.DominioEF;
using System.Data.Entity.ModelConfiguration;

namespace Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioEF.Map
{
    public class DetalheDaFabricacaoMap:ComplexTypeConfiguration<DetalheDeFabricacao>
    {

        public DetalheDaFabricacaoMap()
        {
            Property(detalheFab => detalheFab.AnoFabricacao)
                .HasColumnName("AnoFabricacao");

            Property(detalheFab => detalheFab.AnoModelo)
                .HasColumnName("AnoModelo");

            Property(detalheFab => detalheFab.Marca)
                .HasColumnName("Marca")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            Property(detalheFab => detalheFab.Modelo)
                .HasColumnName("Modelo")
                .HasColumnType("varchar")
                .HasMaxLength(100);

            
        }
    }
}
