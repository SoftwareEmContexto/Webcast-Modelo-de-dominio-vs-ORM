using Webcast.ModeloDeDominioComORM.Negocio.Comum;
using System;

namespace Webcast.ModeloDeDominioComORM.Negocio.DominioEF.GerenciamentoDeAnunciante
{
    public sealed class AgendaTelefonica : ObjetoDeValor<AgendaTelefonica>
    {
        public Telefone TelefonePrincipal { get; private set; }
        public Telefone TelefoneComercial { get; private set; }
        public Telefone TelefoneCelular { get; private set; }


        private AgendaTelefonica(Telefone telefonePrincipal,
            Telefone telefoneComercial, Telefone celular)
        {
            if (telefonePrincipal == null)
                throw new InvalidOperationException("O telefone principal é obrigatório");

            if (telefoneComercial == null)
                throw new InvalidOperationException("O telefone comercial é obrigatório");

            if (celular == null)
                throw new InvalidOperationException("O celular é obrigatório");

            TelefonePrincipal = telefonePrincipal;
            TelefoneComercial = telefoneComercial;
            TelefoneCelular = celular;
        }

        public static AgendaTelefonica Nova(Telefone telefonePrincipal,
            Telefone telefoneComercial, Telefone celular)
        {
            return new AgendaTelefonica(telefonePrincipal, telefoneComercial, celular);
        }

        protected override bool EqualsCore(AgendaTelefonica other)
        {
            return TelefonePrincipal == other.TelefonePrincipal
                    && TelefoneComercial == other.TelefoneComercial
                    && TelefoneCelular == other.TelefoneCelular;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = TelefonePrincipal.GetHashCode();
                hashCode = (hashCode * 397) ^ TelefoneComercial.GetHashCode();
                hashCode = (hashCode * 397) ^ TelefoneCelular.GetHashCode();

                return hashCode;
            }
        }
    }
}
