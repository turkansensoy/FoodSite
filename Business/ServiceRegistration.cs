using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<ICategoryService, CategoryManager>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IRecipeRepository, RecipeRepository>();
            services.AddSingleton<IRecipeService, RecipeManager>();

            services.AddSingleton<IRecipeMaterialService, RecipeMaterialManager>();
            services.AddSingleton<IRecipeMaterialRepository, RecipeMaterialRepository>();

            services.AddSingleton<IMaterialService, MaterialManager>();
            services.AddSingleton<IMaterialRepository, MaterialRepository>();

            return services;
        }
    }
}
