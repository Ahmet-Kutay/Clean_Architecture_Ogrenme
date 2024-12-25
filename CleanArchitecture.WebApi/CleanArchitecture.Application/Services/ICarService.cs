using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;
using CleanArchitecture.Domain.Entities;
using EntityFrameworkCorePagination.Nuget.Pagination;

namespace CleanArchitecture.Application.Services;

public interface ICarService
{
    Task AddRangeAsync(IList<Car> cars, CancellationToken cancellationToken);
    Task CreateAsync(CreateCarCommand request, CancellationToken cancellationToken);
    Task<PaginationResult<Car>> GetAllAsync(GetAllCarQuery request, CancellationToken cancellationToken);
}