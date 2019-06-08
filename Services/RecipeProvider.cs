using System.Collections;
using System.Collections.Generic;
using System.Linq;
using to_cook.Models;

namespace to_cook.Services
{
    public interface IRecipeProvider
    {
        IEnumerable<Recipe> GetAll();
        Recipe GetById(int id);
        Recipe Add(Recipe recipe);
        Recipe Update(int id, Recipe recipe);
        void Delete(int id);
    }

    public class RecipeProvider : IRecipeProvider
    {
        private IRecipeProviderDB _recipeProviderDB;

        public RecipeProvider(IRecipeProviderDB recipeProviderDB)
        {
            _recipeProviderDB = recipeProviderDB;
        }

        public IEnumerable<Recipe> GetAll()
        {
            return this._recipeProviderDB.Recipes();
        }

        public Recipe GetById(int id)
        {
            return this._recipeProviderDB.Recipes().Where(x => x.Id == id).FirstOrDefault();
        }

        public Recipe Add(Recipe recipe)
        {
            this._recipeProviderDB.Recipes().Add(recipe);
            return recipe;
        }

        public Recipe Update(int id, Recipe recipe)
        {
            var oldRecipe = this.GetById(id);
            if (oldRecipe != null)
            {
                oldRecipe.Title = recipe.Title;
                oldRecipe.Description = recipe.Description;
                return oldRecipe;
            }
            else
            {
                return null;
            }
        }

        public void Delete(int id)
        {
            var recipe = this.GetById(id);
            if (recipe != null)
            {
                this._recipeProviderDB.Recipes().Remove(recipe);
            }
        }
    }
}
