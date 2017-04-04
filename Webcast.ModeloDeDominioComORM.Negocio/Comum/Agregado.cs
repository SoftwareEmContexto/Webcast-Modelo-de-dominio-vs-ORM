namespace Webcast.ModeloDeDominioComORM.Negocio.Comum
{
    public class Agregado : Entidade
    {
        public Agregado(Identidade id) : base(id)
        {
          
        }

        public Agregado() : base(new Identidade())
        {

        }

    }
}
