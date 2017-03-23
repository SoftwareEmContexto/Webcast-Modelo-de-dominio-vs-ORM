using Webcast.ModeloDeDominioComORM.Negocio.DominioEF.GerenciamentoDeAnuncio;

namespace Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioEF
{
    public class AnuncioRepositorio
    {
        private readonly MeuCarroNaVitrineContext _contexto;

        public AnuncioRepositorio()
        {
            _contexto = new MeuCarroNaVitrineContext();
        }

        public void Salvar(Anuncio anuncio)
        {
            _contexto.Anuncio.Add(anuncio);
            _contexto.SaveChanges();
        }
    }
}
