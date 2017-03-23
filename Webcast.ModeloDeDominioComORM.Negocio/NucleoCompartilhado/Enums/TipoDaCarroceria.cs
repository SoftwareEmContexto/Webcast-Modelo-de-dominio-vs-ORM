using Webcast.ModeloDeDominioComORM.Negocio.Comum;

namespace Webcast.ModeloDeDominioComORM.Negocio.NucleoCompartilhado.Enums
{
    public class TipoDaCarroceria : Enumeration
    {
        public static readonly TipoDaCarroceria Hatch = new TipoDaCarroceria(0, "Hatch");
        public static readonly TipoDaCarroceria Sedan = new TipoDaCarroceria(1, "Sedan");
        public static readonly TipoDaCarroceria UtilitarioEsportivo = new TipoDaCarroceria(2, "Utilitário Esportivo");
        public static readonly TipoDaCarroceria Picape = new TipoDaCarroceria(3, "Picape");
        public static readonly TipoDaCarroceria VanUtilitario = new TipoDaCarroceria(4, "Van/Utilitário");

        public TipoDaCarroceria()
        {
        }


        private TipoDaCarroceria(int value, string displayName)
            : base(value, displayName)
        {
        }
    }
}