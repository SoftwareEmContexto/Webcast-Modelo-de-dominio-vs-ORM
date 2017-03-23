using Webcast.ModeloDeDominioComORM.Negocio.DominioEF.GerenciamentoDeAnuncio;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioEF.Map
{
    public class AnuncioMap : EntityTypeConfiguration<Anuncio>
    {

        public AnuncioMap()
        {
            HasKey(anuncio => anuncio.Id);

            Property(anuncio => anuncio.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasColumnName("AnuncioId");

            Property(anuncio => anuncio.AnuncianteId);

            Property(anuncio => anuncio.DataDePublicacao);


            ToTable(@"Anuncio");
        }
    }
}
