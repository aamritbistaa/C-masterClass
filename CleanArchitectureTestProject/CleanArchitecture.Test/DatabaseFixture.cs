using CleanArchitecture.Application.Mapper;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Infrastructure.Context;
using CleanArchitecture.Test.Data;
using IdentityServer4.EntityFramework.Options;
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

            ConfigurationStoreOptions storeOptions = new ConfigurationStoreOptions();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(storeOptions);

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            object value = builder.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
            builder.UseApplicationServiceProvider(serviceCollection.BuildServiceProvider());

            var databaseContext = new AppDbContext(builder.Options);

            databaseContext.Database.EnsureCreated();

            DepartmentInfo.Init();

            var departmentList = DepartmentInfo.DepartmentList;

            UserInfo.Initialize();
            var userList = UserInfo.userList;
           
            try
            {
                databaseContext.Departments.AddRange(departmentList);
                databaseContext.Users.AddRange(userList);
                databaseContext.SaveChanges();
            }
            catch(Exception ex)
            {
                var message = ex.Message;
                throw new Exception(message);
            }
            mockDbContext = databaseContext;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
