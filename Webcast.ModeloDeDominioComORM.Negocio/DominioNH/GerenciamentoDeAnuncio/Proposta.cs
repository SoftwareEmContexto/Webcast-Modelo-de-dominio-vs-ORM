using Webcast.ModeloDeDominioComORM.Negocio.NucleoCompartilhado;
using System;
using Webcast.ModeloDeDominioComORM.Negocio.Comum;

namespace Webcast.ModeloDeDominioComORM.Negocio.DominioNH.GerenciamentoDeAnuncio
{
    public class Proposta : Entidade
    {
        public virtual Guid AnuncioId { get; }
        public virtual Nome Nome { get; }
        public virtual Email Email { get; }
        public virtual Telefone Telefone { get; }
        public virtual DateTime DataDeEnvio { get; }
        public virtual decimal Valor { get; }
        public virtual string Mensagem { get; }

        protected Proposta():base()
        {

        }

        public Proposta(Identidade id, Guid anuncioId, Nome nome, Email email, Telefone telefone,
            decimal valor, string mensagem) : base(id)
        {
            if (valor == default(decimal))
                throw new InvalidOperationException("O Valor da Proposta é obrigatório");

            if (string.IsNullOrWhiteSpace(mensagem))
                throw new InvalidOperationException("Informe algum detalhe na proposta");

            if (nome == null)
                throw new InvalidOperationException("O Nome é obrigatório");

            if (telefone == null)
                throw new InvalidOperationException("O Telefone é obrigatório");

            if (email == null)
                throw new InvalidOperationException("O Email é obrigatório");

            AnuncioId = anuncioId;
            DataDeEnvio = DateTime.Now;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Valor = valor;
            Mensagem = mensagem;
        }
    }
}