using Webcast.ModeloDeDominioComORM.Negocio.NucleoCompartilhado;
using System;

namespace Webcast.ModeloDeDominioComORM.Negocio.DominioNH.GerenciamentoDeAnunciante
{
    public class Anunciante : Agregado
    {
        public virtual Nome Nome { get; protected set; }
        public virtual Endereco Endereco { get; protected set; }
        public virtual Email Email { get; protected set; }
        public virtual AgendaTelefonica AgendaTelefonica { get; protected set; }

        protected Anunciante() : base()
        {
            
        }

        public Anunciante(Guid id, Nome nome, Endereco endereco, Email email,
            AgendaTelefonica agendaTelefonica) : base(id)
        {
            if (nome == null)
                throw new InvalidOperationException("O Nome do proprietário é obrigatório");

            if (endereco == null)
                throw new InvalidOperationException("O Endereço do proprietário é obrigatório");

            if (email == null)
                throw new InvalidOperationException("O Email do proprietário é obrigatório");

            if (agendaTelefonica == null)
                throw new InvalidOperationException("A Agenda Telefônica do proprietário é obrigatória");

            Nome = nome;
            Email = email;
            Endereco = endereco;
            AgendaTelefonica = agendaTelefonica;
            
        }

        public virtual void AlterarEmail(Email novoEmail)
        {
            Email = novoEmail;
        }
    }
}