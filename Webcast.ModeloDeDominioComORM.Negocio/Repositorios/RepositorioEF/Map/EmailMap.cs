
using Webcast.ModeloDeDominioComORM.Negocio.DominioEF.GerenciamentoDeAnunciante;
using System.Data.Entity.ModelConfiguration;

namespace Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioEF.Map
{
    public class EmailMap : ComplexTypeConfiguration<Email>
    {
        public EmailMap()
        {
            Property(email => email.Valor)
                .HasColumnName("Email")
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
