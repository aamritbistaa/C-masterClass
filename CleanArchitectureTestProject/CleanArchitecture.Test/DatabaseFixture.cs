using CleanArchitecture.Application.Mapper;
using CleanArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Test
{
    public class DatabaseFixture : IDisposable
    {
        public AppDbContext mockDbContext = null;
        public DatabaseFixture()
        {
            MapperHelper._isUnitTest = true;

            //ConfigurationStoreOptions storeOptions = new ConfigurationStoreOptions();
            var serviceCollection = new ServiceCollection();
            //serviceCollection.AddSingleton(storeOptions);

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            //object value = builder.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
            builder.UseApplicationServiceProvider(serviceCollection.BuildServiceProvider());

            var databaseContext = new AppDbContext(builder.Options);

            databaseContext.Database.EnsureCreated();


            databaseContext.SaveChanges();
            mockDbContext = databaseContext;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
