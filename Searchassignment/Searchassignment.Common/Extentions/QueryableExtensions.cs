using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Searchassignment.Common.Extentions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params string[] navProperties) where T : class
        {
            if (navProperties != null)
            {
                foreach (var navProperty in navProperties)
                    query = query.Include(navProperty);
            }

            return query;
        }
    }
}
