using FitCard.Data.Context;
using FitCard.Domain.Entities;

namespace FitCard.Testes
{
    public class DBUnitTextsMockUnitializer
    {
        public DBUnitTextsMockUnitializer()
        {

        }

        public void Seed(FitCardContext context)
        {
            context.Categoria.Add(new CategoriaEntity { CategoriaNome = "Supermercado" });
            context.Categoria.Add(new CategoriaEntity { CategoriaNome = "Restaurante" });
            context.Categoria.Add(new CategoriaEntity { CategoriaNome = "Borracharia" });
            context.Categoria.Add(new CategoriaEntity { CategoriaNome = "Posto" });
            context.Categoria.Add(new CategoriaEntity { CategoriaNome = "Oficina" });
            context.SaveChanges();

            context.User.Add(new UserEntity { Nome = "FitCard", Email = "dev@fitcard.com.br" });
            context.SaveChanges();
        }
    }
}