namespace Domainify.Domain
{
    public abstract class RequestToCheckEntityForDeletingPermanently<TEntity> :
        CommandRequest<TEntity>
        where TEntity : BaseEntity<TEntity>
    {
        public override void Prepare(TEntity entity)
        {
            base.Prepare(entity);
            InvariantState.DefineAnInvariant(
                condition: entity.IsDeleted,
                fault: new EntityMustBeDeletedBeforeBenigDeletedPermanentlyFault());
        }
    }
}
