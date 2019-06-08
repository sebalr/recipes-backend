using System.Collections.Generic;
using to_cook.Models;

namespace to_cook.Services
{
    public interface IRecipeProviderDB
    {
        ICollection<Recipe> Recipes();
    }

    public class RecipeProviderDB : IRecipeProviderDB
    {
        ICollection<Recipe> _recipes;

        public RecipeProviderDB()
        {
            _recipes = new HashSet<Recipe>()
            {
                new Recipe() { Id = 1, Title = "Hamburger pizza" },
                new Recipe() { Id = 2, Title = "Argentine Asado" },
                new Recipe() { Id = 3, Title = "Mexican Tacos" },
            };
        }

        public ICollection<Recipe> Recipes()
        {
            return this._recipes;
        }
    }
}
