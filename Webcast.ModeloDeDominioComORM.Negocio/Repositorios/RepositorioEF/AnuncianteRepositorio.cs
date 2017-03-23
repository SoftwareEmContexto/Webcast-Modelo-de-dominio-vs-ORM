using Webcast.ModeloDeDominioComORM.Negocio.DominioEF.GerenciamentoDeAnunciante;
using System;
using System.Linq;

namespace Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioEF
{
    public class AnuncianteRepositorio
    {
        private readonly MeuCarroNaVitrineContext _contexto;

        public AnuncianteRepositorio()
        {
            _contexto = new MeuCarroNaVitrineContext();
        }

        public Anunciante ObterPor(Guid Id)
        {
            return _contexto.Anunciante.FirstOrDefault(anunciante => anunciante.Id == Id);
        }

        public void Salvar(Anunciante anunciante)
        {
            _contexto.Anunciante.Add(anunciante);
            _contexto.SaveChanges();
        }
    }
}
