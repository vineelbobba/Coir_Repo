using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Coir_ERP.EntityFramework.Repositories
{
    public abstract class Coir_ERPRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<Coir_ERPDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected Coir_ERPRepositoryBase(IDbContextProvider<Coir_ERPDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class Coir_ERPRepositoryBase<TEntity> : Coir_ERPRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected Coir_ERPRepositoryBase(IDbContextProvider<Coir_ERPDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
