using Webcast.ModeloDeDominioComORM.Negocio.DominioNH.GerenciamentoDeAnunciante;
using FluentNHibernate.Mapping;

namespace Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioNH.Map
{
    public class AnuncianteMap : ClassMap<Anunciante>
    {
        public AnuncianteMap() : base()
        {
            Id(a => a.Id).Column("AnuncianteId") ;

            Component(a => a.Nome, nome =>
            {
                nome.Map(n => n.PrimeiroNome).Column("Nome");
                nome.Map(n => n.Sobrenome).Column("Sobrenome");
            });

            Component(a => a.Endereco, endereco =>
            {
                endereco.Map(e => e.Cep);
                endereco.Map(e => e.Logradouro);
                endereco.Map(e => e.Bairro);
                endereco.Map(e => e.Estado);
                endereco.Map(e => e.Cidade);
            });

            Component(a => a.AgendaTelefonica, agenda =>
            {
                agenda.Component(a => a.Celular, c =>
                {
                    c.Map(tel => tel.DDD).Column("DDDCelular");
                    c.Map(tel => tel.Numero).Column("Celular");
                });

                agenda.Component(a => a.TelefoneComercial, c =>
                {
                    c.Map(tel => tel.DDD).Column("DDDTelefoneComercial");
                    c.Map(tel => tel.Numero).Column("TelefoneComercial");
                });

                agenda.Component(a => a.TelefonePrincipal, c =>
                {
                    c.Map(tel => tel.DDD).Column("DDDTelefonePrincipal");
                    c.Map(tel => tel.Numero).Column("TelefonePrincipal");
                });
            });


            Component(a => a.Email, e =>
            {
                e.Map(em => em.Valor).Column("Email");
            });

        }
    }
}
