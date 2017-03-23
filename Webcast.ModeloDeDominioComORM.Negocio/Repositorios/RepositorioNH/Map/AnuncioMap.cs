using Webcast.ModeloDeDominioComORM.Negocio.DominioNH.GerenciamentoDeAnuncio;
using FluentNHibernate;
using FluentNHibernate.Mapping;

namespace Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioNH.Map
{
    public class AnuncioMap : ClassMap<Anuncio>
    {
        public AnuncioMap()
        {
            Id(anuncio => anuncio.Id).GeneratedBy.Assigned().Column("AnuncioId");
            Map(anuncio => anuncio.AnuncianteId);

            Map(anuncio => anuncio.DataDePublicacao);

            Component(anuncio => anuncio.Vigencia, vigencia =>
            {
                vigencia.Map(v => v.Inicial).Column("PeriodoInicio");
                vigencia.Map(v => v.Final).Column("PeriodoFinal");
            });


            HasMany<Proposta>(Reveal.Member<Anuncio>("Propostas"))
                .KeyColumns.Add("AnuncioId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Cascade.AllDeleteOrphan()
                .Cascade.SaveUpdate();

            HasOne<Veiculo>(x => x.Veiculo).Cascade.All();
        }
    }
}
