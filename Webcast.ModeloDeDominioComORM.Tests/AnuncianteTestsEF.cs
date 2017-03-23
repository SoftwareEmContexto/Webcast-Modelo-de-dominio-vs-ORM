using Webcast.ModeloDeDominioComORM.Negocio.Comum;
using Webcast.ModeloDeDominioComORM.Negocio.DominioEF.GerenciamentoDeAnunciante;
using Webcast.ModeloDeDominioComORM.Negocio.Repositorios.RepositorioEF;
using System;
using Xunit;

namespace SeuCarroNaVitrine.Tests
{
    public class AnuncianteTestsEF
    {

        private readonly AnuncianteRepositorio _repositorio;

        public AnuncianteTestsEF()
        {
            _repositorio = new AnuncianteRepositorio();
        }

        [Fact()]
        public void PersistirUmNovoAnuncianteTest()
        {
            var identidade = Guid.NewGuid();
            var nome = Nome.Novo("Gustavo", "Fontes");
            var endereco = Endereco.Novo("Av. paulista", "Jardins", "São Paulo", "SP", 012345678);
            var email = Email.Novo("gustavo.fontes@gmail.com");
         
            var novoAnunciante = new Anunciante
                (
                identidade, 
                nome, 
                endereco, 
                email,
                Telefone.Novo(11, "12345678"), 
                Telefone.Novo(11, "12345678"), 
                Telefone.Novo(11, "12345678"));

            _repositorio.Salvar(novoAnunciante);


            
        }
    }
}
