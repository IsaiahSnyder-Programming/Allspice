using System;
using System.Collections.Generic;
using Allspice.Models;
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

        internal List<Recipe> GetAll()
        {
            return _recipeRepo.GetAll();
        }

        internal Recipe GetById(int id)
        {
            Recipe found = _recipeRepo.GetById(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal Recipe Create(Recipe recipeData)
        {
            return _recipeRepo.Create(recipeData);
        }

        internal string Remove(int id, Account user)
        {
            Recipe game = _recipeRepo.GetById(id);
            if (game.creatorId != user.Id)
            {
                throw new Exception("you can't do that, nice try.");
            }
            return _recipeRepo.Remove(id);
        }
    }
}