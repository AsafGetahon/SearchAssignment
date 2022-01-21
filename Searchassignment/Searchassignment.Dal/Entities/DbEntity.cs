using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchassignment.Dal.Entities
{
    public partial class DbEntity : DbContext
    {
        public DbEntity()
        {

        }

        public DbEntity(DbContextOptions<DbEntity> options)
            : base(options)
        {

        }

        public DbSet<QueryEntity> SearchQuery { get; set; }
    }
}

