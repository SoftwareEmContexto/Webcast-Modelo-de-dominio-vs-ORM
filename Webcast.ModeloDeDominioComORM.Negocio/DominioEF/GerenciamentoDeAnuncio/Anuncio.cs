using Webcast.ModeloDeDominioComORM.Negocio.NucleoCompartilhado;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Webcast.ModeloDeDominioComORM.Negocio.DominioEF.GerenciamentoDeAnuncio
{
    public class Anuncio : Agregado
    {

        public static Expression<Func<Anuncio, ICollection<Proposta>>> PropostaExpression = f => f._propostas;
        private ICollection<Proposta> _propostas;

        public Guid AnuncianteId { get; private set; }
        public DateTime DataDePublicacao { get; private set; }
        public Periodo Vigencia { get; private set; }
        public Veiculo Veiculo { get; private set; }

        public IEnumerable<Proposta> Propostas { get { return _propostas; } }

        private Anuncio()
        {

        }

        public Anuncio(Guid id, Guid anuncianteId, Periodo vigencia,
            Veiculo veiculo) : base(id)
        {
            if (vigencia == null)
                throw new InvalidOperationException("A Vigência é obrigatória");

            if (veiculo == null)
                throw new InvalidOperationException("O Veículo é obrigatório");

            _propostas = new List<Proposta>();
            AnuncianteId = anuncianteId;
            DataDePublicacao = DateTime.Now;
            Vigencia = vigencia;
            Veiculo = veiculo;
        }

        public void AdicionarProposta(Proposta proposta)
        {
            if (!_propostas.Contains(proposta))
                _propostas.Add(proposta);
        }
    }
}