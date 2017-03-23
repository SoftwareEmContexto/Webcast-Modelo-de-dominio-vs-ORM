using System;

namespace Webcast.ModeloDeDominioComORM.Negocio.Comum
{
    public class Entidade
    {
        public virtual Identidade Id { get; protected set; }


        public Entidade(Identidade id)
        {
            Id = id;
        }

        public override bool Equals(object entidade)
        {
            var entidadeComparacao = entidade as Entidade;

            if (ReferenceEquals(entidadeComparacao, null))
                return false;

            if (ReferenceEquals(this, entidadeComparacao))
                return true;

            if (GetType() != entidadeComparacao.GetType())
                return false;

            if (!Transitorio() &&
                !entidadeComparacao.Transitorio() &&
                Id.Id == entidadeComparacao.Id.Id)
                return true;

            if (Transitorio() || entidadeComparacao.Transitorio())
                return false;

            return Id.Id == entidadeComparacao.Id.Id;
        }

        public virtual bool Transitorio()
        {
            return Id.Id == default(Guid);
        }

        public static bool operator ==(Entidade entidadeA, Entidade entidadeB)
        {
            if (ReferenceEquals(entidadeA, null) && ReferenceEquals(entidadeB, null))
                return true;

            if (ReferenceEquals(entidadeA, null) || ReferenceEquals(entidadeB, null))
                return false;

            return entidadeA.Equals(entidadeB);
        }

        public static bool operator !=(Entidade entidadeA, Entidade entidadeB)
        {
            return !(entidadeA == entidadeB);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id.Id).GetHashCode();
        }
    }
}
