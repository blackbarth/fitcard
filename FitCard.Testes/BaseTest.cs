using FitCard.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FitCard.Testes
{
    public class BaseTest
    {
        protected FitCardContext ctx;
        public static string connectionString = "Server=localhost;Database=FitCardDBTeste;User Id=sa;Pwd=W#k54*%#";

        public BaseTest(FitCardContext ctx = null)
        {
            this.ctx = ctx ?? GetInMemoryDBContext();
        }

        protected FitCardContext GetInMemoryDBContext()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<FitCardContext>();
            var options = builder.UseSqlServer(connectionString)
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            FitCardContext dbContext = new FitCardContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            return dbContext;

        }
    }
}