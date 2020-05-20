using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsForNumbers
{
    public class QueryContext : DbContext
    {
        public QueryContext()
                    : base("DbConnection") { }

        public DbSet<Query> Queries { get; set; }

    }
}
