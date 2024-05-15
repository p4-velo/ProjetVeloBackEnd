using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProjetVeloBackEnd.DAL;

public class DbContextEntityFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionStrings"));

        return new AppDbContext(optionsBuilder.Options);
    }
}
//