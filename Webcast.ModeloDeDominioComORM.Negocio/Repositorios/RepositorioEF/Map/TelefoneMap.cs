
using Webcast.ModeloDeDominioComORM.Negocio.DominioEF.GerenciamentoDeAnunciante;
using System.Data.Entity.ModelConfiguration;

namespace Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioEF.Map
{
    public class TelefoneMap : ComplexTypeConfiguration<Telefone>
    {
        public TelefoneMap()
        {
            

            Property(tel => tel.DDD)
             .HasColumnName("DDDTelefoneComercial");


            Property(tel => tel.Numero)
                .HasColumnName("TelefoneComercial")
                 .HasColumnType("varchar")
                 .HasMaxLength(9);


            Property(tel => tel.DDD)
             .HasColumnName("DDDTelefonePrincipal");


            Property(tel => tel.Numero)
                .HasColumnName("TelefonePrincipal")
                 .HasColumnType("varchar")
                 .HasMaxLength(9);

            Property(tel => tel.DDD)
                .HasColumnName("DDDCelular");


            Property(tel => tel.Numero)
                .HasColumnName("Celular")
                 .HasColumnType("varchar")
                 .HasMaxLength(9);



        }
    }
}
