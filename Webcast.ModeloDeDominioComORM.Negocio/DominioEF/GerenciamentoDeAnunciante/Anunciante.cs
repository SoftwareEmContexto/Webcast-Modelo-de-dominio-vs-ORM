using System;

namespace Webcast.ModeloDeDominioComORM.Negocio.DominioEF.GerenciamentoDeAnunciante
{
    public class Anunciante : Agregado
    {
      

        public Nome Nome { get; private set; }
        public Endereco Endereco { get; private set; }
        public Email Email { get; private set; }

        // O Telefone foi incluido no anunciante pois o EF não consegue mapear um VO que encapsula outro VO.
        // Sendo assim, não consigo ter uma Agenda telefonica que possui telefones. Só seria possivel se minha
        //Agenda telefonica fosse uma entidade.

        public Telefone TelefonePrincipal { get; private set; }

        //O mapeamento do EF não permite que exista mais de uma propriedade do mesmo tipo.
        //Ou seja, não é possivel ter dois tipos telefone na mesma entidade.


        //public Telefone TelefoneComercial { get; private set; }
        //public Telefone TelefoneCelular { get; private set; }

        private Anunciante()
        {

        }
        public Anunciante(Guid id, Nome nome, Endereco endereco, Email email,Telefone celular, Telefone comercial, Telefone principal): base(id)
        {
            if (nome == null)
                throw new InvalidOperationException("O Nome do proprietário é obrigatório");

            if (endereco == null)
                throw new InvalidOperationException("O Endereço do proprietário é obrigatório");

            if (email == null)
                throw new InvalidOperationException("O Email do proprietário é obrigatório");

            if (celular == null )
                throw new InvalidOperationException("Telefone celular é obrigatório");

            if (principal == null)
                throw new InvalidOperationException("Telefone principal é obrigatório");

            if (comercial == null)
                throw new InvalidOperationException("Telefone comercial é obrigatório");

            Nome = nome;
            Email = email;
            Endereco = endereco;
            //TelefoneCelular = celular;
            //TelefoneComercial = comercial;
            TelefonePrincipal = principal;
        }

        public void AlterarEmail(Email novoEmail)
        {
            Email = novoEmail;
        }
    }
}