using Webcast.ModeloDeDominioComORM.Negocio.DominioNH;
using Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioNH.Map;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using Webcast.ModeloDeDominioComORM.Negocio.Comum;
using FluentNHibernate.Mapping;
using System.Reflection;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioNH
{
    public class RepositorioBase<T> where T : Webcast.ModeloDeDominioComORM.Negocio.Comum.Agregado
    {

        protected readonly ISessionFactory _sessionFactory;
        protected readonly ISession _session;

        public RepositorioBase()
        {
            _sessionFactory = Init();

            _session = _sessionFactory.OpenSession();

        }

        public T ObterPor(Identidade id)
        {
            return _session.Load<T>(id.Id);
        }

        private ISessionFactory Init()
        {
            return Fluently.Configure()
               .Database(MsSqlConfiguration.MsSql2012.ShowSql()
                           .ConnectionString(@"Server=(LocalDb)\MSSQLLocalDB; Database=SeuCarroNaVitrine; Integrated Security=SSPI;"))
               .Mappings(m =>
               {
     
                   m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly());
                   
               })

               .BuildConfiguration()
               .BuildSessionFactory();
        }



    }

}
