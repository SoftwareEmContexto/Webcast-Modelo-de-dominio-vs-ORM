using Webcast.ModeloDeDominioComORM.Negocio.Comum;
using Webcast.ModeloDeDominioComORM.Negocio.DominioPuro.GerenciamentoDeAnunciante;
using Webcast.ModeloDeDominioComORM.Negocio.NucleoCompartilhado;
using Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioDapper;
using System;
using Xunit;


namespace SeuCarroNaVitrine.Tests
{
    public class AnuncianteTestDapper
    {
        private readonly AnuncianteRepositorioSQL _repositorio;

        public AnuncianteTestDapper()
        {
            _repositorio = new AnuncianteRepositorioSQL();
        }


        [Fact]
        public Guid InserirAnunciante()
        {
            
            var nome = Nome.Novo("José Roberto", "Araújo");
            var endereco = Endereco.Novo("Rua do Paraíso", "Saúde", "São Paulo", "SP", 04123010);
            var email = Email.Novo("jroberto.araujo@gmail.com");
            var contatos = AgendaTelefonica.Nova(Telefone.Novo(11, "123456789"),
                Telefone.Novo(11, "123456789"), Telefone.Novo(11, "123456789"));

            var id = new Identidade();

            var anunciante = new Anunciante(id, nome, endereco, email, contatos);

            _repositorio.Salvar(anunciante);

            var anuncianteResult = _repositorio.ObterPorId(id);

            Console.WriteLine(anuncianteResult.Nome);

            return id.Id;
        }
    }
}
