using Webcast.ModeloDeDominioComORM.Negocio.Comum;
using Webcast.ModeloDeDominioComORM.Negocio.DominioPuro.GerenciamentoDeAnunciante;
using Webcast.ModeloDeDominioComORM.Negocio.NucleoCompartilhado;
using Webcast.ModeloDeDominioComORM.Negocio.NucleoCompartilhado.Enums;
using Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioDapper;
using System;
using Xunit;

namespace SeuCarroNaVitrine.Tests
{
   public class AnuncioTestDapper
    {

        private readonly AnuncioRepositorioSQL _repositorio;
        public AnuncioTestDapper()
        {
            _repositorio = new AnuncioRepositorioSQL();
        }

        [Fact]
        public void InserirAnuncioTest()
        {

            var veiculoId = new Identidade();
            var detalheDeFabricacao = DetalheDeFabricacao.Novo("Ford", "Focus Titanium 2.0", 2015, 2016);
            var opcionais = ItensOpcicionais.Novo("Ar Condicionado, Vidros Elétricos, Travas Elétricas, Teto Solar, Farois de Neblina, Farois de Milha");
            var detalheDoVeiculo = DetalheDoVeiculo.Novo("ABC-1234", 10000, TipoDoCambio.Automatico,
                TipoDaCarroceria.Hatch, Cor.Branco, TipoDeCombustivel.Flex, 4, 65000);
            var veiculo = new Veiculo(veiculoId, detalheDeFabricacao, opcionais, detalheDoVeiculo);

            var vigencia = Periodo.Novo(DateTime.Now, DateTime.Now.AddDays(10));

            var anuncioId = new Identidade();
            var anuncianteId = new Identidade("B2490150-D8A8-4F5F-89AB-A4EB28622BA4");

            var anuncio = new Anuncio(anuncioId, anuncianteId, vigencia, veiculo);

            _repositorio.Salvar(anuncio);

            var anuncianteResult = _repositorio.ObterPorId(anuncioId);

            Console.WriteLine(anuncianteResult.Veiculo.Detalhe.Cor);
            Console.WriteLine(anuncianteResult.Veiculo.Detalhe.Combustivel);
            Console.WriteLine(anuncianteResult.Veiculo.Detalhe.Cambio);
            Console.WriteLine(anuncianteResult.Veiculo.Opcionais.Itens);

        }
    }
}
