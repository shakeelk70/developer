using System.Linq.Expressions;
using CodingTest.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CodingTest.Database;

public interface IRepository
{
    IQueryable<TEntity> Query<TEntity>() where TEntity : class;
    IQueryable<TEntity> FromExpression<TEntity>(Expression<Func<IQueryable<TEntity>>> expression);

    TEntity? GetEntity<TEntity>(Func<TEntity, bool> func) where TEntity : class;
    TEntity? GetEntity<TEntity>(int id) where TEntity : class, IEntity;

    EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;

    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
