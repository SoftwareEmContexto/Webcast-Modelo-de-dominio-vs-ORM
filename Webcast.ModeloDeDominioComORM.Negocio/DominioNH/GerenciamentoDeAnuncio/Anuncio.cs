
using Webcast.ModeloDeDominioComORM.Negocio.NucleoCompartilhado;
using System;
using System.Collections.Generic;

namespace Webcast.ModeloDeDominioComORM.Negocio.DominioNH.GerenciamentoDeAnuncio
{
    public class Anuncio : Agregado
    {
        private IList<Proposta> _propostas;

        public virtual Guid AnuncianteId { get; }
        public virtual DateTime DataDePublicacao { get; }
        public virtual Periodo Vigencia { get; }
        public virtual Veiculo Veiculo { get; }
        public virtual IEnumerable<Proposta> Propostas { get { return _propostas; } }

        protected Anuncio():base()
        {

        }

        public Anuncio(Guid id, Guid anuncianteId, Periodo vigencia,
            Veiculo veiculo) : base(id)
        {

            if (vigencia == null)
                throw new InvalidOperationException("A Vigência é obrigatória");

            if (veiculo == null)
                throw new InvalidOperationException("O Veículo é obrigatório");

            _propostas = new List<Proposta>(); ;
            AnuncianteId = anuncianteId;
            DataDePublicacao = DateTime.Now;
            Vigencia = vigencia;
            Veiculo = veiculo;
        }

        public virtual void AdicionarProposta(Proposta proposta)
        {
            if (!_propostas.Contains(proposta))
                _propostas.Add(proposta);
        }
    }
}