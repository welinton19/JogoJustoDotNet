using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace JogoJustoDotNet.AppData;

public class JogoDbContextFactory : IDesignTimeDbContextFactory<JogoDbContext>
{
    public JogoDbContext CreateDbContext(string[] args)
    {
        
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("JogoJustoConnection");

        var optionsBuilder = new DbContextOptionsBuilder<JogoDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new JogoDbContext(optionsBuilder.Options);
    }
}
