using System;
using Allspice.Repositories;
using Allspice.Models;
using System.Collections.Generic;

namespace Allspice.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _ingRepo;
        public IngredientsService(IngredientsRepository ingRepo)
        {
            _ingRepo = ingRepo;
        }

        internal List<Ingredient> GetAll()
        {
            return _ingRepo.GetAll();
        }

        internal Ingredient GetById(int id)
        {
            Ingredient found = _ingRepo.GetById(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal Ingredient Create(Ingredient ingredientData)
        {
            return _ingRepo.Create(ingredientData);
        }
    }
}