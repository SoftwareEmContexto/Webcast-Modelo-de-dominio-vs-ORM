using System;

namespace Webcast.ModeloDeDominioComORM.Negocio.DominioEF
{
    public class Agregado : Entidade
    {
        public Agregado(Guid id) : base(id)
        {
          
        }

        public Agregado() : base(Guid.NewGuid())
        {

        }

    }
}
