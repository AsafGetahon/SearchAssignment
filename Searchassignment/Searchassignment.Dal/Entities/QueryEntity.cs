using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchassignment.Dal.Entities
{
    public class QueryEntity
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string QuerySearched { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateLastSearched { get; set; } = DateTime.Now;
    }
}
