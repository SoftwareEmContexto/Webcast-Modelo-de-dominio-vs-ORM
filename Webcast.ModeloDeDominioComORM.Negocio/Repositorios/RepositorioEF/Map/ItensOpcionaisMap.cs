
using Webcast.ModeloDeDominioComORM.Negocio.DominioEF;
using System.Data.Entity.ModelConfiguration;

namespace Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioEF.Map
{
    public class ItensOpcionaisMap:ComplexTypeConfiguration<ItensOpcicionais>
    {

        public ItensOpcionaisMap()
        {

            Property(itensOp => itensOp.Itens)
                .HasColumnName("Opcionais")
                .HasColumnType("varchar")
                .HasMaxLength(300);
        }
    }
}
