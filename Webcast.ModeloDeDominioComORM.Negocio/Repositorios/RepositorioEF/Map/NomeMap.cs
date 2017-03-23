using Webcast.ModeloDeDominioComORM.Negocio.DominioEF.GerenciamentoDeAnunciante;
using System.Data.Entity.ModelConfiguration;

namespace Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioEF.Map
{
    public class NomeMap:ComplexTypeConfiguration<Nome>
    {
        public NomeMap()
        {
            Property(nome => nome.PrimeiroNome)
                .HasColumnName(nameof(Nome))
                .HasColumnType("varchar")
                .HasMaxLength(100);


            Property(nome => nome.Sobrenome)
                .HasColumnName("Sobrenome")
                .HasColumnType("varchar")
                .HasMaxLength(100);


        }
    }
}
