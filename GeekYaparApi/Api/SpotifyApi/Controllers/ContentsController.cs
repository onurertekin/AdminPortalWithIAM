
using Contract.Request.Contents;
using Contract.Response.Contents;
using DomainService.Operations;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("geek-yapar-api/contents")]
    public class ContentsController : ControllerBase
    {
        private readonly ContentOperations contentOperations;

        public ContentsController(ContentOperations contentOperations)
        {
            this.contentOperations = contentOperations;
        }

        [HttpGet]
        public ActionResult<SearchContentsResponse> Search([FromQuery] SearchContentsRequest request)
        {
            //Database'den çektik
            var contents = contentOperations.Search(request.categoryId, request.name, request.description, request.author);

            //Response nesnesini oluşturduk ama henüz boş.
            SearchContentsResponse response = new SearchContentsResponse();

            //Response içindeki contents listesini dolduruyoruz.
            //Tek tek döngü ile dolaşarak response.contents'e ekliyoruz.
            foreach (var content in contents)
            {
                var newContent = new SearchContentsResponse.Contents();

                newContent.id = content.Id;
                newContent.name = content.Name;
                newContent.description = content.Description;
                newContent.author = content.Author;
                newContent.categoryId = content.CategoryId;

                response.contents.Add(newContent);
            }

            //Response'u dönüyoruz.
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        public ActionResult<GetSingleContentResponse> GetSingle(int id)
        {
            //Database'den çektik
            var content = contentOperations.GetSingle(id);
            //Response nesnesini oluşturduk.
            GetSingleContentResponse response = new GetSingleContentResponse();
            //Oluşturduğumuz response nesnesinin içini dolduruyoruz.
            response.id = content.Id;
            response.name = content.Name;
            response.description = content.Description;
            response.author = content.Author;
            response.categoryId = content.CategoryId;
            //Response'u döndürüyoruz.
            return new JsonResult(response);
        }
        [HttpPost]
        public void Create([FromBody] CreateContentsRequest request)
        {
            contentOperations.Create(request.name, request.author, request.description, request.categoryId);
        }
        [HttpPut("{id}")]
        public void Update(int id, UpdateContentsRequest request)
        {
            contentOperations.Update(id, request.name, request.author, request.description, request.categoryId);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            contentOperations.Delete(id);
        }

    }
}
