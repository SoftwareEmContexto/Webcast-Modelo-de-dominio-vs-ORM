
using Webcast.ModeloDeDominioComORM.Negocio.DominioEF.GerenciamentoDeAnunciante;
using System.Data.Entity.ModelConfiguration;

namespace Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioEF.Map
{
    public class EnderecoMap:ComplexTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {

            Property(endereco => endereco.Cidade)
                .HasColumnType("varchar")
                .HasColumnName("Cidade")
                .HasMaxLength(100)
                .IsRequired();

            Property(endereco => endereco.Bairro)
                .HasColumnName("Bairro")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(endereco => endereco.Cep)
                .HasColumnName("Cep")
                .IsRequired();

            Property(endereco => endereco.Logradouro)
                .HasColumnName("Logradouro")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(endereco => endereco.Estado)
             .HasColumnName("Estado")
             .HasColumnType("varchar")
             .HasMaxLength(100)
             .IsRequired();

        }
    }
}
