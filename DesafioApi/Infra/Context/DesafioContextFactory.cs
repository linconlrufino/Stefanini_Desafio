using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infra.Contexts;
public class DesafioContextFactory : IDesignTimeDbContextFactory<DesafioContext>
{
    public DesafioContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DesafioContext>();
        optionsBuilder.UseSqlServer("Server=127.0.0.1,5434;Database=master;User ID=sa;Password=Stefanini@123;MultipleActiveResultSets=true;Trusted_Connection=False; TrustServerCertificate=True;");

        return new DesafioContext(optionsBuilder.Options);
    }
}