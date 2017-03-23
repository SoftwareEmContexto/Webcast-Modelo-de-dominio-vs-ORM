using Webcast.ModeloDeDominioComORM.Negocio.Comum;
using Webcast.ModeloDeDominioComORM.Negocio.NucleoCompartilhado;
using Webcast.ModeloDeDominioComORM.Negocio.NucleoCompartilhado.Enums;
using System;

namespace Webcast.ModeloDeDominioComORM.Negocio.DominioPuro.GerenciamentoDeAnunciante
{
    public class Veiculo : Entidade
    {
        public DetalheDeFabricacao DetalheDeFabricacao { get; }
        public ItensOpcicionais Opcionais { get; }
        public DetalheDoVeiculo Detalhe { get; private set; }
        public StatusPublicacao StatusDePublicacao { get; } = StatusPublicacao.NaoVistoriado;

        public Veiculo(Identidade id, DetalheDeFabricacao detalheDeFabricacao,
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

        public void AlterarKilometragem(int novaKilometragem)
        {
            Detalhe = DetalheDoVeiculo.Novo(Detalhe.Placa, novaKilometragem,
                Detalhe.Cambio, Detalhe.Carroceria, Detalhe.Cor, Detalhe.Combustivel,
                Detalhe.Portas, Detalhe.Preco);
        }
    }
}