using Allspice.Repositories;

namespace Allspice.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _recipeRepo;
        public RecipesService(RecipesRepository recipeRepo)
        {
            _recipeRepo = recipeRepo;
        }
    }
}