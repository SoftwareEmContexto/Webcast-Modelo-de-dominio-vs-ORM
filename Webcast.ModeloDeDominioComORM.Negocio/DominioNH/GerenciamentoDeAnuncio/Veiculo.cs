using Webcast.ModeloDeDominioComORM.Negocio.NucleoCompartilhado;
using Webcast.ModeloDeDominioComORM.Negocio.NucleoCompartilhado.Enums;
using System;

namespace Webcast.ModeloDeDominioComORM.Negocio.DominioNH.GerenciamentoDeAnuncio
{
    public class Veiculo : Entidade
    {
        
        public virtual DetalheDeFabricacao DetalheDeFabricacao { get; }
        public virtual ItensOpcicionais Opcionais { get; }
        public virtual DetalheDoVeiculo Detalhe { get; protected set; }
        public virtual StatusPublicacao StatusDePublicacao { get; } = StatusPublicacao.NaoVistoriado;

        protected Veiculo():base(Guid.Empty)
        {

        }

        public Veiculo(Guid id, DetalheDeFabricacao detalheDeFabricacao,
            ItensOpcicionais opcionais, DetalheDoVeiculo detalhe) : base(id)
        {
            if (detalheDeFabricacao == null)
                throw new InvalidOperationException("O Detalhe de Fabricação é obrigatório");

            if (detalhe == null)
                throw new InvalidOperationException("O Detalhe do Veículo é obrigatório");

            DetalheDeFabricacao = detalheDeFabricacao;
            Opcionais = opcionais;
            Detalhe = detalhe;
        }

        public virtual void AlterarKilometragem(int novaKilometragem)
        {
            Detalhe = DetalheDoVeiculo.Novo(Detalhe.Placa, novaKilometragem,
                Detalhe.Cambio, Detalhe.Carroceria, Detalhe.Cor, Detalhe.Combustivel,
                Detalhe.Portas, Detalhe.Preco);
        }
    }
}