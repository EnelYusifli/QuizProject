using Microsoft.Extensions.DependencyInjection;
using Quiz.Core.Repositories;
using Quiz.Data.Repositories;

namespace Quiz.Business;

public static class ServiceRegistration
{
    public static void RegisterRepos(this IServiceCollection services)
    {
        services.AddScoped<IBlogRepository,BlogRepository>();
    }
}
