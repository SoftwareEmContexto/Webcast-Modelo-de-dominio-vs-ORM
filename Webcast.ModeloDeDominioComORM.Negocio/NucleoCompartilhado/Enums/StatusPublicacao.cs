using Webcast.ModeloDeDominioComORM.Negocio.Comum;

namespace Webcast.ModeloDeDominioComORM.Negocio.NucleoCompartilhado.Enums
{
    public class StatusPublicacao : Enumeration
    {
        public static readonly StatusPublicacao Anunciado = new StatusPublicacao(0, "Anunciado");
        public static readonly StatusPublicacao Disponivel = new StatusPublicacao(1, "Disponível");
        public static readonly StatusPublicacao NaoVistoriado = new StatusPublicacao(2, "Não Vistoriado");

        public StatusPublicacao()
        {
        }

        
        private StatusPublicacao(int value, string displayName)
            : base(value, displayName)
        {
        }
    }
}