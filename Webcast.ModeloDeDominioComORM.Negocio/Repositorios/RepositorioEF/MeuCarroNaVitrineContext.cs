using Webcast.ModeloDeDominioComORM.Negocio.DominioEF.GerenciamentoDeAnunciante;
using Webcast.ModeloDeDominioComORM.Negocio.DominioEF.GerenciamentoDeAnuncio;
using Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioEF.Map;
using System.Data.Entity;

namespace Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioEF
{
    public class MeuCarroNaVitrineContext:DbContext
    {

        public MeuCarroNaVitrineContext():base(@"Server=(LocalDb)\MSSQLLocalDB; Database=SeuCarroNaVitrine; Integrated Security=SSPI;")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Configurations.Add(new NomeMap());
            modelBuilder.Configurations.Add(new EnderecoMap());
            modelBuilder.Configurations.Add(new EmailMap());
            modelBuilder.Configurations.Add(new TelefoneMap());
            modelBuilder.Configurations.Add(new AnuncianteMap());



            modelBuilder.Configurations.Add(new PeriodoMap());
            modelBuilder.Configurations.Add(new DetalheDoVeiculoMap());
            modelBuilder.Configurations.Add(new CambioMap());
            modelBuilder.Configurations.Add(new CarroceriaMap());
            modelBuilder.Configurations.Add(new CombustivelMap());
            modelBuilder.Configurations.Add(new CorMap());
            modelBuilder.Configurations.Add(new DetalheDaFabricacaoMap());
            modelBuilder.Configurations.Add(new ItensOpcionaisMap());
            modelBuilder.Configurations.Add(new StatusPublicacaoMap());
            modelBuilder.Configurations.Add(new VeiculoMap());
            modelBuilder.Configurations.Add(new AnuncioMap());


        }

        public DbSet<Anunciante> Anunciante { get; set; }
        public DbSet<Anuncio> Anuncio { get; set; }
    }
}

