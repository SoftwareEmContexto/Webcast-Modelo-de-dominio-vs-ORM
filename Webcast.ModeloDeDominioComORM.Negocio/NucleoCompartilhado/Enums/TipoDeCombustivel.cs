using Webcast.ModeloDeDominioComORM.Negocio.Comum;

namespace Webcast.ModeloDeDominioComORM.Negocio.NucleoCompartilhado.Enums
{
    public class TipoDeCombustivel : Enumeration
    {
        public static readonly TipoDeCombustivel Gasolina = new TipoDeCombustivel(0, "Gasolina");
        public static readonly TipoDeCombustivel Alcool = new TipoDeCombustivel(1, "Alcool");
        public static readonly TipoDeCombustivel Flex = new TipoDeCombustivel(2, "Gasolina e Alcool");
        public static readonly TipoDeCombustivel GasNatural = new TipoDeCombustivel(3, "Gás Natural");

        public TipoDeCombustivel()
        {
        }

        
        private TipoDeCombustivel(int value, string displayName)
            : base(value, displayName)
        {
        }
    }
}