using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Allspice.Models;

namespace Allspice.Repositories
{
    public class RecipesRepository
    {
        private readonly IDbConnection _db;

        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }


        internal List<Recipe> GetAll()
        {
            string sql = @"
            SELECT
            g.*,
            a.*
            FROM recipes g
            JOIN accounts a WHERE a.id = g.creatorId;
            ";
            return _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
            {
                recipe.Creator = account;
                return recipe;
            }).ToList();
        }

        internal Recipe GetById(int id)
        {
            throw new NotImplementedException();
        }

        internal Recipe Create(Recipe recipeData)
        {
            throw new NotImplementedException();
        }

        internal string Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}