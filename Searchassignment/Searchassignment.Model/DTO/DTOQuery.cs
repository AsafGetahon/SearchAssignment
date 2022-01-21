using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchassignment.Model.DTO
{
    public class DTOQuery
    {
        public int Id { get; set; }
        public string QuerySearched { get; set; }
        public DateTime DateLastSearched { get; set; }
    }
}
