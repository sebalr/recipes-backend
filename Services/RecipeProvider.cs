using System.Collections.Generic;
using to_cook.Models;

namespace to_cook.Services
{
    public interface IRecipeProvider
    {
        ICollection<Recipe> Recipes();
    }

    public class RecipeProvider : IRecipeProvider
    {
        ICollection<Recipe> _recipes;

        public RecipeProvider()
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
