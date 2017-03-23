using Webcast.ModeloDeDominioComORM.Negocio.DominioNH;
using Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioNH.Map;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;

namespace Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioNH
{
    public class RepositorioBase<T> where T : Agregado
    {

        protected readonly ISessionFactory _sessionFactory;
        protected readonly ISession _session;

        public RepositorioBase()
        {
            _sessionFactory = Init();

            _session = _sessionFactory.OpenSession();

        }

        public T ObterPor(Guid id)
        {
            return _session.Load<T>(id);
        }

        private ISessionFactory Init()
        {
            return Fluently.Configure()
               .Database(MsSqlConfiguration.MsSql2012.ShowSql()
                           .ConnectionString(@"Server=(LocalDb)\MSSQLLocalDB; Database=SeuCarroNaVitrine; Integrated Security=SSPI;"))
               .Mappings(m =>
               {
                   m.FluentMappings.Add<AnuncianteMap>();
                   m.FluentMappings.Add<AnuncioMap>();
                   m.FluentMappings.Add<VeiculoMap>();
                   m.FluentMappings.Add<PropostaMap>();

               })

               .BuildConfiguration()
               .BuildSessionFactory();
        }



    }
}
