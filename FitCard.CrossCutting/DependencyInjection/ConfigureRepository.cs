using FitCard.Data.Context;
using FitCard.Data.Implementations;
using FitCard.Data.Repository;
using FitCard.Domain.Interfaces;
using FitCard.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FitCard.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceColletion)
        {
            serviceColletion.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceColletion.AddScoped(typeof(IUserRepository), typeof(UserImplementation));
            serviceColletion.AddScoped(typeof(ICategoriaRepository), typeof(CategoriaImplementation));
            serviceColletion.AddScoped(typeof(IEmpresaRepository), typeof(EmpresaImplementation));
            //conexao com mysql
            //serviceColletion.AddDbContext<MyContext>(
            //        options => options.UseMySql("Server=localhost;Port=3306;Database=dbApi;Uid=root;Pwd=W#k54*%#")
            //    );

            serviceColletion.AddDbContext<FitCardContext>(
                options => options.UseSqlServer("Server=localhost;Database=FitCardDB;User Id=sa;Pwd=W#k54*%#")
            );
        }
    }
}