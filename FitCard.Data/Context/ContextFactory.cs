using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FitCard.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<FitCardContext>
    {
        public FitCardContext CreateDbContext(string[] args)
        {
            //Usado para criar as migra
            //Conexao para MySQL
            //var connectionString = "Server=localhost;Port=3306;Database=FitCardDB;Uid=root;Pwd=W#k54*%#";
            var connectionString = "Server=maximizi.com;Database=FitCardDB;User Id=fitcard;Pwd=fitcard";
            var optionsBuilder = new DbContextOptionsBuilder<FitCardContext>();
            //conexao para MySql
            //optionsBuilder.UseMySql(connectionString);
            optionsBuilder.UseSqlServer(connectionString);
            return new FitCardContext(optionsBuilder.Options);
        }
    }
}