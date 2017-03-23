﻿using System;
using Webcast.ModeloDeDominioComORM.Negocio.Comum;

namespace Webcast.ModeloDeDominioComORM.Negocio.DominioEF
{
    public sealed class DetalheDeFabricacao : ObjetoDeValor<DetalheDeFabricacao>
    {
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int AnoModelo { get; private set; }
        public int AnoFabricacao { get; private set; }

        private DetalheDeFabricacao()
        {

        }

        private DetalheDeFabricacao(string marca, string modelo,
            int anoFabricacao, int anoModelo)
        {
            if (AnoModelo < AnoFabricacao)
                throw new InvalidOperationException("O Ano Modelo não pode ser Maior que o Ano de Fabricação");

            if (string.IsNullOrWhiteSpace(marca))
                throw new InvalidOperationException("A Marca é obrigatória");

            if (string.IsNullOrWhiteSpace(modelo))
                throw new InvalidOperationException("O Modelo é obrigatório");

            Marca = marca;
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            AnoModelo = anoModelo;
        }

        public static DetalheDeFabricacao Novo(string marca, string modelo,
            int anoFabricacao, int anoModelo)
        {
            return new DetalheDeFabricacao(marca, modelo, anoFabricacao, anoModelo);
        }

        protected override bool EqualsCore(DetalheDeFabricacao other)
        {
            return Marca == other.Marca
                && Modelo == other.Modelo
                && AnoFabricacao == other.AnoFabricacao
                && AnoModelo == other.AnoModelo;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hashCode = Marca.GetHashCode();
                hashCode = (hashCode * 397) ^ Modelo.GetHashCode();
                hashCode = (hashCode * 397) ^ AnoModelo.GetHashCode();
                hashCode = (hashCode * 397) ^ AnoFabricacao.GetHashCode();

                return hashCode;
            }
        }
    }
}
