using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Request.Contents
{
    public class CreateContentsRequest
    {
        public string? name { get; set; }
        public string? author { get; set; }
        public string? description { get; set; }
        public int categoryId { get; set; }
    }
}
