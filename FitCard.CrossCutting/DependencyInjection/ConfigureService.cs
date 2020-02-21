using FitCard.Domain.Interfaces.Services.Categoria;
using FitCard.Domain.Interfaces.Services.Empresa;
using FitCard.Domain.Interfaces.Services.User;
using FitCard.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FitCard.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceColletion)
        {
            serviceColletion.AddTransient<IUserService, UserService>();
            serviceColletion.AddTransient<ILoginService, LoginService>();
            serviceColletion.AddTransient<ICategoriaService, CategoriaService>();
            serviceColletion.AddTransient<IEmpresaService, EmpresaService>();
        }
    }
}