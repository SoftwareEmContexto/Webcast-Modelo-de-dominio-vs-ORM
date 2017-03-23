using Webcast.ModeloDeDominioComORM.Negocio.Comum;
using System;
using System.Text.RegularExpressions;

namespace Webcast.ModeloDeDominioComORM.Negocio.DominioNH
{
    public sealed class Email : ObjetoDeValor<Email>
    {
        public string Valor { get; }

        private Email()
        {

        }

        private Email(string valor)
        {
            if (!(ValidarEnderecoDeEmail(valor)))
                throw new InvalidOperationException("Endereço de email inválido");

            Valor = valor;
        }

        public static Email Novo(string email)
        {
            return new Email(email);
        }

        protected override bool EqualsCore(Email other)
        {
            return Valor == other.Valor;
        }

        protected override int GetHashCodeCore()
        {
            return Valor.GetHashCode();
        }

        private static bool ValidarEnderecoDeEmail(string emailAddress)
        {
            var regexPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            var matches = Regex.Match(emailAddress, regexPattern);
            return matches.Success;
        }
    }
}
