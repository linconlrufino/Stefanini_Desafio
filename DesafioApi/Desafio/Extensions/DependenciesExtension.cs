using Application.Handlers;
using Domain.Repositories;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions
{
    public static class DependenciesExtension
    {
        public static void AddSqlConnection(this IServiceCollection services, string connectString)
        {
            services.AddDbContext<DesafioContext>(option => option.UseSqlServer(connectString));
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPessoaRepository, PessoaRepository>();
            services.AddTransient<ICidadeRepository, CidadeRepository>();
        }

        public static void AddHandlers(this IServiceCollection services)
        {
            services.AddTransient<PessoaHandler, PessoaHandler>();
            services.AddTransient<CidadeHandler, CidadeHandler>();
        }
    }
}