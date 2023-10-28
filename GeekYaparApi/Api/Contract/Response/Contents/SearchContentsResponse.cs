using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Response.Contents
{
    public class SearchContentsResponse
    {
        public class Contents
        {
            public int id { get; set; }
            public string? name { get; set; }
            public string? description { get; set; }
            public string? author { get; set; }
            public int categoryId { get; set; }
        }
        public SearchContentsResponse()
        {
            contents = new List<Contents>();
        }
        public List<Contents> contents { get; set; }

    }
}
