using Webcast.ModeloDeDominioComORM.Negocio.DominioEF;
using System.Data.Entity.ModelConfiguration;

namespace Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioEF.Map
{
    public class PeriodoMap:EntityTypeConfiguration<Periodo>
    {

        public PeriodoMap()
        {
            Property(periodo => periodo.Inicial)
                .HasColumnName("PeriodoInicio");


            Property(periodo => periodo.Final)
                .HasColumnName("PeriodoFinal");
        }
    }
}
