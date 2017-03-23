using Webcast.ModeloDeDominioComORM.Negocio.DominioNH.GerenciamentoDeAnuncio;
using FluentNHibernate.Mapping;
using System;

namespace Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioNH.Map
{
    public class PropostaMap:ClassMap<Proposta>
    {
        public PropostaMap()
        {
            Id(s => s.Id).GeneratedBy.Assigned().UnsavedValue(Guid.Empty);

            Component(a => a.Nome, nome =>
            {
                nome.Map(n => n.PrimeiroNome).Column("Nome");
                nome.Map(n => n.Sobrenome).Column("Sobrenome");
            });


            Component(proposta => proposta.Telefone, telefone =>
            {
                telefone.Map(tel => tel.DDD).Column("DDD");
                telefone.Map(tel => tel.Numero).Column("Telefone");
            });

            Component(a => a.Email, e =>
            {
                e.Map(em => em.Valor).Column("Email");
            });

            Map(proposta => proposta.DataDeEnvio);
            Map(proposta => proposta.Valor);
            Map(proposta => proposta.Mensagem);
        }
     
    }
}
