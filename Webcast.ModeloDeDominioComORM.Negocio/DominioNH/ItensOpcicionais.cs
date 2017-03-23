using Webcast.ModeloDeDominioComORM.Negocio.Comum;
using System.Collections.Generic;

namespace Webcast.ModeloDeDominioComORM.Negocio.DominioNH
{
    public sealed class ItensOpcicionais : ObjetoDeValor<ItensOpcicionais>
    {
        private List<string> _opcionais;

        public string Itens { get; }

        private ItensOpcicionais()
        {

        }

        private ItensOpcicionais(string itens)
        {
            _opcionais = new List<string>();

            _opcionais.AddRange(itens.Split(','));

            Itens = UnificarItens(_opcionais);
        }

        public static ItensOpcicionais Novo(string item)
        {
            return new ItensOpcicionais(item);
        }
        
        private string UnificarItens(List<string> opcionais)
        {
            return string.Join(",", _opcionais);
        }

        protected override bool EqualsCore(ItensOpcicionais other)
        {
            return Itens == other.Itens;
        }

        protected override int GetHashCodeCore()
        {
            return Itens.GetHashCode();
        }
    }
}
