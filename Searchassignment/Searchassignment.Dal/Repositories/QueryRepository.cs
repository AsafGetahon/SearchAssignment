using Searchassignment.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchassignment.Dal.Repositories
{
    public interface IQueryRepository : IGenericRepository<QueryEntity>
    {

    }
    public class QueryRepository : GenericRepository<QueryEntity>, IQueryRepository
    {

        public QueryRepository(DbEntity dbContext) : base(dbContext)
        {

        }
    }
}
