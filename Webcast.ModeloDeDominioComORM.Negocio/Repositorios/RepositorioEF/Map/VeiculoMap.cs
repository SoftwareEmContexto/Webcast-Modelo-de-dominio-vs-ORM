using Webcast.ModeloDeDominioComORM.Negocio.DominioEF.GerenciamentoDeAnuncio;
using System.Data.Entity.ModelConfiguration;

namespace Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioEF.Map
{
    public class VeiculoMap : EntityTypeConfiguration<Veiculo>
    {
        public VeiculoMap()
        {
            HasKey(veiculo => veiculo.Id);

            Property(veiculo => veiculo.Id)
                .HasColumnName("VeiculoId");


            HasRequired(anuncio => anuncio.Anuncio);

            ToTable("Veiculo");

        }
    }
}
