using Contract.Request.GeekYaparApi.Content;
using Contract.Response.GeekYaparApi.Content;
using Host.Filters;
using Host.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.Controllers.v1.GeekYaparApi.Content
{
    [ApiController]
    [Route("geek-yapar-api/contents")]
    public class ContentsController : ControllerBase
    {
        private readonly HttpHelper httpHelper;
        private readonly string geekYaparApiUrl;
        public ContentsController(HttpHelper httpHelper, IConfiguration configuration)
        {
            this.geekYaparApiUrl = configuration.GetValue<string>("Services:GeekYaparApi");
            this.httpHelper = httpHelper;
        }

        [HttpGet]
        [Authorizable("Contents_List")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<SearchContentsResponse>> Search([FromQuery] SearchContentsRequest request)
        {
            string url = ($"{geekYaparApiUrl}/geek-yapar-api/contents?name={request.name}&description={request.description}&author={request.author}&categoryId={request.categoryId}");
            var response = await httpHelper.Get<SearchContentsResponse>(url);
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        [Authorizable("Contents_GetSingle")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<GetSingleContentResponse>> GetSingle(int id)
        {
            string url = ($"{geekYaparApiUrl}/geek-yapar-api/contents/{id}");
            var response = await httpHelper.Get<GetSingleContentResponse>(url);
            return new JsonResult(response);
        }

        [HttpPost]
        [Authorizable("Contents_Create")]
        [RequiredHeaderParameters("Token")]
        public async Task Create([FromBody] CreateContentsRequest request)
        {
            await httpHelper.Create($"{geekYaparApiUrl}/geek-yapar-api/contents",request);
        }

        [HttpPut("{id}")]
        [Authorizable("Contents_Update")]
        [RequiredHeaderParameters("Token")]
        public async Task Update(int id, UpdateContentsRequest request)
        {
            await httpHelper.Update($"{geekYaparApiUrl}/geek-yapar-api/contents/{id}",request);
        }

        [HttpDelete("{id}")]
        [Authorizable("Contents_Delete")]
        [RequiredHeaderParameters("Token")]
        public async Task Delete(int id)
        {
            await httpHelper.Delete($"{geekYaparApiUrl}/geek-yapar-api/contents/{id}");
        }

    }
}
