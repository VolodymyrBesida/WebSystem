using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsForNumbers
{
    public class Query
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public int CompiledResult { get; set; }

        public Query() { }
    }
}
