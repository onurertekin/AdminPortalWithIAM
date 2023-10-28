using Contract.Request.Categories;
using Contract.Response.Categories;
using DomainService.Operations;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("geek-yapar-api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryOperations categoryOperations;

        public CategoriesController(CategoryOperations categoryOperations)
        {
            this.categoryOperations = categoryOperations;
        }

        //..
        [HttpGet]
        public ActionResult<SearchCategoriesResponse> Search([FromQuery] SearchCategoriesRequest request)
        {
            var categories = categoryOperations.Search(request.name);

            SearchCategoriesResponse response = new SearchCategoriesResponse();
            foreach (var category in categories)
            {
                response.categories.Add(new SearchCategoriesResponse.Categories()
                {
                    name = category.Name,
                    id = category.Id,

                });
            }

            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        public ActionResult<GetSingleCategoriesResponse> GetSingle(int id)
        {
            var category = categoryOperations.GetSingle(id);
            GetSingleCategoriesResponse response = new GetSingleCategoriesResponse();
            response.id = category.Id;
            response.name = category.Name;
            return new JsonResult(response);
        }

        [HttpPost]
        public void Create([FromBody] CreateCategoriesRequest request)
        {
            categoryOperations.Create(request.name);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] UpdateCategoriesRequest request)
        {
            categoryOperations.Update(id, request.name);
        }

        [HttpDelete("{id}")]
        public void Delete(int id) 
        {
            categoryOperations.Delete(id);
        }

    }
}
