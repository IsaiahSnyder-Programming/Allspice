using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Allspice.Services;
using Allspice.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Allspice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : Controller
    {
        private readonly IngredientsService _ingS;

        public IngredientsController(IngredientsService ingS)
        {
            _ingS = ingS;
        }

        [HttpGet]
        public ActionResult<List<Ingredient>> GetAll()
        {
            try
            {
                List<Ingredient> ingredients = _ingS.GetAll();
                return Ok(ingredients);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Ingredient> GetById(int id)
        {
            try
            {
                Ingredient ingredient = _ingS.GetById(id);
                return Ok(ingredient);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Ingredient>> Create([FromBody] Ingredient ingredientData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                ingredientData.creatorId = userInfo.Id;
                Ingredient ingredient = _ingS.Create(ingredientData);
                ingredient.Creator = userInfo;
                return Created($"api/ingredients/{ingredient.Id}", ingredient);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}