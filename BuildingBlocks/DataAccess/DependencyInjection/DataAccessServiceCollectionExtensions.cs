using DataAccess.Repositories;
using DataAccess.Repositories.GenericRepository;
using DataAccess.Repositories.QueryRepository;
using DataAccess.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using UnitOfWorkImplementation = DataAccess.UnitOfWork.UnitOfWork;

namespace DataAccess.DependencyInjection;

public static class DataAccessServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccess(
        this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

        services.AddScoped(typeof(IReadRepository<>), typeof(GenericRepository<>));

        services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));

        services.AddScoped<IUnitOfWork, UnitOfWorkImplementation>();

        return services;
    }
}