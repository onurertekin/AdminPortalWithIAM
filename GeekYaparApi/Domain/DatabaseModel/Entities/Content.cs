using DatabaseModel.Migrations.MsSql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Entities
{
    [Table("Contents")]
    public class Content
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
