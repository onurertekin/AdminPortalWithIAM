using Contract.Request.GeekYaparApi.Categories;
using Contract.Response.GeekYaparApi;
using Contract.Response.GeekYaparApi.Categories;
using Contract.Response.Users;
using Host.Filters;
using Host.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Host.Controllers.v1.GeekYaparApi.Categories
{
    [ApiController]
    [Route("geek-yapar-api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly HttpHelper httpHelper;
        private readonly string geekYaparApiUrl;
        public CategoriesController(HttpHelper httpHelper, IConfiguration configuration)
        {
            this.geekYaparApiUrl = configuration.GetValue<string>("Services:GeekYaparApi");
            this.httpHelper = httpHelper;
        }

        [HttpGet]
        [Authorizable("Categories_List")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<SearchCategoriesResponse>> Search([FromQuery] SearchCategoriesRequest request)
        {
            SearchCategoriesResponse response = new SearchCategoriesResponse();
            string url = ($"{geekYaparApiUrl}/geek-yapar-api/categories?name={request.name}");
            response = await httpHelper.Get<SearchCategoriesResponse>(url);
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        [Authorizable("Categories_GetSingle")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<GetSingleCategoriesResponse>> GetSingle(int id)
        {
            GetSingleCategoriesResponse response = new GetSingleCategoriesResponse();
            string url = ($"{geekYaparApiUrl}/geek-yapar-api/categories/{id}");
            response = await httpHelper.Get<GetSingleCategoriesResponse>(url);
            return new JsonResult(response);
        }

        [HttpPost]
        [Authorizable("Categories_Create")]
        [RequiredHeaderParameters("Token")]
        public async Task Create([FromBody] CreateCategoriesRequest request)
        {
            await httpHelper.Create($"{geekYaparApiUrl}/geek-yapar-api/categories", request);
        }

        [HttpPut("{id}")]
        [Authorizable("Categories_Update")]
        [RequiredHeaderParameters("Token")]
        public async Task Update(int id, [FromBody] UpdateCategoriesRequest request)
        {
            await httpHelper.Update($"{geekYaparApiUrl}/geek-yapar-api/categories/{id}", request);
        }

        [HttpDelete("{id}")]
        [Authorizable("Categories_Delete")]
        [RequiredHeaderParameters("Token")]
        public async Task Delete(int id)
        {
            await httpHelper.Delete($"{geekYaparApiUrl}/geek-yapar-api/categories/{id}");
        }

    }
}
