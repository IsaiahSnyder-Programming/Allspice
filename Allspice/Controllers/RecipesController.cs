using Allspice.Services;
using Microsoft.AspNetCore.Mvc;

namespace Allspice.Controllers
{
    [Route("[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _rs;

        public RecipesController(RecipesService rs)
        {
            _rs = rs;
        }


    }
}