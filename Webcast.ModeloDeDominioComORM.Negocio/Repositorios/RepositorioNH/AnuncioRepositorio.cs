using Webcast.ModeloDeDominioComORM.Negocio.DominioNH.GerenciamentoDeAnuncio;

namespace Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioNH
{
    public class AnuncioRepositorio:RepositorioBase<Anuncio>
    {
        public void Salvar(Anuncio novoAnuncio)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Save(novoAnuncio);
               // _session.Flush();
                tran.Commit();
            }
        }
    }
}
