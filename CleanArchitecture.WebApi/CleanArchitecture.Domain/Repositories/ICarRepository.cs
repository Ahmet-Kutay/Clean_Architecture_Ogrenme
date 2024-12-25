using CleanArchitecture.Domain.Entities;
using System.Linq.Expressions;

namespace CleanArchitecture.Domain.Repositories;

public interface ICarRepository
{
    Task AddAsync(Car entity, CancellationToken cancellationToken);
    IQueryable<Car> Where(Expression<Func<Car, bool>> expression);
}