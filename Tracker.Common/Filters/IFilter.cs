using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Common.Filters
{
    public interface IFilter
    {
        string searchString { get; }
        string sortOrder { get; }
        int pageNumber { get; }
        int pageSize { get; }
    }
}
