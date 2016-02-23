using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Common.Filters
{
    public class GenericFilter : IFilter
    {
        public string searchString { get; set; }
        public string sortOrder { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }

        public int defaultPageSize = 10;

        public GenericFilter(string searchString, int pageNumber, int pageSize)
        {
            this.searchString = searchString;
            this.pageNumber = (pageNumber > 0) ? pageNumber : 1;
            this.pageSize = (pageSize > 0 && pageSize <= defaultPageSize) ? pageSize : defaultPageSize;
        }
    }
}
