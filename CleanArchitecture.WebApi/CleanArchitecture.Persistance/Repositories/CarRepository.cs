using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArchitecture.Persistance.Repositories;

public sealed class CarRepository : ICarRepository
{
    private readonly AppDbContext _context;

    public CarRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Car entity, CancellationToken cancellationToken)
    {
        await _context.Set<Car>().AddAsync(entity, cancellationToken);
    }

    public IQueryable<Car> Where(Expression<Func<Car, bool>> expression)
    {
        return _context.Set<Car>().Where(expression);
    }
}