namespace Domainify.Domain
{
    public abstract class RequestToCheckEntityForDeleting<TEntity> :
        CommandRequest<TEntity>
        where TEntity : BaseEntity<TEntity>
    {
        public override void Prepare(TEntity entity)
        {
            base.Prepare(entity);
            InvariantState.DefineAnInvariant(
                condition: entity.IsDeleted,
                fault: new TheEntityWasDeletedSoDeletingItAgainIsNotPossibleFault());
        }
    }
}
