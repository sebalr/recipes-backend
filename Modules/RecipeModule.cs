using System.Threading.Tasks;
using Carter;
using Carter.ModelBinding;
using Carter.Request;
using Carter.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using to_cook.Models;
using to_cook.Services;

namespace to_cook.Modules
{
    public class RecipeModule : CarterModule
    {
        public RecipeModule(IRecipeService recipeService) : base("recipe")
        {
            Get("/", ctx =>
            {
                var recipes = recipeService.GetAll();
                return ctx.Response.AsJson(recipes);
            });

            Get("/{id:int}", ctx =>
            {
                var id = ctx.GetRouteData().As<int>("id");

                var recipe = recipeService.GetById(id);

                if (recipe != null)
                {
                    return ctx.Response.AsJson(recipe);
                }
                else
                {
                    ctx.Response.StatusCode = 404;
                    return ctx.Response.WriteAsync($"No recipe with id {id} was found");
                }
            });

            Post("/", ctx =>
            {
                var recipe = ctx.Request.Bind<Recipe>();

                var addedRecipe = recipeService.Add(recipe);

                return ctx.Response.AsJson(addedRecipe);
            });

            Put("/{id:int}", ctx =>
            {
                var id = ctx.GetRouteData().As<int>("id");
                var newRecipe = ctx.Request.Bind<Recipe>();

                if (id != newRecipe.Id)
                {
                    ctx.Response.StatusCode = 400;
                    return ctx.Response.WriteAsync("Cant update Id property");
                }

                var editedRecipe = recipeService.Update(id, newRecipe);
                return ctx.Response.AsJson(editedRecipe);

            });

            Delete("/{id:int}", ctx =>
            {
                var id = ctx.GetRouteData().As<int>("id");
                recipeService.Delete(id);
                ctx.Response.StatusCode = 204;
                return Task.CompletedTask;
            });
        }
    }
}
