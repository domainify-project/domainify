using System.Linq.Expressions;

namespace Domainify.Domain
{
    public abstract class RequestToCheckEntityForDeletingPermanentlyById<TEntity, IdType> :
        RequestToCheckEntityForDeletingPermanently<TEntity>
        where TEntity : Entity<TEntity, IdType>
    {
        public RequestToCheckEntityForDeletingPermanentlyById(IdType id) 
        {
            Id = id;
        }

        public IdType Id { get; private set; }

        public override Expression<Func<TEntity, bool>>? Identification()
        {
            return x => x.Id!.Equals(Id);
        }

        public virtual RequestToCheckEntityForDeletingPermanentlyById<TEntity, IdType> SetId(IdType value)
        {
            Id = value;

            return this;
        }
    }
}
