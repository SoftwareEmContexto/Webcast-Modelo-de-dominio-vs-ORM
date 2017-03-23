using Webcast.ModeloDeDominioComORM.Negocio.DominioEF.GerenciamentoDeAnunciante;
using System.Data.Entity.ModelConfiguration;

namespace Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioEF.Map
{
    public class AnuncianteMap:EntityTypeConfiguration<Anunciante>
    {
        public AnuncianteMap()
        {
            HasKey(anunciante => anunciante.Id);
            Property(anunciante => anunciante.Id)
                .HasColumnName("AnuncianteId");

           
            ToTable("Anunciante","dbo");      
                
        }
    }
}
