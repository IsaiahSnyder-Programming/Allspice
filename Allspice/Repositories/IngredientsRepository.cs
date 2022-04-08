using System.Data;
using System.Linq;
using Dapper;
using Allspice.Models;
using System.Collections.Generic;

namespace Allspice.Repositories
{
    public class IngredientsRepository
    {
        private readonly IDbConnection _db;

        public IngredientsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Ingredient> GetAll()
        {
            string sql = @"
            SELECT
            g.*,
            a.*
            FROM ingredients g
            JOIN accounts a WHERE a.id = g.creatorId;
            ";
            return _db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
            {
                ingredient.Creator = account;
                return ingredient;
            }).ToList();
        }

        internal Ingredient GetById(int id)
        {
            string sql = @"
            SELECT 
            i.*,
            a.* 
            FROM ingredients i
            JOIN accounts a ON i.creatorId = a.id
            WHERE i.id = @id;
            ";
            return _db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
            {
                ingredient.Creator = account;
                return ingredient;
            }, new { id }).FirstOrDefault();
        }

        internal Ingredient Create(Ingredient ingredientData)
        {
            string sql = @"
            INSERT INTO ingredients
            (name, quantity, recipeId, creatorId)
            VALUES
            (@Name, @Quantity, @RecipeId, @CreatorId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, ingredientData);
            ingredientData.Id = id;
            return ingredientData;
        }
    }
}