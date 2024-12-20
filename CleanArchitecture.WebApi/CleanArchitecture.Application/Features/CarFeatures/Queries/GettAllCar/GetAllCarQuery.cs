using CleanArchitecture.Domain.Entities;
using MediatR;
using System.Fabric.Query;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCar;

public sealed record GetAllCarQuery() : IRequest<PagedList<List<Car>>;