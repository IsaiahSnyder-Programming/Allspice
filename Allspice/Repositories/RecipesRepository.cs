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
            string sql = @"
            SELECT 
            r.*,
            a.* 
            FROM recipes r
            JOIN accounts a ON r.creatorId = a.id
            WHERE r.id = @id;
            ";
            return _db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
            {
                recipe.Creator = account;
                return recipe;
            }, new { id }).FirstOrDefault();
        }

        internal Recipe Create(Recipe recipeData)
        {
            string sql = @"
            INSERT INTO recipes
            (name, description, category, imgUrl, averageTime, creatorId)
            VALUES
            (@Name, @Description, @Category, @ImgUrl, @AverageTime, @CreatorId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, recipeData);
            recipeData.Id = id;
            return recipeData;
        }

        internal string Remove(int id)
        {
            string sql = @"
            DELETE FROM recipes WHERE id = @id LIMIT 1;
            ";
            int rowsAffected = _db.Execute(sql, new { id });
            if (rowsAffected > 0)
            {
                return "delorted";
            }
            throw new Exception("could not delete");
        }
    }
}