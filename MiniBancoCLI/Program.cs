using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniBancoCLI;
using MiniBancoCLI.Infrastructure.Data;
using MiniBancoCLI.Util.ServiceCollection;


var serviceCollection = new ServiceCollection();



//connectionString
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

//builder





var connectionString = configuration.GetConnectionString("DefaultConnection");

//DI



serviceCollection.addServices();


serviceCollection.AddDbContext<MiniBankContext>(options => options.UseSqlServer(connectionString));
serviceCollection.AddScoped<App>();



var serviceProvider = serviceCollection.BuildServiceProvider(validateScopes: true);

try {
    var app = serviceProvider.GetRequiredService<App>();
    app.Run();
}catch (Exception ex) {
    Console.WriteLine($"Error ao inicializar {ex.Message}");
}
